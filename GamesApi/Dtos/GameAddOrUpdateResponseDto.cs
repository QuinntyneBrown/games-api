namespace GamesApi.Dtos
{
    public class GameAddOrUpdateResponseDto: GameDto
    {
        public GameAddOrUpdateResponseDto(Models.Game entity)
        :base(entity)
        {

        }
    }
}
