using System.Collections.Generic;
using A37_EPLAYERS.Models;

namespace A37_EPLAYERS.Interfaces
{
    public interface INoticias
    {
        void Create(Noticias n);

        List<Noticias> ReadAll();

        void Update(Noticias n);

        void Delete(int id);
    }
}