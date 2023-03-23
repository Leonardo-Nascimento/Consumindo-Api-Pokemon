using DesafioPokemon.Infra.Context;

namespace DesafioPokemon.Infra.Uow
{

    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;
        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void Commit()
        {
            _dataContext.SaveChanges();
        }

        public void Rollback()
        {
            
        }
    }
}
