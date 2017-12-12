using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMProjet.Mapping
{
    /// <summary>
    /// Mapping des noms de colones sur les objets correspondants 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class DataNames : Attribute
    {
        //getter,  setter de la list _valueNames
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

        /// <summary>
        /// Creation d'une nouvelle liste
        /// </summary>
        public DataNames()
        {
            _valueNames = new List<string>();
        }

        /// <summary>
        /// Définition de la liste avec les paramètre valueNames
        /// </summary>
        /// <param name="valueNames"></param>
        public DataNames(params string[] valueNames)
        {
            _valueNames = valueNames.ToList();
        }
    }
}
