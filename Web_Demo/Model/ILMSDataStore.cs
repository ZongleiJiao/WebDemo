using System;
using System.Collections.Generic;

namespace Web_Demo.Model
{
    public interface ILMSDataStore
    {
        IEnumerable<CityDto> GetAllCities();
        CityDto GetCity(int cityID);
        void AddNewCity(CityDto newCity);
        void EditCity(int cityID, CityDto city);
        void deleteCity(int cityID);
    }
}
