using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCWED2_SG1_21_22_2.Models.Models
{
   public class AveragePublisher
    {
        public string PublisherName { get; set; }

        public double Average { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as AveragePublisher;

            if (other == null)
                return false;

            return other.PublisherName == PublisherName && other.Average == Average;
        }

        public override string ToString()
        {
            return $"{PublisherName} - {Average}";
        }
    }
}
