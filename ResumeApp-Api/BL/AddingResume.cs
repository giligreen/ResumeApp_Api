using Aspose.Words;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BL
{
   public static class AddingResume
    {
        public static Resume BuildNewResume(string path)
        {
            Resume r = new Resume(path);
            string newPath = ConvertFileToTextFile(path);
            r.WordArr = DividingFileIntoWords(newPath).ToArray();
            r.FillDictionary();
            ResumeClassifier.ClassifyResume(r);
            return r;
        }
        public static void SaveResumeInDB(Resume r)
        {
            string DB_Path = @"DataBase.xlsx";
            var wbook = new XLWorkbook(DB_Path);
            var ws = wbook.Worksheet(1);
            int row = ws.RowsUsed().Count() + 1;
            ws.Cell(row, 1).SetValue<string>(r.Path);
            ws.Cell(row, 2).SetValue<string>(r.Class); 
            wbook.Save();
        }




        /// <summary>
        /// פונקציה שמקבלת נתיב לקובץ וורד או פידיאף - קובץ בינארי, וממירה אותו לקובץ טקסט
        /// </summary>
        /// <param name="File_path">נתיב הקובץ להמרה</param>
        /// <returns>נתיב לקובץ הטקסט החדש</returns>
        public static string ConvertFileToTextFile(String FilePath)
        {
            var doc = new Document("my-files/Resume database/" + FilePath);
            string newPath = "my-files/text files/" + Path.GetFileNameWithoutExtension(FilePath) + ".txt";
            doc.Save(newPath);
            return newPath;
        }


        /// <summary>
        ///  string פונקציה שמקבלת נתיב של קובץ טקסט וקוראת את כל תוכנו לתוך משתנה
        /// </summary>
        /// <param name="filePath">נתיב לקובץ</param>
        /// <returns></returns>
        public static string ReadAllTextFromFile(string filePath)
        {

            string s = File.ReadAllText(filePath);
            return s;
        }


        /// <summary>
        /// פונקציה שמקבלת נתיב לקובץ טקסט 
        /// ומחזירה מערך של מילים 
        /// </summary>
        /// <param name="filePass"></param>
        public static List<string> DividingFileIntoWords(string filePath)
        {
            string text = ReadAllTextFromFile(filePath);

            string cleantext = Regex.Replace(text, "[^A-Za-z א-ת]", " ").TrimStart().TrimEnd();
            List<string> words = new List<string>();
            char[] charsToSplit = new char[2];
            charsToSplit[0] = ' ';
            charsToSplit[1] = (char)10;
            words = cleantext.Split(charsToSplit).ToList<string>();


            words.RemoveAll((item) => string.IsNullOrEmpty(item) || string.IsNullOrWhiteSpace(item));
            words.RemoveRange(0, 10);
            words.RemoveRange(words.Count() - 22 - 1, 23);
            return words;
        }

      
    }
}
