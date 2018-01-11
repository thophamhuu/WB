
using System.Collections.Generic;

namespace Nop.Core
{

    /// <summary>
    /// API Paged list interface
    /// </summary>
    public interface IAPIPagedList<T>
    {
        int PageIndex { get;  }
        int PageSize { get;  }
        int TotalCount { get;  }
        int TotalPages { get;  }
        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
        List<T> Items { get;  }
    }
}
