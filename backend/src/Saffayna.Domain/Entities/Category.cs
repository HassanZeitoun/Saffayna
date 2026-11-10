namespace Saffayna.Domain.Entities;

// A group of spending, e.g. "Groceries" or "Housing".
public class Category
{
    public Guid Id { get; set; }                 // unique id, we generate it ourselves
    public string Name { get; set; } = string.Empty;   // never null, starts as ""
    public Guid? ParentId { get; set; }          // null = main category; has value = subcategory
    public Category? Parent { get; set; }        // link to the parent category (used by EF later)
}