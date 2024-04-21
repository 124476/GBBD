using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBBD.Models
{
    public partial class VYStatus
    {
        public string VYColor
        {
            get
            {
                if (Id == 1)
                {
                    return "Green";
                }
                if (Id == 2 || Id == 4)
                {
                    return "Red";
                }
                return "Gray";
            }
        }
    }
}
