using System;
using System.Collections.Generic;
using GamesApi.Dtos;
using GamesApi.Data;
using System.Linq;

namespace GamesApi.Services
{
    public class GameService : IGameService
    {
        public GameService(IUow uow, ICacheProvider cacheProvider)
        {
            _uow = uow;
            _repository = uow.Games;
            _cache = cacheProvider.GetCache();
        }

        public GameAddOrUpdateResponseDto AddOrUpdate(GameAddOrUpdateRequestDto request)
        {
            var entity = _repository.GetAll()
                .FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            if (entity == null) _repository.Add(entity = new Models.Game());
            entity.Name = request.Name;
            _uow.SaveChanges();
            return new GameAddOrUpdateResponseDto(entity);
        }

        public ICollection<GameDto> Get()
        {
            ICollection<GameDto> response = new HashSet<GameDto>();
            var entities = _repository.GetAll().Where(x => x.IsDeleted == false).ToList();
            foreach (var entity in entities) { response.Add(new GameDto(entity)); }
            return response;
        }

        public GameDto GetById(int id)
        {
            return new GameDto(_repository.GetAll().Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault());
        }

        public dynamic Remove(int id)
        {
            var entity = _repository.GetById(id);
            entity.IsDeleted = true;
            _uow.SaveChanges();
            return id;
        }

        protected readonly IUow _uow;
        protected readonly IRepository<Models.Game> _repository;
        protected readonly ICache _cache;
    }
}
