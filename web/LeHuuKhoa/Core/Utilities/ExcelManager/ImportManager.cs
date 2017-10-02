using System;
using System.IO;
using System.Linq;
using LeHuuKhoa.Core.Models;
using OfficeOpenXml;

namespace LeHuuKhoa.Core.Utilities.ExcelManager
{
    public interface IImportManager
    {
        void ImportCategoriesFromXlsx(Stream stream);
    }
    public class ImportManager : IImportManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public ImportManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void ImportCategoriesFromXlsx(Stream stream)
        {
            #region properties
            var properties = new[]
            {
                new PropertyByName<PostCategory>("Id"),
                new PropertyByName<PostCategory>("Name"),
                new PropertyByName<PostCategory>("DisplayOrder"),
                new PropertyByName<PostCategory>("ImageUrl"),
                new PropertyByName<PostCategory>("Descriptions")
            };
            #endregion

            var manager = new PropertyManager<PostCategory>(properties);
            using (var xlPackage = new ExcelPackage(stream))
            {
                var worksheet = xlPackage.Workbook.Worksheets.FirstOrDefault();
                if (worksheet == null)
                    throw new WorkSheetNotFoundException("No worksheet found");

                var iRow = 2;

                while (true)
                {
                    var allColumnsAreEmpty = manager.GetProperties
                        .Select(property => worksheet.Cells[iRow, property.PropertyOrderPosition])
                        .All(cell => string.IsNullOrEmpty(cell?.Value?.ToString()));

                    if (allColumnsAreEmpty)
                        break;

                    manager.ReadFromXlsx(worksheet, iRow);
                    var id = manager.GetProperty("Id").StringValue;
                    var category = _unitOfWork.Categories.Get(id);
                    var isNew = category == null || id == null;
                    category = category ?? new PostCategory();

                    category.Name = manager.GetProperty("Name").StringValue;
                    category.ImageUrl = manager.GetProperty("ImageUrl").StringValue;
                    category.Descriptions = manager.GetProperty("Descriptions").StringValue;
                    category.DisplayOrder = manager.GetProperty("DisplayOrder").ByteValue;

                    if (isNew)
                    {
                        try
                        {
                            category.Id = Guid.NewGuid().ToString();
                            _unitOfWork.Categories.Add(category);
                        }
                        catch (Exception e)
                        {
                            throw new Exception(e.Message);
                        }
                    }
                    else
                        category.Modify(category.Name, category.DisplayOrder, category.ImageUrl, category.Descriptions);

                    iRow++;
                    _unitOfWork.Complete();
                }
            }
        }
    }
}