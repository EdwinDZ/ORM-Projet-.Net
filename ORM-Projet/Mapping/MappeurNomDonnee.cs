using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMProjet.Mapping
{
    //Déterminez quelles colonnes existent dans cette rangée
    //Déterminez si TEntity à laquelle nous sommes mappés possède des propriétés ayant le même nom que l'une des colonnes (noms de données)
    //Mappez la valeur du DataRow vers TEntity.

    public class MappeurNomDonnee<TEntity> where TEntity : class, new()
    {
        public TEntity Map(DataRow row)
        {
            TEntity entity = new TEntity();
            return Map(row, entity);
        }

        public TEntity Map(DataRow row, TEntity entity)
        {
            var columnNames = row.Table.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToList();
            var properties = (typeof(TEntity)).GetProperties()
                                              .Where(x => x.GetCustomAttributes(typeof(NomDonnee), true).Any())
                                              .ToList();
            foreach (var prop in properties)
            {
                MappeurPropriete.Map(typeof(TEntity), row, prop, entity);
            }

            return entity;
        }

        public IEnumerable<TEntity> Map(DataTable table)
        {
            List<TEntity> entities = new List<TEntity>();
            var columnNames = table.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToList();
            var properties = (typeof(TEntity)).GetProperties()
                                              .Where(x => x.GetCustomAttributes(typeof(NomDonnee), true).Any())
                                              .ToList();
            foreach (DataRow row in table.Rows)
            {
                TEntity entity = new TEntity();
                foreach (var prop in properties)
                {
                    MappeurPropriete.Map(typeof(TEntity), row, prop, entity);
                }
                entities.Add(entity);
            }

            return entities;
        }
    }
}
