﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XCWED2_HFT_2021221.Logic.Interfaces;
using XCWED2_HFT_2021221.Models.Entities;
using XCWED2_HFT_2021221.Models.Models;

namespace XCWED2_HFT_2021221.Endpoint.Controllers
{
    [Route("api/[controller]")]
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
        public ApiResult Post(Designer designer)
        {
            var result = new ApiResult(true);

            try
            {
                designerLogic.Create(designer);
            }
            catch (Exception)
            {
                result.IsSuccess = false;
            }

            return result;
        }

        // PUT api/Designer/Update
        [HttpPut]
        [ActionName("Update")]
        public ApiResult Put(Designer designer)
        {
            var result = new ApiResult(true);

            try
            {
                designerLogic.Update(designer);
            }
            catch (Exception)
            {
                result.IsSuccess = false;
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
    }
}