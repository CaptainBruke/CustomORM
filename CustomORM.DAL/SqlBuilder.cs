using CustomORM.Framework.SqlFilter;
using CustomORM.Framework.SqlMapping;
using CustomORM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomORM.DAL
{
    public class SqlBuilder<T>where T: BaseModel
    {
        private static string _FindSql = null;
        private static string _InsertSql = null;
        private static string _DeleteSql = null;
        private static string _UpdateSql = null;
        
        static SqlBuilder()
        {
            Type type = typeof(T);

            {
                string colunmsString = string.Join(",", type.GetProperties().Select(p => $"[{p.GetMappingName()}]"));
                _FindSql = $"SELECT {colunmsString} FROM [{type.GetMappingName()}] WHERE Id=";
            }
            {
                string columnsString = string.Join(",", type.GetPropertiesWithoutKey().Select(p => $"[{p.GetMappingName()}]"));
                string valuesString = string.Join(",", type.GetPropertiesWithoutKey().Select(p => $"@{p.GetMappingName()}"));
                _InsertSql = $"INSERT INTO [{type.GetMappingName()}] ({columnsString}) VALUES({valuesString}); SELECT @@Identity";
            }
            {
                _DeleteSql = $"DELETE [{type.GetMappingName()}] WHERE Id=";
            }
            {
                string columnsEqueValueString = string.Join(",", type.GetPropertiesWithoutKey().Select(p => $"[{p.GetMappingName()}]=@{p.GetMappingName()}"));
                _UpdateSql = $"UPDATE [{type.GetMappingName()}] SET {columnsEqueValueString} WHERE Id=@Id";
            }
        }

        public static string GetFindSql()
        {
            return _FindSql;
        }
        public static string GetInsertSql()
        {
            return _InsertSql;
        }
        public static string GetDeleteSql()
        {
            return _DeleteSql;
        }

        public static string GetUpdateSql()
        {
            return _UpdateSql;
        }
    }
}
