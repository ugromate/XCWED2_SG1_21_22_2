using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCWED2_HFT_2021221.Models.Entities;
using XCWED2_HFT_2021221.Models.Models;

namespace XCWED2_HFT_2021221.Logic.Interfaces
{
   public interface IBoardGameLogic
    {
        IList<BoardGame> ReadAll();

        BoardGame Read(int id);

        BoardGame Create(BoardGame entity);

        BoardGame Update(BoardGame entity);

        void Delete(int id);

        int TwoKidGameCount();

        BoardGame BestAlonePlayable();

        IEnumerable<NationalityCount> GamesByDesignerNationality();
    }
}
