using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
    internal class SQLCommandRunner<T>
    {
        private string[] primaryKeyColumns;

        private string[] columns;

        private string[] propertyNames;

        public SQLCommandRunner(string[] primaryKeyColumns, string[] columns, string[] propertyNames)
        {
            this.primaryKeyColumns = primaryKeyColumns ?? new string[0];
            this.columns = columns ?? new string[0];
            this.propertyNames = propertyNames ?? new string[0];
        }

        public IList<T> ExtractDataFromSQLReader(SqlCommand cmd)
        {

            var ObjectList = new List<T>();

            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {

                T Object = (T)Activator.CreateInstance(typeof(T));

                SetObjectProperties(r, Object, columns, propertyNames);
                SetObjectProperties(r, Object, primaryKeyColumns, primaryKeyColumns);

                ObjectList.Add(Object);

            }

            return ObjectList;

        }

        private void SetObjectProperties(SqlDataReader r, T Object, string[] columnArray, string[] propertyArray)
        {
            for (int i = 0; i < columnArray.Length; i++)
            {

                Type type = typeof(T);
                PropertyInfo property = type.GetProperty(propertyArray[i]);
                var DBValue = r[columnArray[i]];

                if (property != null && DBValue != DBNull.Value && property.CanWrite)
                {
                    property.SetValue(Object, DBValue);
                }
            }
        }
    }
}
