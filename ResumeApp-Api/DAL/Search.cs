
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
        //public static byte[] SearchBySubject(string subject)
        //{

        //    switch (subject)
        //    {
        //        case "Accounting":
        //            subject = "Accountin".ToUpper();
        //            break;
        //        case "Office Management":
        //            subject = "OfficeManagemen".ToUpper();
        //            break;
        //        case "Education":
        //            subject = "Educatio".ToUpper();
        //            break;
        //        case "Graphics And Design":
        //            subject = "GraphicsAndDesig".ToUpper();
        //            break;
        //        case "Computer Science":
        //            subject = "CompProgramin".ToUpper();
        //            break;
        //        case "Architecture":
        //            subject = "Architectur".ToUpper();
        //            break;
        //        default:
        //            break;
        //    }
        //    byte[] byteArray = null;
        //    int index = 0;
        //    var DB_Path = @"my_files\DataBase.xlsx";
        //    var wbook = new XLWorkbook(DB_Path);
        //    var ws = wbook.Worksheet(1);
        //    List<Document> files = new List<Document>();
        //    for (int i = 2; i <= ws.RowsUsed().Count(); i++)
        //    {
        //        if (ws.Cell(i, 2).GetValue<string>().ToUpper() == subject.ToUpper())
        //        {
        //            byteArray = System.IO.File.ReadAllBytes(ws.Cell(i, 1).GetValue<string>());
        //            //byteArray = System.IO.File.ReadAllBytes(@"M:\פרוייקט\GIT פרוייקט עם\ResumeApp_Api\ResumeApp - Api\ResumeApp - Api\my_files\אבוחצירא.pdf");
        //        }
        //    }
        //    if (byteArray == null)
        //    {
        //        //byteArray = System.IO.File.ReadAllBytes(ws.Cell(5, 1).GetValue<string>());
        //        return null;
        //    }
        //    wbook.Save();
        //    return byteArray;
        //}
        public static List<string> SearchBySubject(string subject)
        {

            switch (subject)
            {
                case "Accounting":
                    subject = "Accountin".ToUpper();
                    break;
                case "Office Management":
                    subject = "OfficeManagemen".ToUpper();
                    break;
                case "Education":
                    subject = "Educatio".ToUpper();
                    break;
                case "Graphics and Design":
                    subject = "GraphicsAndDesig".ToUpper();
                    break;
                case "Software Engineer":
                    subject = "CompProgramin".ToUpper();
                    break;
                case "Architecture":
                    subject = "Architectur".ToUpper();
                    break;
                default:
                    break;
            }

            int index = 0;
            var DB_Path = @"my_files\DataBase.xlsx";
            var wbook = new XLWorkbook(DB_Path);
            var ws = wbook.Worksheet(1);
            List<string> files = new List<string>();
            for (int i = 2; i <= ws.RowsUsed().Count(); i++)
            {
                if (ws.Cell(i, 2).GetValue<string>().ToUpper() == subject.ToUpper())
                {
                    files.Add(@"http://127.0.0.1:8887/my_files/" + ws.Cell(i, 1).GetValue<string>());
                    index++;
                    if (index >= 10)
                    {
                        break;
                    }
                }
            }

            wbook.Save();
            return files;
        }



    }
}
