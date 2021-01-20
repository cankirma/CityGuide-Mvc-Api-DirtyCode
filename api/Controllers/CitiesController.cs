using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos;
using api.Models;
using AutoMapper;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private IAppRepository _appRepository;
        private IMapper _mapper;

        public CitiesController(IAppRepository appRepository,IMapper mapper)
        {
            _appRepository = appRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult GetCities()
        {
            //var cities = _appRepository.GetCities().Select(c => new CityForListDto {Description = c.Description, Name = c.Name, Id = c.Id, PhotoUrl = c.Photos.FirstOrDefault(p => p.IsMain == true).Url}).ToList();
            var cities = _appRepository.GetCities();
            var citiestoReturn = _mapper.Map<List<CityForListDto>>(cities);
            return Ok(citiestoReturn);
        }
        [HttpGet]
        [Route("detail")]
        public ActionResult GetCitiesById(int id)
        {
            
            var city = _appRepository.GetCityById(id);
            var citytoReturn = _mapper.Map<List<CityForDetailDto>>(city);
            return Ok(citytoReturn);
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add([FromBody]City city)
        {
            _appRepository.Add(city);
            _appRepository.SaveAll();
            return Ok(city);
        }
    }
}
