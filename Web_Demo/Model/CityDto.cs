using System;
namespace Web_Demo.Model
{
    public class CityDto
    {
        public int Id;
        public string Name;
        public string Description;
        public int NumberOfPointInterest;

        public static CityDto CreateCityFromBody(CityDto city){
            CityDto newCity = new CityDto();
            newCity.Name = city.Name;
            newCity.Description = city.Description;
            newCity.NumberOfPointInterest = city.NumberOfPointInterest;
            return newCity;
        }

        public CityDto()
        {
        }
    }


}
