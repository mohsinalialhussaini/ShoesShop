using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace JOOTASHOP.Models
{
    public class viewProductModel
    {
        public List<string> filePath = new List<string>();
        string[] x = Directory.GetFiles(@"C:\Users\Shams Ur Rehman\Desktop\New folder (2)\JOOTASHOP\JOOTASHOP\Content\men");
       
        public viewProductModel()
        {

            foreach (var item in x)
            {
                string s = Path.GetFileName(item);
                filePath.Add(s);
            }
            
        }
        
    }
}