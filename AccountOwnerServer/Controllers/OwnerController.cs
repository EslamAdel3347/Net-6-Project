using AutoMapper;
using Contracts;
using Entities.Dto;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace AccountOwnerServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase {


        private readonly ILoggerManager _logger;
        private readonly IRepositorywrapper repositorywrapper;
        private readonly IMapper _mapper;

        public OwnerController(ILoggerManager logger, IRepositorywrapper repositorywrapper, IMapper mapper)
        {
            _logger = logger;
            this.repositorywrapper = repositorywrapper;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllOwners()
        {

            try
            {
                var Owner = repositorywrapper.Owner.GetAllOwners();

                _logger.LogInfo($"Returned all owners from database.");

                var Result = _mapper.Map<IEnumerable<OwnerDto>>(Owner);
                return Ok(Result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllOwners action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [Route("GetOwnerByName")]
        public IActionResult GetOwnerByName(string Name)
        {

            try
            {
                var Owner = repositorywrapper.Owner.GetOwnerByname(Name);
                _logger.LogInfo($"Returned all owners from database.");
                var Result = _mapper.Map<OwnerDto>(Owner);
                return Ok(Result);
                
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllOwners action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        
   
        [HttpGet("{OwnerId}", Name = "GetOwnerById")]
        public IActionResult GetOwnerById(Guid OwnerId)
        {

            try
            {
                var Owner = repositorywrapper.Owner.GetOwnerWithDetails(OwnerId);
                if (Owner!=null)
                {
                    _logger.LogInfo($"Returned  owners  data from database.");
                    var Result = _mapper.Map<OwnerDto>(Owner);
                    return Ok(Result);
                }
                else
                {
                    _logger.LogError($"Owner with id: {OwnerId}, hasn't been found in db.");
                    return NotFound();
                }
               

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOwnerById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPost]
        public IActionResult CreateOwner([FromBody ]CreateOwnerDto Createowner)
        {

            try
            {
                
                if (Createowner is null)
                {
                    _logger.LogError($"Owner object sent from client is null");
                    return NotFound();
                  
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid owner object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var OwnerEnriry = _mapper.Map<Owner>(Createowner);

                repositorywrapper.Owner.Create(OwnerEnriry);
                repositorywrapper.Save();


                    _logger.LogInfo($"add new  owners   to database.");
                var CreatedOwner = _mapper.Map<OwnerDto>(OwnerEnriry);
                return CreatedAtRoute("GetOwnerById", new { OwnerId = CreatedOwner.Id }, CreatedOwner);



            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOwnerById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
