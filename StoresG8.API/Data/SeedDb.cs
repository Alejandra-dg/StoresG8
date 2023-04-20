
using StoresG8.Shared.Entities;
using StoresG8.API.Data;
using StoresG8.API.Services;
using StoresG8.API.Services.Stores.API.Services;
using Microsoft.EntityFrameworkCore;
using Stores.Shared.Entities;
using StoresG8.WEB.Shared.Responses;
using StoresG8.WEB.Shared.Responses.StoresG8.Shared.Responses;
using StoresG8.Shared.Responses.Stores.Shared.Responses;

namespace StoresG8.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IApiService _apiService;

        public SeedDb(DataContext context, IApiService apiService)
        {
            _context = context;
            _apiService = apiService;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
           // await CheckCountriesAsync();
        }

        private async Task CheckCountriesAsync()
        {  // se comentara para coger menos paises no todos 
            if (!_context.Countries.Any())
            {


                Response responseCountries = await _apiService.GetListAsync<CountryResponse>("/v1", "/countries");
            if (responseCountries.IsSuccess)
            { 
                    
                List<CountryResponse> countries = (List<CountryResponse>)responseCountries.Result!;
                foreach (CountryResponse countryResponse in countries)
                {
                    Country country = await _context.Countries!.FirstOrDefaultAsync(c => c.Name == countryResponse.Name!)!;
                    if (country == null)

                        {   // Respuesta de Countries
                           country = new() { Name = countryResponse.Name!, States = new List<State>() };
                        Response responseStates = await _apiService.GetListAsync<StateResponse>("/v1", $"/countries/{countryResponse.Iso2}/states");
                        if (responseStates.IsSuccess)

                        { // Respuesta de Estados
                            List<StateResponse> states = (List<StateResponse>)responseStates.Result!;
                            foreach (StateResponse stateResponse in states!)
                            {
                                State state = country.States!.FirstOrDefault(s => s.Name == stateResponse.Name!)!;
                                if (state == null)
                                {
                                    state = new() { Name = stateResponse.Name!, Cities = new List<City>() };
                                    Response responseCities = await _apiService.GetListAsync<CityResponse>("/v1", $"/countries/{countryResponse.Iso2}/states/{stateResponse.Iso2}/cities");
                                    if (responseCities.IsSuccess)
                                    {  
                                            // Respuesta de Ciudades
                                        List<CityResponse> cities = (List<CityResponse>)responseCities.Result!;
                                        foreach (CityResponse cityResponse in cities)
                                        {
                                            if (cityResponse.Name == "Mosfellsbær" || cityResponse.Name == "Șăulița")
                                            {
                                                continue;
                                            }
                                            City city = state.Cities!.FirstOrDefault(c => c.Name == cityResponse.Name!)!;
                                            if (city == null)
                                            {
                                                state.Cities.Add(new City() { Name = cityResponse.Name! });
                                            }
                                        }
                                    }
                                    if (state.CitiesNumber > 0)
                                    {
                                        country.States.Add(state);
                                    }
                                }
                            }
                        }
                        if (country.StatesNumber > 0)
                        {
                            _context.Countries.Add(country);
                      
                            await _context.SaveChangesAsync();
                        }
                    }
                }
            }
            }
            
        

        }
    }
}

