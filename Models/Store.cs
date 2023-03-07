using Bogus;
using System.Net.Mail;

namespace LinqExercise.Models;
public class Store
{
    public List<Customer> Customers { get; set; }
    public List<Product> Products { get; set; }
    public Store()
    {
        Randomizer.Seed = new Random(8675309);

        var productFaker = new Faker<Product>()
            .RuleFor(p => p.Name, f => f.Commerce.ProductName())
            .RuleFor(p => p.Description, f => f.Commerce.ProductAdjective())
            .RuleFor(p => p.Cost, (f, u) => f.Finance.Amount(0, 100, 2))
            .RuleFor(p => p.ProductId, _ => Guid.NewGuid());

        var products = productFaker.Generate(30);

        var orderFaker = new Faker<Order>()
            .RuleFor(o => o.Status, f => f.PickRandom<OrderStatus>())
            .RuleFor(o => o.Cart, f => Enumerable.Range(1, f.Random.Int(1, 10))
                                                    .Select(x => f.PickRandom(products))
                                                    .ToList());

        var customerFaker = new Faker<Customer>()
            .RuleFor(c => c.Name, f => f.Name.FullName())
            .RuleFor(c => c.Address, f => f.Address.FullAddress())
            .RuleFor(c => c.Phone, f => f.Phone.PhoneNumber())
            .RuleFor(c => c.Email, f => new MailAddress(f.Internet.Email()))
            .RuleFor(c => c.Orders, f => orderFaker.GenerateBetween(1, 7));

        Products = products;
        Customers = customerFaker.Generate(100);
    }
}