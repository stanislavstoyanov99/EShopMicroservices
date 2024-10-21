namespace Ordering.Infrastructure.Data.Extensions
{
    public class InitialData
    {
        public static IEnumerable<Customer> Customers =>
            new List<Customer>
            {
                Customer.Create(CustomerId.Of(new Guid("58c49479-ec65-4de2-86e7-033c546291aa")), "stanislav", "stanislav@gmail.com"),
                Customer.Create(CustomerId.Of(new Guid("189dc8dc-990f-48e0-a37b-e6f2b60b9d7d")), "john", "john@gmail.com")
            };

        public static IEnumerable<Product> Products =>
            new List<Product>
            {
                Product.Create(ProductId.Of(new Guid("44c3ac0c-577a-49b0-9495-052827d47ccd")), "Samsung S10", 800),
                Product.Create(ProductId.Of(new Guid("6f9233b3-a26b-4b61-84a7-44d86e884023")), "Iphone 15", 1000),
                Product.Create(ProductId.Of(new Guid("eb513701-5e67-4b7f-a757-4f88727aa521")), "Samsung S22+", 1200),
                Product.Create(ProductId.Of(new Guid("b69d7729-1e40-40b0-8747-950fdca2921d")), "Huawei P40 Pro", 900)
            };

        public static IEnumerable<Order> OrdersWithItems
        {
            get
            {
                var address1 = Address.Of("Stanislav", "Stoyanov", "stanislav@gmail.com", "Dupnishka", "Bulgaria", "Pernik", "2420");
                var address2 = Address.Of("John", "Smith", "john@gmail.com", "Avenue 1", "USA", "New York", "08050");

                var payment1 = Payment.Of("stanislav", "5555555555554444", "12/28", "355", 1);
                var payment2 = Payment.Of("john", "8885555555554444", "06/30", "222", 2);

                var order1 = Order.Create(
                    OrderId.Of(Guid.NewGuid()),
                    CustomerId.Of(new Guid("58c49479-ec65-4de2-86e7-033c546291aa")),
                    OrderName.Of("ORD_1"),
                    shippingAddress: address1,
                    billingAddress: address1,
                    payment1);

                order1.Add(ProductId.Of(new Guid("44c3ac0c-577a-49b0-9495-052827d47ccd")), 2, 500);
                order1.Add(ProductId.Of(new Guid("6f9233b3-a26b-4b61-84a7-44d86e884023")), 1, 400);

                var order2 = Order.Create(
                    OrderId.Of(Guid.NewGuid()),
                    CustomerId.Of(new Guid("189dc8dc-990f-48e0-a37b-e6f2b60b9d7d")),
                    OrderName.Of("ORD_2"),
                    shippingAddress: address2,
                    billingAddress: address2,
                    payment2);

                order2.Add(ProductId.Of(new Guid("eb513701-5e67-4b7f-a757-4f88727aa521")), 1, 650);
                order2.Add(ProductId.Of(new Guid("b69d7729-1e40-40b0-8747-950fdca2921d")), 2, 450);

                return new List<Order> { order1, order2 };
            }
        }
    }
}
