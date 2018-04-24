using System;
namespace Web_Demo.Model
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public string Description{ get; set; }
        public int NumberOfPointInterest{ get; set; }

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
