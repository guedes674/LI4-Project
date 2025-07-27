using ComplicadaMente.Models;

public class CartService
{
    public event Action? OnChange; // this event is triggered when the cart changes just because of the
                                   // that red pop up that appears when an item is added to the cart
    public class CartItem
    {
        public int ProductId { get; set; }
        public string ProductType { get; set; } // can be "QuebraCabeca" or "Peca"
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    public List<CartItem> Items { get; set; } = new();

    // method to add an item to the cart
    public void AddItem(int productId, string productType, string? name, decimal price, int quantity = 1)
    {
        // check if the item already exists in the cart
        var item = Items.FirstOrDefault(i => i.ProductId == productId && i.ProductType == productType);

        // if it exists, increase the quantity, otherwise add a new item
        if (item != null)
        {
            item.Quantity += quantity;
        }

        // if it doesn't exist, create a new item
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

        // notify that the cart has changed
        OnChange?.Invoke();
    }

    // method to remove an item from the cart
    public void RemoveItem(int productId, string productType)
    {
        // find the item and remove it
        var item = Items.FirstOrDefault(i => i.ProductId == productId && i.ProductType == productType);

        // if item exists, remove it
        if (item != null)
            Items.Remove(item);

        // notify that the cart has changed
        OnChange?.Invoke();
    }

    // method to update the quantity of an item in the cart
    public void UpdateQuantity(int productId, string productType, int quantity)
    {
        // find the item
        var item = Items.FirstOrDefault(i => i.ProductId == productId && i.ProductType == productType);

        // if item exists, update the quantity
        if (item != null)
            item.Quantity = quantity;

        // notify that the cart has changed
        OnChange?.Invoke();
    }

    // method to clear the cart
    public void Clear()
    {
        Items.Clear();

        // notify that the cart has changed
        OnChange?.Invoke();
    }
}