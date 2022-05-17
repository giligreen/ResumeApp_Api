using Aspose.Words;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace BL
{
   public class Search
    {

        public static string SearchBySubject(string subject)
        {
            string sss="";
            string DB_Path = @"my_files\DataBase.xlsx";
            var wbook = new XLWorkbook(DB_Path);
            var ws = wbook.Worksheet(1);
            List<Document> files = new List<Document>();
            for (int i = 2; i <= ws.RowsUsed().Count(); i++)
            {
                if (ws.Cell(i,2).GetValue<string>()==subject)
                {
                    var doc = new Document(ws.Cell(i, 1).GetValue<string>());
                    files.Add(doc);
                    sss=ws.Cell(i, 1).GetValue<string>();

                }
            }

            wbook.Save();
            return sss;
        }


    }
}
