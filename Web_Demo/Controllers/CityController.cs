using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web_Demo.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_Demo.Controllers
{
    [Route("api/city")]
    public class CityController : Controller
    {
        private ILMSDataStore _dbStore;

        public CityController(ILMSDataStore dbStore)
        {
            _dbStore = dbStore;
        }

        // GET: api/city
        [HttpGet]
        public JsonResult Get()
        {
            //data from memory
            //var result = CityDataStore.getInstance().GetAllCities();

            //data from DB
            var result = _dbStore.GetAllCities();
            return new JsonResult(result);

        }

        // GET api/city/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //data from memory
            //var cityResult = CityDataStore.getInstance().GetCityByID(id);

            //data from DB
            var cityResult = _dbStore.GetCity(id);
            IActionResult result;

            //请检查返回值是不是 null
            if (cityResult == null)
            {
                result = NotFound();
            }
            else
            {
                result = Ok(cityResult);
            }
            return result;
        }

        // POST api/city
        [HttpPost]
        public IActionResult Post([FromBody]CityDto value)
        {
            //TODO: check value is valid
            //input 值跟 model 对不上, 相应的 property 的值就是 null

            //Memory
            //CityDataStore.getInstance().AddCity(value);

            //DB
            CityDto newCity = CityDto.CreateCityFromBody(value);
            _dbStore.AddNewCity(newCity);

            return Ok(newCity);
        }

        // PUT api/city/5
        [HttpPut("{id}")]
        //[HttpPut]
        public IActionResult Put(int id, [FromBody]CityDto value)
        {
            //TODO: check value is valid
            //IActionResult result;
            //Memory
            //CityDto resultCity = CityDataStore.getInstance().UpdateCity(value);
            //if (resultCity != null)
            //{
            //    result = Accepted(resultCity);
            //}
            //else
            //{
            //    result = NotFound();
            //}
            //return result;

            //DB
            _dbStore.EditCity(id, value);
            return Ok();
        }


        // DELETE api/city/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //Memory
            //bool isRecordExist = CityDataStore.getInstance().DeleteCity(id);
            //IActionResult result;

            //if(isRecordExist){
            //    result = NoContent();
            //}else{
            //    result = NotFound();
            //}
            //return result;
            _dbStore.deleteCity(id);
            return Ok();
        }
    }
}
