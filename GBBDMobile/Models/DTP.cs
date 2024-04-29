using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBBDMobile.Models
{
    public class DTP
    {
        public int Id { get; set; }
        public string Place { get; set; }
        public string Comment { get; set; }
        public string Other { get; set; }
        public string OtherKol { get; set; }
        public DateTime DateTime { get; set; }
        public string ClassDTP { get; set; }
        public int Kol { get; set; }
        [JsonIgnore]
        public byte[] Photo { get; set; }
    }
}
