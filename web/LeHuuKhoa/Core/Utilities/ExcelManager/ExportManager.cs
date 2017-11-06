using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using LeHuuKhoa.Core.Models;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Table;

namespace LeHuuKhoa.Core.Utilities.ExcelManager
{
    public interface IExportManager
    {
        byte[] ExportCategoriesToXlsx(List<Category> categories);

    }
    public class ExportManager : IExportManager
    {
        protected virtual void SetCaptionStyle(ExcelStyle style)
        {
            style.Fill.PatternType = ExcelFillStyle.Solid;
            style.Fill.BackgroundColor.SetColor(Color.CadetBlue);
            style.Font.Bold = true;
        }
        protected virtual byte[] ExportToXlsx<T>(PropertyByName<T>[] properties, List<T> itemsToExport, string worksheetsTitle)
        {
            using (var stream = new MemoryStream())
            {
                using (var xlPackage = new ExcelPackage(stream))
                {
                    var worksheet = xlPackage.Workbook.Worksheets.Add(worksheetsTitle);
                    

                    var fWorksheet = xlPackage.Workbook.Worksheets.Add("DataForFilters");
                    fWorksheet.Hidden = eWorkSheetHidden.VeryHidden;

                    var mi = typeof(Category)
                        .GetProperties()
                        .Where(pi => pi.Name != "IsPublished" && pi.Name != "IsDeleted")
                        .Select(pi => (MemberInfo)pi)
                        .ToArray();

                    var manager = new PropertyManager<T>(properties.Where(p => !p.Ignore));
                    worksheet.Cells["A1"].LoadFromCollection(itemsToExport, true, TableStyles.Medium18, BindingFlags.CreateInstance, mi);
                    worksheet.Cells.AutoFitColumns();
                    manager.WriteCaption(worksheet, SetCaptionStyle);

                    var row = 2;
                    foreach (var items in itemsToExport)
                    {
                        manager.CurrentObject = items;
                        manager.WriteToXlsx(worksheet, row++, fWorksheet);
                    }

                    xlPackage.Save();
                }
                return stream.ToArray();
            }
        }
        public byte[] ExportCategoriesToXlsx(List<Category> categories)
        {
            var properties = new[]
            {
                new PropertyByName<Category>("Mã Danh Mục", p => p.Id),
                new PropertyByName<Category>("Tên Danh mục Luận", p => p.Name),
                new PropertyByName<Category>("Hình Ảnh", p => p.Avatar),
                new PropertyByName<Category>("Thứ Tự", p => p.DisplayOrder),
                new PropertyByName<Category>("Mô Tả", p => p.Descriptions),
                new PropertyByName<Category>("Công bố", p => p.IsPublished),
                new PropertyByName<Category>("Xóa", p => p.IsDeleted)

            };
            
            return ExportToXlsx(properties, categories, "Danh mục");
        }
    }
}