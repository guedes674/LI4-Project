using ComplicadaMente.Models;

public class CartService
{
    public event Action? OnChange;

    public class CartItem
    {
        public int ProductId { get; set; }
        public string ProductType { get; set; } // "QuebraCabeca" or "Peca"
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    public List<CartItem> Items { get; set; } = new();

    public void AddItem(int productId, string productType, string? name, decimal price, int quantity = 1)
    {
        var item = Items.FirstOrDefault(i => i.ProductId == productId && i.ProductType == productType);
        if (item != null)
        {
            item.Quantity += quantity;
        }
        else
        {
            Items.Add(new CartItem
            {
                ProductId = productId,
                ProductType = productType,
                Name = name,
                Price = price,
                Quantity = quantity
            });
        }
        OnChange?.Invoke();
    }

    public void RemoveItem(int productId, string productType)
    {
        var item = Items.FirstOrDefault(i => i.ProductId == productId && i.ProductType == productType);
        if (item != null)
            Items.Remove(item);
        OnChange?.Invoke();
    }

    public void UpdateQuantity(int productId, string productType, int quantity)
    {
        var item = Items.FirstOrDefault(i => i.ProductId == productId && i.ProductType == productType);
        if (item != null)
            item.Quantity = quantity;
        OnChange?.Invoke();
    }

    public void Clear()
    {
        Items.Clear();
        OnChange?.Invoke();
    }
}