# CustomORM
基于.net core 3.1。使用ado.net 写出最基础的增删改查的自定义ORM

Based on. Net core 3.1. use ado.net Write out the most basic add, delete, modify and query custom ORM

数据库脚本在：CustomORM\CustomORM.DAL 的文件夹下
1.主程序：CustomORM
2.CustomORM.DAL 提供底层和数据库交互的支持，生成sql,sql泛型缓存。构成基本的增删改查的支持
3.CustomORM.Framework 提供表映射，字段映射，包含：标记特性和方法。
4.CustomORM.Model 数据库表的对应的模型，数据库表Mussic和model一致，数据库表Test和model故意不一致，表名称，字段名称不一致，使用特性标记映射。
