using System.Linq;

namespace EasyTemplateCore.Services
{
    public static class QueryExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="pageNo"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static IQueryable<T> ApplyPaging<T>(
            this IQueryable<T> query, int pageNo, int pageSize)
        {
            if (pageNo <= 0)
            {
                pageNo = 1;
            }

            if (pageSize <= 0)
            {
                pageSize = 10;
            }

            var skipCount = (pageNo - 1) * pageSize;
            return query.Skip(skipCount).Take(pageSize);
        }
    }
}
