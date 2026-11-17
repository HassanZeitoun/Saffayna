using System.ComponentModel.DataAnnotations;

namespace Saffayna.Application.Categories;

// What the client sends to create a category.
// There is no Id: we generate it on the server (in the service, Step 5.2).
// Attributes go on the constructor parameters, not on "property:". ASP.NET Core validates
// positional records through their constructor and throws if the attributes are on the property.
public sealed record CreateCategoryRequest(
    [Required, StringLength(100)] string Name, // same limit as HasMaxLength(100); Required also rejects "" and "   "
    Guid? ParentId);                           // null = main category, value = subcategory