using System;
using System.Collections.Generic;
using System.Text;

namespace CustomORM.Model
{
    public class Mussic :BaseModel
    {
       public int crawlerId { get; set; }
        public string allName{ get; set; }
        public string name{ get; set; }
        public string  singer { get; set; }
        public string  url{ get; set; }
        public string  dowloadUrl{ get; set; }
        public string  passWord{ get; set; }
        public string  album{ get; set; }
        public string  rate{ get; set; }
        public string  languge{ get; set; }
        public string  size{ get; set; }
        public DateTime  date{ get; set; }
        public string  lyricist{ get; set; }
        public string  composer{ get; set; }
        public string  lyric{ get; set; }
    }
}
