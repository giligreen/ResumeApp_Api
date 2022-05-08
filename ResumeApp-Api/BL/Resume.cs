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
        public  IDictionary<string,int> AttributesValues { get; set; }


        public Resume()
        {

        }

        public Resume(string path)
        {
            Path = path;
            //הוספת התכונות בעץ למילון יחד עם הערך 0  כרגע
            //foreach (var item in collection)
            //{
            AttributesValues.Add("???", 0);

            //}
          
                }
        /// <summary>
        /// פונקציה שעוברת וממלאה את המילון של תכונות הקו"ח באפסים או אחדות ע"פ מערך המילים שלו
        /// </summary>
        public void FillDictionary()
        {
            foreach (var pair in this.AttributesValues)
            {
                if (this.WordArr.Any(x => x == pair.Key))
                {
                    //???   זה או זה לבדןק 
                    this.AttributesValues.Add(pair.Key, 1);
                    this.AttributesValues[pair.Key] = 1;
                }

            }
        }


    }
}
