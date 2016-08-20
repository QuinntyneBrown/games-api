using GamesApi.Dtos;
using System.Collections.Generic;

namespace GamesApi.Services
{
    public interface IGameService
    {
        GameAddOrUpdateResponseDto AddOrUpdate(GameAddOrUpdateRequestDto request);
        ICollection<GameDto> Get();
        GameDto GetById(int id);
        dynamic Remove(int id);
    }
}
