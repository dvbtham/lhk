﻿using System;
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
                new PropertyByName<Category>("Id"),
                new PropertyByName<Category>("Name"),
                new PropertyByName<Category>("DisplayOrder"),
                new PropertyByName<Category>("ImageUrl"),
                new PropertyByName<Category>("BackgroundImage"),
                new PropertyByName<Category>("ShortDescriptions"),
                new PropertyByName<Category>("Descriptions")
            };
            #endregion

            var manager = new PropertyManager<Category>(properties);
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

                    var isNew = category == null;
                    category = category ?? new Category();

                    category.Name = manager.GetProperty("Name").StringValue;
                    category.Avatar = manager.GetProperty("Avatar").StringValue;
                    category.Descriptions = manager.GetProperty("Descriptions").StringValue;
                    category.DisplayOrder = manager.GetProperty("DisplayOrder").ByteValue;

                    if (isNew)
                    {
                        try
                        {
                            category.Id = SlugHelper.ToUnsignString(category.Name);
                            _unitOfWork.Categories.Add(category);
                        }
                        catch (Exception e)
                        {
                            throw new Exception(e.Message);
                        }
                    }
                    else
                        category.Modify(category.Name, category.DisplayOrder, category.Avatar, category.Descriptions);

                    iRow++;
                    _unitOfWork.Complete();
                }
            }
        }
    }
}