using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMProjet.Configuration
{
    /// <summary>
    /// Gestion des paramètres de la requête SQL
    /// </summary>
    class DboParameter
    {
        // Clé
        public String Key { get; set; }
        // Valeur
        public String Value { get; set; }

        // Type acceptés
        private Type[] typeAccepted =
        {
            typeof(Char),
            typeof(Byte),
            typeof(Int16),
            typeof(Int32),
            typeof(Int64),
            typeof(UInt16),
            typeof(UInt32),
            typeof(UInt64),
            typeof(String),
            typeof(Boolean),
            typeof(DateTime)
        };

        /// <summary>
        /// Associer une valeur a une clé
        /// </summary>
        /// <param name="key">Clé du paramètre</param>
        /// <param name="value">Valeur du paramètre</param>
        public DboParameter(String key, object value)
        {
            this.Key = key;
            // Teste de la présence du type
            if (TestTypeValue(value.GetType()))
            {
                // Adaptation du type datetime au format YYYY-MM-DD hh:mm:ss
                if (value.GetType().Equals(typeof(DateTime)))
                {
                    DateTime d = (DateTime)value;
                    this.Value = d.Year + "-" + d.Month + "-" + d.Day + " " + d.Hour + ":" + d.Minute + ":" + d.Second;
                }
                else if (value.GetType().Equals(typeof(String)))
                {
                    // TODO Parser pour éviter les injection SQL
                    this.Value = EscapeParam((String)value);
                }
                else if (value.GetType().Equals(typeof(Boolean)))
                {
                    // TODO Changer True/False en 0/1 /!\ prise en compte du SGBD les valeurs peuvent différer.
                    this.Value = ChangeBoolean((Boolean)value);
                }
                else
                {
                    this.Value = value.ToString();
                }
            }
            else
            {
                // TODO Lever une exception spécifique
                throw new Exception();
            }
        }

        private String EscapeParam(String param)
        {
            throw new NotImplementedException();
        }

        private string ChangeBoolean(bool value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Vérifier la présence du paramètre dans la liste des type accepté
        /// </summary>
        /// <param name="valueTypeName">Type de variable à tester</param>
        /// <returns>
        /// True si le type est présent
        /// False si le type n'est pas présent
        /// </returns>
        private Boolean TestTypeValue(Type valueTypeName)
        {
            return typeAccepted.Contains<Type>(valueTypeName);
        }
    }
}
