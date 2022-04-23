using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCWED2_SG1_21_22_2.Models.Entities;
using XCWED2_SG1_21_22_2.Models.Models;

namespace XCWED2_SG1_21_22_2.Logic.Interfaces
{
    public interface IDesignerLogic
    {
        IList<Designer> ReadAll();

        Designer Read(int id);

        Designer Create(Designer entity);

        Designer Update(Designer entity);

        void Delete(int id);

        AverageDesigner MostPopularDesigner();
    }
}
