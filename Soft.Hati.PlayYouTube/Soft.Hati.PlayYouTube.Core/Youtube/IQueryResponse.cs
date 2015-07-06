using System.Collections.Generic;

namespace Soft.Hati.YouPlayVS.Core.Youtube
{
    public interface IQueryResponse
    {
        IEnumerable<SearchResult> Videos { get; }
    }
}