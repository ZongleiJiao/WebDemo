using System;
using System.Collections.Generic;
using System.Linq;

namespace Web_Demo.Model
{
    public class CityDataStore
    {
        private static CityDataStore _instance;

        public static CityDataStore getInstance()
        {
            if (_instance == null)
            {
                _instance = new CityDataStore();
            }
            return _instance;
        }

        private static List<CityDto> Seed()
        {
            List<CityDto> Seed = new List<CityDto>();

            Seed.Add(new CityDto
            {
                Id = 1,
                Name = "Brisbane",
                Description = "Brisbaneis the capital of and most populous city in the Australian state of Queensland, " +
                    "and the third most populous city in Australia. Brisbane's metropolitan area has a population of 2.4 million."
            });
            Seed.Add(new CityDto
            {
                Id = 2,
                Name = "Melbourne",
                Description = "Melbourne is the capital and most populous city of the Australian state of Victoria, " +
                    "and the second-most populous city in Australia and Oceania The name Melbourne covers an urban agglomeration spanning " +
                    "2,664 km2 (1,029 sq mi), which comprises the broader metropolitan area, as well as being the common name for its city centre. "
            });
            Seed.Add(new CityDto
            {
                Id = 3,
                Name = "Sydney",
                Description = "Sydney is the state capital of New South Wales and the most populous city in Australia and Oceania. " +
                    "Located on Australia's east coast, the metropolis surrounds the world's largest natural harbour and sprawls " +
                    "about 70 km (43.5 mi) on its periphery towards the Blue Mountains to the west, Hawkesbury to the north " +
                    "and Macarthur to the south. Sydney is made up of 658 suburbs, 40 local government areas and 15 contiguous " +
                    "regions. Residents of the city are known as Sydneysiders"
            });

            return Seed;
        }

        private List<CityDto> _Cities;
        private CityDataStore(){
            _Cities = Seed();
        }


        public List<CityDto> GetAllCities(){
            return _Cities;
        }

        public CityDto GetCityByID(int InputId){

            CityDto result = _Cities.FirstOrDefault((CityDto arg) => arg.Id == InputId);

            return result;

        }

        public void AddCity(CityDto newCity){
            _Cities.Add(newCity);
        }

        public CityDto UpdateCity(CityDto updatedCity){
            CityDto result = _Cities.FirstOrDefault((CityDto arg) => arg.Id == updatedCity.Id);
            if(result != null){
                result.Name = updatedCity.Name;
                result.Description = updatedCity.Description;
                result.NumberOfPointInterest = updatedCity.NumberOfPointInterest;
            }
            return result;
        }

        public bool DeleteCity( int Id){
            bool result = false;
            CityDto resultCity = _Cities.FirstOrDefault((CityDto arg) => arg.Id == Id);
            if(resultCity != null){
                _Cities.Remove(resultCity);
                result = true;
            }
            return result;
        }

    }
}
