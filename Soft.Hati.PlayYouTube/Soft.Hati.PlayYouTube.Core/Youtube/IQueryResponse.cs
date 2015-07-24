using System.Collections.Generic;

namespace Soft.Hati.PlayYouTube.Core.Youtube
{
    public interface IQueryResponse
    {
        IDictionary<TypeResult, IList<SearchResult>> Results { get; }
    }
}