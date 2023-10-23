using System.Data.SqlClient;


namespace CareerCloud.ADODataAccessLayer
{
    internal class SQLCommandBuilder<T>
    {
        private string tableName;
        
        private string[] primaryKeyColumns;
        
        private string[] columns;

        private string[] propertyNames;

        private string[] exceptedColumns = { "Time_Stamp" };

        public SQLCommandBuilder(string tableName, string[] primaryKeyColumns, string[] columns, string[] propertyNames)
        {
            this.tableName = tableName;
            this.primaryKeyColumns = primaryKeyColumns ?? new string[0];
            this.columns = columns ?? new string[0];
            this.propertyNames = propertyNames ?? new string[0];
        }


        private string GetInsertStatement()
        {
            string pkColumnParamList = FieldListBuilder.GetCommaSeparatedString(primaryKeyColumns, "@");
            string columnParamList = FieldListBuilder.GetCommaSeparatedString(columns.Except(exceptedColumns).ToArray(), "@");
            string valuesList = FieldListBuilder.ConcatenateWithComma(pkColumnParamList, columnParamList);
            
            string pkColumnList = FieldListBuilder.GetCommaSeparatedString(primaryKeyColumns,"");
            string columnList = FieldListBuilder.GetCommaSeparatedString(columns.Except(exceptedColumns).ToArray(), "");
            string columnsList = FieldListBuilder.ConcatenateWithComma(pkColumnList, columnList);
           

            return $"INSERT INTO {tableName} ({columnsList}) VALUES({valuesList})";

        }

        private string GetDeleteStatement()
        {

            return $"DELETE FROM {tableName} WHERE({FieldListBuilder.GetConditionalExpression(primaryKeyColumns)})";

        }

        private string GetUpdateStatement()
        {
            string setList = FieldListBuilder.GetConditionalExpression(columns.Except(exceptedColumns).ToArray(), "@", "\n,");
            string conditionList = FieldListBuilder.GetConditionalExpression(primaryKeyColumns);

            return $"UPDATE {tableName} SET {setList} WHERE {conditionList}";

        }

        private string GetSelectStatement()
        {

            return $"SELECT * FROM {tableName}";

        }


        public void SetSelectCommand(SqlCommand cmd ) => cmd.CommandText = GetSelectStatement();

        public void SetInsertCommand(SqlCommand cmd, T item) => SetSQLCommand(cmd, GetInsertStatement(), item);

        public void SetUpdateCommand(SqlCommand cmd, T item) => SetSQLCommand(cmd, GetUpdateStatement(), item);



        public void SetDeleteCommand(SqlCommand cmd, T item) => SetSQLCommand(cmd, GetDeleteStatement(), item);

        public void GetUpdateStatement(SqlCommand cmd, T item) => SetSQLCommand(cmd, GetUpdateStatement(), item);

        private void SetSQLCommand(SqlCommand cmd, string commandText, T item)
        {

            if (cmd == null)
            {
                throw new ArgumentNullException("SQL command is not initialized");
            }

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = commandText;

            SetSQLCommandParameters(cmd, primaryKeyColumns, primaryKeyColumns, item);
            SetSQLCommandParameters(cmd, columns, propertyNames, item);

        }

        private void SetSQLCommandParameters(SqlCommand cmd, string[] columnArray, string[] propertyArray, T item)
        {

            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            if (columnArray == null)
            {
                throw new ArgumentNullException("columnArray");
            }


            for (int i = 0; i < columnArray.Length; i++)
            {
                string sqlParamName = "@" + columnArray[i]; 
                string PropertyName = propertyArray[i];


                var sqlParamValue = item.GetType().GetProperty(PropertyName).GetValue(item);
                if ((sqlParamValue == null) && (columnArray[i] == "Time_Stamp")) 
                {
                    DateTime now = DateTime.Now;
                    long bNow = now.ToBinary();
                    byte[] datetime = BitConverter.GetBytes(bNow);

                    sqlParamValue = now;
                }
                
                cmd.Parameters.AddWithValue(sqlParamName, sqlParamValue);
            }
        }

    }
}
