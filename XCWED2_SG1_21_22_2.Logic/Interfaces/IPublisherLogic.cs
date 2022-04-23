using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCWED2_SG1_21_22_2.Models.Entities;
using XCWED2_SG1_21_22_2.Models.Models;

namespace XCWED2_SG1_21_22_2.Logic.Interfaces
{
    public interface IPublisherLogic
    {
        IList<Publisher> ReadAll();

        Publisher Read(int id);

        Publisher Create(Publisher entity);

        Publisher Update(Publisher entity);

        void Delete(int id);

        IEnumerable<AveragePublisher> GetPublisherAverages();
    }
}
