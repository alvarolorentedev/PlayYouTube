using System.Collections.Generic;

namespace Soft.Hati.YouPlayVS.Core.Youtube
{
    public interface IQueryResponse
    {
        IDictionary<TypeResult, IList<SearchResult>> Results { get; }
    }
}