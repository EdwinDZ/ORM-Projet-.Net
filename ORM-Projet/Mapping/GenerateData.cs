using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMProjet.Mapping
{
    /// <summary>
    /// Récupérer les donneés de la liste et les insére en mémoire dans un objet DataSet
    /// </summary>
    public static class GenerateData
    {
        public static DataSet ToDataSet<T>(this List<T> list)
        {
            Type TypeElement = typeof(T);
            DataSet ds = new DataSet();
            DataTable t = new DataTable();
            ds.Tables.Add(t);

            //Ajoute une colonne à la table pour chaque propriété publique sur T
            foreach (var propInfo in TypeElement.GetProperties())
            {
                Type ColType = Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType;

                t.Columns.Add(propInfo.Name, ColType);
            }

            //Passe par chaque propriété sur T et ajouter chaque valeur à la table

            foreach (T item in list)
            {
                DataRow row = t.NewRow();

                foreach (var propInfo in TypeElement.GetProperties())
                {
                    row[propInfo.Name] = propInfo.GetValue(item, null) ?? DBNull.Value;
                }

                t.Rows.Add(row);
            }

            return ds;

        }
    }
}
