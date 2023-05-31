namespace Invoicing.Domain.Services;

public class InvoiceService
{
    private readonly ContextMap _contextMap;

    public InvoiceService(ContextMap contextMap)
    {
        _contextMap = contextMap;
    }

    public void GenerateInvoice()
    {
        var issuer = _contextMap.Get<Company>("Issuer");
        var receiver = _contextMap.Get<Person>("Receiver");
        var order = _contextMap.Get<Order>("Order");

        // Calculate the total price of the products in the order
        decimal totalPrice = 0;
        foreach (var product in order.Products)
        {
            totalPrice += product.Price;
        }

        // Generate the invoice document
        var invoice = new Invoice
        {
            Issuer = issuer,
            Receiver = receiver,
            Order = order,
            TotalAmount = totalPrice,
            InvoiceDate = DateTime.Now
        };

        // Perform additional invoice processing steps (e.g., applying discounts, taxes)
    }
}