namespace GamesApi.Data
{
    public interface IUow
    {
        IRepository<Models.Game> Games { get; }
        void SaveChanges();
    }
}
