using System.Collections.Generic;
using A37_EPLAYERS.Models;

namespace A37_EPLAYERS.Interfaces
{
    public interface IEquipe
    {

        void Create(Equipe e);

        List<Equipe> ReadAll();

        void Update(Equipe e);

        void Delete(int id);
    }
}
