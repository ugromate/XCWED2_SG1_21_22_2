using System.Linq;
using XCWED2_SG1_21_22_2.Models.Entities;
using XCWED2_SG1_21_22_2.Repository.DbContexts;
using XCWED2_SG1_21_22_2.Repository.Interfaces;

namespace XCWED2_SG1_21_22_2.Repository.Repositories
{
    public class PublisherRepository : RepositoryBase<Publisher, int>, IPublisherRepository
    {
        public PublisherRepository(XCWED2_SG1_21_22_2DbContext context) : base(context)
        {
        }

        public override Publisher Read(int id)
        {
            return ReadAll().SingleOrDefault(x => x.Id == id);
        }


    }
}
