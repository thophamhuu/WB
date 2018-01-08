using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Nop.Core
{
    /// <summary>
    /// Paged list
    /// </summary>
    /// <typeparam name="T">T</typeparam>
    [CollectionDataContract]
    public class APIPagedList<T> : IAPIPagedList<T> where T:class
    {

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="source"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        public APIPagedList(IQueryable<T> source, int pageIndex, int pageSize)
        {
            int total = source.Count();
            this.TotalCount = total;
            this.TotalPages = total / pageSize;

            if (total % pageSize > 0)
                TotalPages++;

            this.PageSize = pageSize;
            this.PageIndex = pageIndex;
            this.Items = source.Skip(pageIndex * pageSize).Take(pageSize).ToList();
        }


        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="source"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        public APIPagedList(IList<T> source, int pageIndex, int pageSize)
        {
            TotalCount = source.Count();
            TotalPages = TotalCount / pageSize;

            if (TotalCount % pageSize > 0)
                TotalPages++;

            this.PageSize = pageSize;
            this.PageIndex = pageIndex;
            this.Items = source.Skip(pageIndex * pageSize).Take(pageSize).ToList();
        }


        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="source"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        public APIPagedList(IEnumerable<T> source, int pageIndex, int pageSize, int totalCount)
        {
            TotalCount = totalCount;
            TotalPages = TotalCount / pageSize;

            if (TotalCount % pageSize > 0)
                TotalPages++;

            this.PageSize = pageSize;
            this.PageIndex = pageIndex;
            this.Items = source.ToList();
        }
        [DataMember]
        public int PageIndex { get; private set; }
        [DataMember]
        public int PageSize { get; private set; }
        [DataMember]
        public int TotalCount { get; private set; }
        [DataMember]
        public int TotalPages { get; private set; }
        [DataMember]

        public bool HasPreviousPage
        {
            get { return (PageIndex > 0); }
        }
        [DataMember]
        public bool HasNextPage
        {
            get { return (PageIndex + 1 < TotalPages); }
        }
        [DataMember]
        public List<T> Items { get; }

    }
}
