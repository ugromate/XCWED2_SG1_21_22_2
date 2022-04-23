﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCWED2_SG1_21_22_2.WpfClient.BL.Interfaces;
using XCWED2_SG1_21_22_2.WpfClient.Models;

namespace XCWED2_SG1_21_22_2.WpfClient
{
    public class BoardGameEditorViaWindowService : IBoardGameEditorService
    {
        public BoardGameModel EditBoardGame(BoardGameModel boardGame)
        {
            var window = new BoardGameEditorWindow(boardGame);

            if (window.ShowDialog() == true)
            {
                return window.BoardGame;
            }

            return null;
        }
    }
}
