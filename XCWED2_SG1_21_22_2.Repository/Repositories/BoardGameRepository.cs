using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCWED2_SG1_21_22_2.Models.Entities;
using XCWED2_SG1_21_22_2.Repository.DbContexts;
using XCWED2_SG1_21_22_2.Repository.Interfaces;

namespace XCWED2_SG1_21_22_2.Repository.Repositories
{
    public class BoardGameRepository : RepositoryBase<BoardGame, int>, IBoardGameRepository
    {
        public BoardGameRepository(XCWED2_SG1_21_22_2DbContext context) : base(context)
        {
        }

        public override BoardGame Read(int id)
        {
            return ReadAll().SingleOrDefault(x => x.Id == id);
        }
    }
}
