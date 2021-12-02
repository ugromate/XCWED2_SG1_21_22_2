using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XCWED2_HFT_2021221.Logic.Interfaces;
using XCWED2_HFT_2021221.Models.Entities;
using XCWED2_HFT_2021221.Models.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XCWED2_HFT_2021221.Endpoint.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BoardGameController : ControllerBase
    {
        readonly IBoardGameLogic boardGameLogic;

        public BoardGameController(IBoardGameLogic boardGameLogic)
        {
            this.boardGameLogic = boardGameLogic;
        }

        // GET: api/BoardGame/GetAll
        [HttpGet]
        [ActionName("GetAll")]
        public IEnumerable<BoardGame> Get()
        {
            return boardGameLogic.ReadAll();
        }

        // GET api/BoardGame/Get/5
        [HttpGet("{id}")]
        public BoardGame Get(int id)
        {
            return boardGameLogic.Read(id);
        }

        // POST api/BoardGame/Create
        [HttpPost]
        [ActionName("Create")]
        public ApiResult Post(BoardGame boardgame)
        {
            var result = new ApiResult(true);

            try
            {
                boardGameLogic.Create(boardgame);
            }
            catch (Exception)
            {
                result.IsSuccess = false;
            }

            return result;
        }

        // PUT api/BoardGame/Update
        [HttpPut]
        [ActionName("Update")]
        public ApiResult Put(BoardGame boardgame)
        {
            var result = new ApiResult(true);

            try
            {
                boardGameLogic.Update(boardgame);
            }
            catch (Exception)
            {
                result.IsSuccess = false;
            }

            return result;
        }

        // DELETE api/BoardGame/Delete/5
        [HttpDelete("{id}")]
        public ApiResult Delete(int id)
        {
            var result = new ApiResult(true);

            try
            {
                boardGameLogic.Delete(id);
            }
            catch (Exception)
            {
                result.IsSuccess = false;
            }

            return result;
        }

        //GET: api/BoardGame/TwoKidGameCount
        [HttpGet]
        [ActionName("TwoKidGameCount")]
        public int TwoKidGameCount()
        {
            return boardGameLogic.TwoKidGameCount();
        }

        //GET: api/BoardGame/GamesByDesignerNationality
        [HttpGet]
        [ActionName("GamesByDesignerNationality")]
        public IEnumerable<NationalityCount> GamesByDesignerNationality()
        {
            return boardGameLogic.GamesByDesignerNationality();
        }

        //GET: api/BoardGame/BestAlonePlayable
        [HttpGet]
        [ActionName("BestAlonePlayable")]
        public BoardGame BestAlonePlayable()
        {
            return boardGameLogic.BestAlonePlayable();
        }
    }
}
