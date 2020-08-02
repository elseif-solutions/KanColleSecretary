using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace KanColleSecretary.Logic
{
    [Serializable]
    class KCS
    {
        public string Name { get; set; }
        public Phrases phrases { get; set; }

        public KCS() { }
        
        public KCS(string SecretaryName, Phrases SecretaryPhrases) {
            Name = SecretaryName;
            phrases = SecretaryPhrases;
        }
    }
}
