using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMProjet.Mapping
{
    //Mapping des noms de colones sur les objets correspondants 

    [AttributeUsage(AttributeTargets.Property)]
    public class NomDonnee : Attribute
    {
        protected List<string> _valueNames { get; set; }

        public List<string> ValueNames
        {
            get
            {
                return _valueNames;
            }
            set
            {
                _valueNames = value;
            }
        }

        public NomDonnee()
        {
            _valueNames = new List<string>();
        }

        public NomDonnee(params string[] valueNames)
        {
            _valueNames = valueNames.ToList();
        }
    }
}
