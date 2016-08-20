namespace GamesApi.Dtos
{
    public class GameDto
    {
        public GameDto()
        {

        }

        public GameDto(Models.Game entity)
        {
            Id = entity.Id;
            Name = entity.Name;
        }

        public int? Id { get; set; }
        public string Name { get; set; }
    }
}
