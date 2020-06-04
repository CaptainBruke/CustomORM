using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CustomORM.Framework.SqlMapping
{
    public static class MappingExtend
    {
        public static string GetMappingName(this MemberInfo type)
        {
            if (type.IsDefined(typeof(AbstractMappingAttribut), true))
            {
                var attribute = type.GetCustomAttribute<AbstractMappingAttribut>();
                return attribute.GetName();
            }
            else
            {
                return type.Name;
            }
        }


    }
}
