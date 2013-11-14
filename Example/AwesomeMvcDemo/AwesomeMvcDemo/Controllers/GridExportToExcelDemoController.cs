using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using AwesomeMvcDemo.Models;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.Controllers
{
    public class GridExportToExcelDemoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetItems(GridParams g)
        {
            return Json(BuildGridModel(g));
        }

        private GridModel<Lunch> BuildGridModel(GridParams g)
        {
            return new GridModelBuilder<Lunch>(Db.Lunches.AsQueryable(), g)
            {
                MakeFooter = gi =>
                                {
                                    if (gi.Level == 0)
                                    {
                                        return new { Id = "Total", Price = "Min: " + gi.Items.Min(o => o.Price), Date = "Max: " + gi.Items.Max(o => o.Date).ToShortDateString() };
                                    }

                                    return new { Price = "Min: " + gi.Items.Min(o => o.Price), Date = "Max: " + gi.Items.Max(o => o.Date).ToShortDateString() };
                                }
            }.Build();
        }

        [HttpPost]
        public ActionResult ExportGridToExcel(GridParams g)
        {
            var gridModel = BuildGridModel(g);

            var columns = new[] { "Id", "Person", "Food", "Price", "Date", "Location" };

            var workbook = GridExcelBuilder.Build(gridModel, columns);

            var stream = new MemoryStream();
            workbook.Write(stream);
            stream.Close();

            return File(stream.ToArray(), "application/vnd.ms-excel", "lunches.xls");
        }

        /// <summary>
        /// Demonstrates the simplest way of creating an excel workbook 
        /// it exports all the lunches records, without taking into count any sorting/paging that is done on the client side
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ExportAllToExcel()
        {
            var workbook = new HSSFWorkbook();
            var sheet = workbook.CreateSheet("sheet1");
            var columns = new[] { "Id", "Person", "Food", "Location" };
            var headerRow = sheet.CreateRow(0);

            //create header
            for (int i = 0; i < columns.Length; i++)
            {
                var cell = headerRow.CreateCell(i);
                cell.SetCellValue(columns[i]);
            }

            //fill content 
            for (int i = 0; i < Db.Lunches.Count; i++)
            {
                var rowIndex = i + 1;
                var row = sheet.CreateRow(rowIndex);

                for (int j = 0; j < columns.Length; j++)
                {
                    var cell = row.CreateCell(j);
                    var o = Db.Lunches[i];
                    cell.SetCellValue(o.GetType().GetProperty(columns[j]).GetValue(o, null).ToString());
                }
            }

            var stream = new MemoryStream();
            workbook.Write(stream);
            stream.Close();

            return File(stream.ToArray(), "application/vnd.ms-excel", "lunches.xls");
        }
    }

    public static class GridExcelBuilder
    {
        public static HSSFWorkbook Build<T>(GridModel<T> gridModel, string[] columns)
        {
            var workbook = new HSSFWorkbook();
            var sheet = workbook.CreateSheet("sheet1");
            var headerRow = sheet.CreateRow(0);

            //create header
            for (int i = 0; i < columns.Length; i++)
            {
                var cell = headerRow.CreateCell(i);
                cell.SetCellValue(columns[i]);
            }

            var currentRow = 0;

            if (gridModel.Data.Groups != null)
            {
                foreach (var groupView in gridModel.Data.Groups)
                {
                    BuildGroup(sheet, columns, ref currentRow, groupView);
                }
            }
            else if (gridModel.Data.Items != null)
            {
                BuildItems(sheet, columns, ref currentRow, gridModel.Data.Items);
            }

            if (gridModel.Data.Footer != null)
            {
                BuildFooter(sheet, columns, ref currentRow, gridModel.Data.Footer);
            }

            return workbook;
        }

        private static void BuildGroup<T>(ISheet sheet, string[] columns, ref int currentRow, GroupView<T> groupView)
        {
            if (groupView.Header != null)
            {
                currentRow++;
                var row = sheet.CreateRow(currentRow);
                var cell = row.CreateCell(0);
                cell.SetCellValue(groupView.Header.Content);
            }

            if (groupView.Groups != null)
            {
                foreach (var groupViewx in groupView.Groups)
                {
                    BuildGroup(sheet, columns, ref currentRow, groupViewx);
                }
            }
            else if (groupView.Items != null)
            {
                BuildItems(sheet, columns, ref currentRow, groupView.Items);
            }

            if (groupView.Footer != null)
            {
                BuildFooter(sheet, columns, ref currentRow, groupView.Footer);
            }
        }

        private static void BuildItems(ISheet sheet, string[] columns, ref int currentRow, IList<object> items)
        {
            //fill content 
            foreach (var item in items)
            {
                currentRow++;
                var row = sheet.CreateRow(currentRow);

                for (int columnIndex = 0; columnIndex < columns.Length; columnIndex++)
                {
                    var cell = row.CreateCell(columnIndex);
                    CellSetValue(cell, columns[columnIndex], item);
                }
            }
        }

        private static void BuildFooter(ISheet sheet, string[] columns, ref int currentRow, object footer)
        {
            currentRow++;
            var row = sheet.CreateRow(currentRow);
            for (int columnIndex = 0; columnIndex < columns.Length; columnIndex++)
            {
                var cell = row.CreateCell(columnIndex);
                CellSetValue(cell, columns[columnIndex], footer);
            }
        }

        private static void CellSetValue(ICell cell, string column, object item)
        {
            var prop = item.GetType().GetProperty(column);

            if (prop != null)
            {
                var value = prop.GetValue(item, null);
                if (prop.PropertyType == typeof(DateTime))
                {
                    cell.SetCellValue(((DateTime)value).ToShortDateString());
                }
                else if (prop.PropertyType == typeof(int))
                {
                    cell.SetCellValue(Convert.ToDouble(value));
                }
                else
                {
                    cell.SetCellValue(value.ToString());
                }
            }
        }
    }
}