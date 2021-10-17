using System.Linq;
using XCWED2_HFT_2021221.Models.Entities;
using XCWED2_HFT_2021221.Repository.DbContexts;
using XCWED2_HFT_2021221.Repository.Interfaces;

namespace XCWED2_HFT_2021221.Repository.Repositories
{
    public class PublisherRepository : RepositoryBase<Publisher, int>, IPublisherRepository
    {
        public PublisherRepository(XCWED2_HFT_2021221DbContext context) : base(context)
        {
        }

        public override Publisher Read(int id)
        {
            return ReadAll().SingleOrDefault(x => x.Id == id);
        }


    }
}
