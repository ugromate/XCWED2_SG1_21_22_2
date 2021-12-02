using Microsoft.AspNetCore.Http;
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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PublisherController : Controller
    {
        readonly IPublisherLogic publisherLogic;

        public PublisherController(IPublisherLogic PublisherLogic)
        {
            this.publisherLogic = PublisherLogic;
        }

        // GET: api/Publisher/GetAll
        [HttpGet]
        [ActionName("GetAll")]
        public IEnumerable<Publisher> Get()
        {
            return publisherLogic.ReadAll();
        }

        // GET api/Publisher/Get/5
        [HttpGet("{id}")]
        public Publisher Get(int id)
        {
            return publisherLogic.Read(id);
        }

        // POST api/Publisher/Create
        [HttpPost]
        [ActionName("Create")]
        public ApiResult Post(Publisher Publisher)
        {
            var result = new ApiResult(true);

            try
            {
                publisherLogic.Create(Publisher);
            }
            catch (Exception)
            {
                result.IsSuccess = false;
            }

            return result;
        }

        // PUT api/Publisher/Update
        [HttpPut]
        [ActionName("Update")]
        public ApiResult Put(Publisher Publisher)
        {
            var result = new ApiResult(true);

            try
            {
                publisherLogic.Update(Publisher);
            }
            catch (Exception)
            {
                result.IsSuccess = false;
            }

            return result;
        }

        // DELETE api/Publisher/Delete/5
        [HttpDelete("{id}")]
        public ApiResult Delete(int id)
        {
            var result = new ApiResult(true);

            try
            {
                publisherLogic.Delete(id);
            }
            catch (Exception)
            {
                result.IsSuccess = false;
            }

            return result;
        }

        //GET: api/Publisher/GetPublisherAverages
        [HttpGet]
        [ActionName("GetPublisherAverages")]
        public IEnumerable<AveragePublisher> GetPublisherAverages()
        {
            return publisherLogic.GetPublisherAverages();
        }
    }
}
