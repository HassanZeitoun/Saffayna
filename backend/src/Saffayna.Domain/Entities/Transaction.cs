namespace Saffayna.Domain.Entities;

// One expense: "I paid 25 USD at the supermarket on 5 Nov".
public class Transaction
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }          // decimal, never double, for money (no rounding errors)
    public DateOnly Date { get; set; }           // only the day matters, no time needed
    public string? Note { get; set; }            // optional text, "?" means it can be null
    public string? ReceiptPath { get; set; }     // optional photo; we store the file path, not the image

    public Guid CategoryId { get; set; }         // which category this expense belongs to
    public Category Category { get; set; } = null!;  // the link itself; null! tells the compiler "EF will fill it"
}