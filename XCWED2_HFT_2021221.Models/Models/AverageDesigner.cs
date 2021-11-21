using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCWED2_HFT_2021221.Models.Models
{
   public class AverageDesigner
    {
        public string DesignerName { get; set; }

        public double AverageRating { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as AverageDesigner;

            if (other == null)
                return false;

            return other.DesignerName == DesignerName && other.AverageRating == AverageRating;
        }

        public override string ToString()
        {
            return $"{DesignerName} - {AverageRating}";
        }
    }
}
