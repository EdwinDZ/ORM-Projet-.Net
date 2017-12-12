using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMProjet.Mapping
{
    /// <summary>
    /// Obtien la liste des noms de colones de la classe DataNames
    /// </summary>
    public static class DataAttributes
    {
        //List de nom de proprieté
        public static List<string> GetDataNames(Type type, string propertyName)
        {
            //Récupére le type de la propriété de DataNames
            var property = type.GetProperty(propertyName).GetCustomAttributes(false).Where(x => x.GetType().Name == "DataNames").FirstOrDefault();

            //
            if (property != null)
            {
                //Retourne le nom des colones de DataNames
                return ((DataNames)property).ValueNames;
            }

            //Retourne la liste 
            return new List<string>();
        }
    }
}
