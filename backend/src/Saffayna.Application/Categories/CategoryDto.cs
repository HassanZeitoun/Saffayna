namespace Saffayna.Application.Categories;

// What the API returns. No Parent object, only ParentId: no cycles, no over-fetching.
public sealed record CategoryDto(Guid Id, string Name, Guid? ParentId);