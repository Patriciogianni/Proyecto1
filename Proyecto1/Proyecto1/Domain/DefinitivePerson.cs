using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_10_FINAL.domain
{
    class DefinitivePerson
    {
        private Person personDef;
        private File fileDef;

        public Person PersonDef
        {
            get
            {
                return personDef;
            }

            set
            {
                personDef = value;
            }

        }

        public File FileDef
        {
            get
            {
                return fileDef;
            }
            set
            {
                fileDef = value;
            }

        }

        public void ShowDefPerson()
        {
            Console.WriteLine(PersonDef);
            Console.WriteLine(FileDef);
        }

    }
}