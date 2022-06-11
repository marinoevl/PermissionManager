using PermissionManager.Application.Common.Models;

namespace PermissionManager.Application.Common.Extensions;

internal static class PaginationExtensions
{
    public static Task<PaginatedItems<TDestination>> PaginatedListAsync<TDestination>(
        this IQueryable<TDestination> queryable, int pagePosition, int itemsPerPage,
        CancellationToken cancellationToken)
    {
        return PaginatedItems<TDestination>.CreateAsync(queryable, pagePosition, itemsPerPage, cancellationToken);
    }
}