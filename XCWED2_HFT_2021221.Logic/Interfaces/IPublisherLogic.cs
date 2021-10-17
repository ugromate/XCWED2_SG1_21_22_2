using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCWED2_HFT_2021221.Logic.Models;
using XCWED2_HFT_2021221.Models.Entities;

namespace XCWED2_HFT_2021221.Logic.Interfaces
{
    public interface IPublisherLogic
    {
        IList<Publisher> ReadAll();

        Publisher Read(int id);

        Publisher Create(Publisher entity);

        Publisher Update(Publisher entity);

        void Delete(int id);

        IEnumerable<AverageModel> GetPublisherAverages();
    }
}
