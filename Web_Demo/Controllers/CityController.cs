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
        // GET: api/city
        [HttpGet]
        public JsonResult Get()
        {
            var result = CityDataStore.getInstance().GetAllCities();
            return new JsonResult(result);
        }

        // GET api/city/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var cityResult = CityDataStore.getInstance().GetCityByID(id);
            IActionResult result;

            //请检查返回值是不是 null
            if(cityResult == null){
                result = NotFound();
            }else{
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

            CityDataStore.getInstance().AddCity(value);

            return Ok(value);
        }

        // PUT api/city/5
        //[HttpPut("{id}")]
        [HttpPut]
        public IActionResult Put(int id, [FromBody]CityDto value)
        {
            //TODO: check value is valid

            CityDto resultCity = CityDataStore.getInstance().UpdateCity(value);
            IActionResult result;

            if (resultCity !=null ){
                result = Accepted(resultCity);
            }else{
                result = NotFound();
            }
            return result;
        }

        // DELETE api/city/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool isRecordExist = CityDataStore.getInstance().DeleteCity(id);
            IActionResult result;

            if(isRecordExist){
                result = NoContent();
            }else{
                result = NotFound();
            }
            return result;
        }
    }
}
