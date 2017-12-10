using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMProjet.Mapping
{
    //Obtient la liste des noms de colonnes de NomDonnee:
    public static class AssistantDonnee
    {
    
        public static List<string> GetDataNames(Type type, string propertyName)
        {
            var proprite = type.GetProperty(propertyName).GetCustomAttributes(false).Where(x => x.GetType().Name == "NomDonnee").FirstOrDefault();
            if (proprite != null)
            {
                return ((NomDonnee)proprite).ValueNames;
            }
            return new List<string>();
        }
    }
}
