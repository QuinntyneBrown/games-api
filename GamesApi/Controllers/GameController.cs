using GamesApi.Dtos;
using GamesApi.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace GamesApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/game")]
    public class GameController : ApiController
    {
        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(GameAddOrUpdateResponseDto))]
        public IHttpActionResult Add(GameAddOrUpdateRequestDto dto) { return Ok(_gameService.AddOrUpdate(dto)); }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(GameAddOrUpdateResponseDto))]
        public IHttpActionResult Update(GameAddOrUpdateRequestDto dto) { return Ok(_gameService.AddOrUpdate(dto)); }

        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(ICollection<GameDto>))]
        public IHttpActionResult Get() { return Ok(_gameService.Get()); }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GameDto))]
        public IHttpActionResult GetById(int id) { return Ok(_gameService.GetById(id)); }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(int))]
        public IHttpActionResult Remove(int id) { return Ok(_gameService.Remove(id)); }

        protected readonly IGameService _gameService;


    }
}
