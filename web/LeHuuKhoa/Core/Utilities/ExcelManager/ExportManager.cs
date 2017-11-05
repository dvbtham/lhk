using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using LeHuuKhoa.Core.Models;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Table;

namespace LeHuuKhoa.Core.Utilities.ExcelManager
{
    public interface IExportManager
    {
        byte[] ExportPostCategoriesToXlsx(List<PostCategory> categories);

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
                    worksheet.Cells["A1"].LoadFromCollection(itemsToExport, true, TableStyles.Medium18);
                    worksheet.Cells.AutoFitColumns();

                    var manager = new PropertyManager<T>(properties.Where(p => !p.Ignore).ToArray());
                    
                    manager.WriteCaption(worksheet, SetCaptionStyle);

                    var row = 2;
                    foreach (var items in itemsToExport)
                    {
                        manager.CurrentObject = items;
                        manager.WriteToXlsx(worksheet, row++);
                    }
                   
                    xlPackage.Save();
                }
                return stream.ToArray();
            }
        }
        public byte[] ExportPostCategoriesToXlsx(List<PostCategory> categories)
        {
            var properties = new[]
            {
                new PropertyByName<PostCategory>("Id", p => p.Id),
                new PropertyByName<PostCategory>("Name", p => p.Name),
                new PropertyByName<PostCategory>("DisplayOrder", p => p.DisplayOrder),
                new PropertyByName<PostCategory>("ImageUrl", p => p.ImageUrl),
                new PropertyByName<PostCategory>("BackgroundImage", p => p.BackgroundImage),
                new PropertyByName<PostCategory>("ShortDescriptions", p => p.ShortDescriptions),
                new PropertyByName<PostCategory>("Descriptions", p => p.Descriptions)
            };
            return ExportToXlsx(properties, categories, "Danh mục");
        }
    }
}