using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCWED2_SG1_21_22_2.WpfClient.Models
{
   public class PublisherModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public PublisherModel()
        {

        }

        public PublisherModel(int iD, string name, string country)
        {
            ID = iD;
            Name = name;
            Country = country;
        }
    }
}
