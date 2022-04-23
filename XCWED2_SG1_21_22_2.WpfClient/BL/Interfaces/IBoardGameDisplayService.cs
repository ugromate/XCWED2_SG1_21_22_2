using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCWED2_SG1_21_22_2.WpfClient.Models;

namespace XCWED2_SG1_21_22_2.WpfClient.BL.Interfaces
{
   public interface IBoardGameDisplayService
    {
        void Display(BoardGameModel boardGame);
    }
}
