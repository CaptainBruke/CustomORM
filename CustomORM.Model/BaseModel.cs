using CustomORM.Framework.SqlFilter;
using System;

namespace CustomORM.Model
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
    }
}
