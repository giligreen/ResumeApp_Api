using Aspose.Words;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace DAL
{
   public class Search
    {
        public static byte[]  SearchBySubject(string subject)
        {
            byte[] byteArray = null;
            var DB_Path = @"my_files\DataBase.xlsx";
            var wbook = new XLWorkbook(DB_Path);
            var ws = wbook.Worksheet(1);
            List<Document> files = new List<Document>();
            for (int i = 2; i <= ws.RowsUsed().Count(); i++)
            {
                if (ws.Cell(i, 2).GetValue<string>() == subject)
                {
                  byteArray = System.IO.File.ReadAllBytes(ws.Cell(i, 1).GetValue<string>());
                }
            }

            wbook.Save();
            return byteArray;
        }


    }
}
