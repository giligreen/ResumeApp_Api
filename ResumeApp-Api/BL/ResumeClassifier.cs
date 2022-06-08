
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    class ResumeClassifier
    {
        public static string ClassifyResume(Resume r)
        {
            //פעם ראשונה - טעינת העץ מהקובץ
            if (GlobalData.tree == null)
            {
                GlobalData.tree = DecisionTree.LoadTreeFromFile(@"M:\פרוייקט\GIT פרוייקט עם\ResumeApp_Api\ResumeApp-Api\BL\Model\smallTree.xlsx");
            }
            //שליחה לעץ החלטה
           string result = DecisionTree.CalculateResult(GlobalData.tree, r.AttributesValuesDict, "");
            
            r.Class = result;
            return result;
        }
    }
}
