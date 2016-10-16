using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weirdo
{
   

    public class Stat
    {
        StreamReader sr = new StreamReader(@"stats.txt");

        public int ID { get; set; }
        public string Name { get; set; }
        public int Category { get; set; }
        public int Value { get; set; }

     
        Array values = Enum.GetValues(typeof(StatTypes));
         

        public Stat(int id, int category)
        {
            ID = id;
            Category = category;
            //Category = (int)values.GetValue(RandomNumberGenerator.RandomInt(0, values.Length - 1));

            int index = RandomNumberGenerator.RandomInt(0, StatTemplates.GetStatTemplateByID(Category).StatNames.Count-1);
            
            Name = StatTemplates.GetStatTemplateByID(Category).StatNames[index];
            StatTemplates.GetStatTemplateByID(Category).StatNames.RemoveAt(index);


            Value = RandomNumberGenerator.RandomInt(1, 15);
        }
    }

    
}
