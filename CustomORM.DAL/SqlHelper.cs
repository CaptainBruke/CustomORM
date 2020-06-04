using CustomORM.Framework;
using CustomORM.Model;
using System;
using System.Data.SqlClient;
using System.Linq;
using CustomORM.Framework.SqlMapping;
using System.Reflection;

namespace CustomORM.DAL
{
    public class SqlHelper
    {
        /// <summary>
        /// 查询一条数据 根据主键id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Find<T>(int id) where T : BaseModel
        {
            Type type = typeof(T);
            string sqlStr = $"{SqlBuilder<T>.GetFindSql()}{id}";

            using (SqlConnection conn = new SqlConnection(ConfigrationManager.SqlConnectionString))
            {
                SqlCommand command = new SqlCommand(sqlStr, conn);
                conn.Open();
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    T t = (T)Activator.CreateInstance(type);
                    foreach (var prop in type.GetProperties())
                    {
                        string propName = prop.GetMappingName();
                        prop.SetValue(t, reader[propName] is DBNull ? null : reader[propName]);
                    }
                    return t;
                }
                else
                {
                    return default(T);
                }
            }
        }

        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns>自增id</returns>
        public int Insert<T>(T t) where T : BaseModel
        {
            Type type = t.GetType();
            string sqlStr = $"{SqlBuilder<T>.GetInsertSql()}";
            var paraArray = type.GetProperties().Select(p => new SqlParameter($"@{p.GetMappingName()}", p.GetValue(t) ?? DBNull.Value)).ToArray();
            using (SqlConnection conn = new SqlConnection(ConfigrationManager.SqlConnectionString))
            {
                SqlCommand command = new SqlCommand(sqlStr, conn);
                command.Parameters.AddRange(paraArray);
                conn.Open();
                var reader = command.ExecuteScalar().ToString();
                return int.Parse(reader);
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns>成功失败</returns>
        public bool Delete<T>(T t) where T : BaseModel
        {
            string sqlStr = $"{SqlBuilder<T>.GetDeleteSql()}{t.Id}";
            using (SqlConnection conn = new SqlConnection(ConfigrationManager.SqlConnectionString))
            {
                SqlCommand command = new SqlCommand(sqlStr, conn);
                conn.Open();
                return command.ExecuteNonQuery()>0;
            }
        }

        public bool Update<T>(T t) where T : BaseModel
        {
            Type type = t.GetType();
            string sqlStr = $"{SqlBuilder<T>.GetUpdateSql()}";
            var paraArray = type.GetProperties().Select(p => new SqlParameter($"@{p.GetMappingName()}", p.GetValue(t) ?? DBNull.Value)).ToArray();
            using (SqlConnection conn = new SqlConnection(ConfigrationManager.SqlConnectionString))
            {
                SqlCommand command = new SqlCommand(sqlStr, conn);
                command.Parameters.AddRange(paraArray);
                conn.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }
    }
}
