using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCWED2_SG1_21_22_2.WpfClient.Models
{
    class DesignerModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Nationality { get; set; }

        public DesignerModel()
        {

        }

        public DesignerModel(int iD, string name, string nationality)
        {
            ID = iD;
            Name = name;
            Nationality = nationality;
        }
    }
}
