using System.ComponentModel.DataAnnotations;

namespace Saffayna.Application.Categories;

// What the client sends to edit a category.
// The Id comes from the route (PUT /api/categories/{id}), not the body,
// so the client cannot redirect the edit to another row.
public sealed record UpdateCategoryRequest(
    [Required, StringLength(100)] string Name,
    Guid? ParentId);