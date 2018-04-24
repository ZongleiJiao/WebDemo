using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Web_Demo.Model
{
    public class LMSDataStore:ILMSDataStore
    {
        private LMSDBContex _ctx;

        public LMSDataStore(LMSDBContex ctx)
        {
            _ctx = ctx;
        }

        private void Save(){
            _ctx.SaveChanges();
        }

        public void AddNewCity(CityDto newCity)
        {
            _ctx.cities.Add(newCity);
            Save();
        }

        public void deleteCity(int cityID)
        {
            var cityToBeDeleted = _ctx.cities.Find(cityID);
            _ctx.cities.Remove(cityToBeDeleted);
            Save();
        }

        public void EditCity(int cityID, CityDto city)
        {
            CityDto cityToBeEdited = _ctx.cities.Find(cityID);
            cityToBeEdited.Name = city.Name;
            cityToBeEdited.Description = city.Description;
            cityToBeEdited.NumberOfPointInterest = city.NumberOfPointInterest;
            Save();

        }

        public IEnumerable<CityDto> GetAllCities()
        {
            return _ctx.cities.OrderBy(x => x.Id).ToList();
        }

        public CityDto GetCity(int cityID)
        {
            return _ctx.cities.Find(cityID);
        }
    }
}
