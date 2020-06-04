using System;
using System.Collections.Generic;
using System.Text;

namespace CustomORM.Framework.SqlMapping
{
    public class AbstractMappingAttribut : Attribute
    {
        private string _Name = null;
        public AbstractMappingAttribut(string name)
        {
            this._Name = name;
        }
        public string GetName()
        {
            return _Name;
        }
    }
}
