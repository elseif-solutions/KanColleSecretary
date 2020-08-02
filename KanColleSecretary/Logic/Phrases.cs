using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace KanColleSecretary.Logic
{
    [Serializable]
    [XmlRoot(ElementName = "Phrases")]
    public class Phrases
    {
        [XmlArrayItem(ElementName = "ListOfSpeeches")]
        public List<string> Speeches = new List<string>( new string[24] ); // 1 line per hour
        
        void Init(string st)
        {
            for (int i = 0; i < 24; i++)
                Speeches[i] = st;
        }
        public Phrases()
        {
            Init("lustrous");
        }
        public Phrases(string st)
        {
            Init(st);
        }
    }
}
