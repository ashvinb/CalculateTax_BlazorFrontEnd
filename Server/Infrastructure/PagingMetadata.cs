using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Woolworths.FoodISO.WebClient.Infrastructure
{
    public class PagingMetadata
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
    }
}
