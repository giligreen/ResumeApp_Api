using ClosedXML.Excel;
using System;
using Aspose.Words;
using System.Collections.Generic;
using System.Linq;

namespace CleanDataBase
{
    class Program
    {
        static void Main(string[] args)
        {
            string DB_Path = @"M:\פרוייקט\GIT פרוייקט עם\ResumeApp_Api\ResumeApp-Api\ResumeApp-Api\my_files\DataBase.xlsx";
            var wbook = new XLWorkbook(DB_Path);
            var ws = wbook.Worksheet(1);
            int num = ws.RowsUsed().Count() / 10;
            for (int i = 1; i < num; i++)
            {
                ws.Row(i).Delete();
            }
            wbook.Save();

        }
    }
}
