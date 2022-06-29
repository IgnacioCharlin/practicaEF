using ClasificadorAnimales.Data.EF;

namespace ClasificadorAnimales.Data.Repository
{
    public abstract class BaseRepository
    {
        protected _20221CPracticaEFContext _Contexto { get; set; }

        public BaseRepository(_20221CPracticaEFContext contexto)
        {
            _Contexto = contexto;
        }

        public void SaveChanges()
        {
            _Contexto.SaveChanges();
        }
    }
}