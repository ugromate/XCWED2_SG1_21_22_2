using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XCWED2_SG1_21_22_2.Logic.Interfaces;
using XCWED2_SG1_21_22_2.Models.DTOs;
using XCWED2_SG1_21_22_2.Models.Entities;
using XCWED2_SG1_21_22_2.Models.Models;

namespace XCWED2_SG1_21_22_2.Endpoint.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DesignerController : Controller
    {
        readonly IDesignerLogic designerLogic;

        public DesignerController(IDesignerLogic designerLogic)
        {
            this.designerLogic = designerLogic;
        }

        // GET: api/Designer/GetAll
        [HttpGet]
        [ActionName("GetAll")]
        public IEnumerable<Designer> Get()
        {
            return designerLogic.ReadAll();
        }

        // GET api/Designer/Get/5
        [HttpGet("{id}")]
        public Designer Get(int id)
        {
            return designerLogic.Read(id);
        }

        // POST api/Designer/Create
        [HttpPost]
        [ActionName("Create")]
        public ApiResult Post(DesignerDTO designer)
        {
            var result = new ApiResult(true);

            try
            {
                designerLogic.Create(new Designer()
                {
                    Id = designer.Id,
                    Name = designer.Name,
                    Nationality = designer.Nationality
                });
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Messages = new List<string>() { ex.Message };
            }

            return result;
        }

        // PUT api/Designer/Update
        [HttpPut]
        [ActionName("Update")]
        public ApiResult Put(DesignerDTO designer)
        {
            var result = new ApiResult(true);

            try
            {
                designerLogic.Update(new Designer()
                {
                    Id = designer.Id,
                    Name = designer.Name,
                    Nationality = designer.Nationality
                });
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Messages = new List<string>() { ex.Message };
            }

            return result;
        }

        // DELETE api/Designer/Delete/5
        [HttpDelete("{id}")]
        public ApiResult Delete(int id)
        {
            var result = new ApiResult(true);

            try
            {
                designerLogic.Delete(id);
            }
            catch (Exception)
            {
                result.IsSuccess = false;
            }


            return result;
        }


        //GET: api/Designer/MostPopularDesigner
        [HttpGet]
        [ActionName("MostPopularDesigner")]
        public AverageDesigner MostPopularDesigner()
        {
            return designerLogic.MostPopularDesigner();
        }


    }
}
