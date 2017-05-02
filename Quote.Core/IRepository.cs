using System.Collections.Generic;

namespace Quote.Core
{
    public interface IRepository
    {
        IEnumerable<Lender> GetLenders();
    }
}