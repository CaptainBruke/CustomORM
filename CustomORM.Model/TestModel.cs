using CustomORM.Framework.SqlMapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomORM.Model
{
    [Table("Test")]
    public class TestModel:BaseModel
    {
        public string Name { get; set; }

        [Colunm("nick")]
        public string NickName { get; set; }
    }
}
