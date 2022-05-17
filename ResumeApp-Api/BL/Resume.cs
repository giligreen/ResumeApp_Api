using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Resume
    {
        public string Path { get; set; }
        public string Class { get; set; }
        public string[] WordArr { get; set; }
        public IDictionary<string, string> AttributesValuesDict { get; set; }


        public Resume()
        {

        }

        public Resume(string path)
        {
            Path = path;
            AttributesValuesDict = new Dictionary<string, string>();
            //הוספת התכונות בעץ למילון יחד עם הערך 0  כרגע
            var wbook = new XLWorkbook(@"M:\פרוייקט\GIT פרוייקט עם\ResumeApp_Api\ResumeApp-Api\BL\Model\DecisionTree.xlsx");
            var db = wbook.Worksheet(1);
            var rows = db.RowsUsed().Count();
            for (int i = 2; i < rows; i++)
            {
                if (!db.Cell(i, 4).GetBoolean())
                {
                    string word = db.Cell(i, 2).GetValue<string>();
                    if (!AttributesValuesDict.ContainsKey(word))
                    {
                        AttributesValuesDict.Add(word, "0");
                    }

                }
            }

        }

        public Resume(string path, string c)
        {
            Path = path;
            Class = c;
        }

        /// <summary>
        /// פונקציה שעוברת וממלאה את המילון של תכונות הקו"ח באפסים או אחדות ע"פ מערך המילים שלו
        /// </summary>
        public void FillDictionary()
        {
            List<string> keys = new List<string>(AttributesValuesDict.Keys);
            foreach (string key in keys)
            {

                if (this.WordArr.Any(x => x == key))
                {
                    this.AttributesValuesDict[key] = "1";
                }

            }
        }
    }
}
