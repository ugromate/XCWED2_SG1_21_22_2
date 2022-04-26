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
        public ApiResult Post(PublisherDTO publisher)
        {
            var result = new ApiResult(true);

            try
            {
                publisherLogic.Create(new Publisher()
                {
                    Id = publisher.Id,
                    Name = publisher.Name,
                    Country = publisher.Country
                });
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Messages = new List<string>() { ex.Message };
            }

            return result;
        }

        // PUT api/Publisher/Update
        [HttpPut]
        [ActionName("Update")]
        public ApiResult Put(PublisherDTO publisher)
        {
            var result = new ApiResult(true);

            try
            {
                publisherLogic.Update(new Publisher()
                {
                    Id = publisher.Id,
                    Name = publisher.Name,
                    Country = publisher.Country
                });
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Messages = new List<string>() { ex.Message };
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
