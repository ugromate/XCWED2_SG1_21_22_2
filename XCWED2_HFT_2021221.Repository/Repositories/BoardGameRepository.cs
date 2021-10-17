using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCWED2_HFT_2021221.Models.Entities;
using XCWED2_HFT_2021221.Repository.DbContexts;
using XCWED2_HFT_2021221.Repository.Interfaces;

namespace XCWED2_HFT_2021221.Repository.Repositories
{
    public class BoardGameRepository : RepositoryBase<BoardGame, int>, IBoardGameRepository
    {
        public BoardGameRepository(XCWED2_HFT_2021221DbContext context) : base(context)
        {
        }

        public override BoardGame Read(int id)
        {
            return ReadAll().SingleOrDefault(x => x.Id == id);
        }
    }
}
