using Aspose.Words;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace BL
{
    class Search
    {

        public static List<Document> SearchBySubject(string subject)
        {
            string DB_Path = @"DataBase.xlsx";
            var wbook = new XLWorkbook(DB_Path);
            var ws = wbook.Worksheet(1);
            List<Document> files = new List<Document>();
            for (int i = 2; i <= ws.RowsUsed().Count(); i++)
            {
                if (ws.Cell(i,2).ToString()==subject)
                {
                    var doc = new Document(ws.Cell(i, 2).ToString());
                    files.Add(doc);

                }
            }

            wbook.Save();
            return files;
        }


    }
}
