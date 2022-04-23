using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCWED2_SG1_21_22_2.Models.Models
{
   public class NationalityCount
    {
        public string Nationality { get; set; }

        public int Count { get; set; }

        public override string ToString()
        {
            return $"{Nationality} - {Count}";
        }
    }
}
