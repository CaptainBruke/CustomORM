using System;
using System.Collections.Generic;
using System.Text;

namespace CustomORM.Framework.SqlMapping
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TableAttribute :  AbstractMappingAttribut
    {
        public TableAttribute(string className):base(className)
        {

        }
    }
}
