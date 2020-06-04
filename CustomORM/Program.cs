using CustomORM.DAL;
using CustomORM.Model;
using System;

namespace CustomORM
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             手写ORM
            1.创建项目：创建DAL,Model,Framework
            2.DAL:提供泛型查询：基本的增删改查
            3.Model:和数据库表保持一致
            4.Framework:提供数据库连接服务，表名称映射等服务
             */

            SqlHelper sqlHelper = new SqlHelper();

            //查询
            //var musicFirst = sqlHelper.Find<Mussic>(12);
            //var testModelFirst = sqlHelper.Find<TestModel>(1);

            //插入
            //var insertModel = new TestModel()
            //{
            //    Name = "夏薇2",
            //    NickName = "Summer"
            //};
            //var id= sqlHelper.Insert(insertModel);

            //删除
            //var deleteModel= sqlHelper.Find<TestModel>(id);
            //bool deleteRes = sqlHelper.Delete(deleteModel);

            //更新
            //var updateModel= sqlHelper.Find<TestModel>(id);
            //updateModel.NickName = "Summer++";
            //updateModel.Name += "++";
            //bool updateRes = sqlHelper.Update(updateModel);

        }
    }
}
