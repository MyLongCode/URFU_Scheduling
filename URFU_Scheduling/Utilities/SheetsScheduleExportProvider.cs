
using Newtonsoft.Json;
using OfficeOpenXml;
using System.Data;
using URFU_Scheduling_lib.Domain.Entities;
using URFU_Scheduling_lib.Domain.Interfaces;

namespace URFU_Scheduling.Utilities
{
    public class SheetsScheduleExportProvider : IScheduleExportProvider
    {
        private readonly ExcelPackage _excelPackage;
        private byte[] _result;

        public SheetsScheduleExportProvider()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            _excelPackage = new ExcelPackage(new FileInfo("MyWorkbook.xlsx"));
        }

        public object Export(Schedule schedule)
        {
            GenerateSheet(schedule);
            WriteXlsx();
            _excelPackage.Dispose();
            return _result;
        }

        private void GenerateSheet(Schedule schedule)
        {
            var workSheet = _excelPackage.Workbook.Worksheets.Add(schedule.Name);
            var events = schedule.Events.Select(x => new 
            { 
                Name = x.Name, 
                Description = x.Description, 
                Start = x.DateStart.ToString(), 
                End = (x.DateStart + x.Duration).ToString() 
            });

            var serializeData = JsonConvert.SerializeObject(events);
            var table = (DataTable)JsonConvert.DeserializeObject(serializeData, typeof(DataTable))!;

            workSheet.Cells.LoadFromDataTable(table, true);
        }

        private void WriteXlsx()
        {
            using (var ms = new MemoryStream())
            {
                _excelPackage.SaveAs(ms);
                ms.Seek(0, SeekOrigin.Begin);
                _result = ms.ToArray();
            }
        }
    }
}