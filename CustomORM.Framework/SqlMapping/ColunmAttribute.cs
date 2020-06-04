using System;
using System.Collections.Generic;
using System.Text;

namespace CustomORM.Framework.SqlMapping
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ColunmAttribute : AbstractMappingAttribut
    {
        public ColunmAttribute(string name) : base(name)
        {
        }
    }
}
