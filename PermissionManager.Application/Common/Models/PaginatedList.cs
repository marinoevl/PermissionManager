using Microsoft.EntityFrameworkCore;

namespace PermissionManager.Application.Common.Models;

public class PaginatedItems<T>
{
    private PaginatedItems(List<T> items, int totalCount, int currentPageIndex, int itemsPerPage)
    {
        Items = items;
        CurrentPageIndex = currentPageIndex;
        TotalPages = (int)Math.Ceiling(totalCount / (double)itemsPerPage);
        TotalCount = totalCount;
    }

    public List<T> Items { get; }
    public int CurrentPageIndex { get; }
    public int TotalPages { get; }
    public int TotalCount { get; }

    public static async Task<PaginatedItems<T>> CreateAsync(IQueryable<T> items, int currentPageIndex, int itemsPerPage,
        CancellationToken cancellationToken)
    {
        var totalCount = await items.CountAsync(cancellationToken);
        var list = await items.Skip((currentPageIndex - 1) * itemsPerPage).Take(itemsPerPage)
            .ToListAsync(cancellationToken);

        return new PaginatedItems<T>(list, totalCount, currentPageIndex, itemsPerPage);
    }
}