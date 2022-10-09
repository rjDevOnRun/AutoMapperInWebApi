using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DTOs;
using WebApi.Models;
using WebApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantItemController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDbService _dbService;

        public PlantItemController(IMapper mapper, IDbService dbService = null)
        {
            _mapper = mapper;
            _dbService = dbService;
        }

        // GET: api/<PlantItemController>
        [HttpGet]
        public async Task<IEnumerable<PlantItem>> Get()
        {
            var piDtos = await _dbService.GetData<PlantItemDTO>
                ("SELECT * FROM TestPlantpid.T_PlantItem; ");

            if (piDtos == null || piDtos.Count < 1) return null;

            var plantItems = _mapper.Map<List<PlantItemDTO>, List<PlantItem>>(piDtos);

            return plantItems;
        }

        // GET api/<PlantItemController>/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            return "value";
        }
    }
}