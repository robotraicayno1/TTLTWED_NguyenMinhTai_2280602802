namespace bai4.Models
{
    public class ShoppingCart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public void AddItem(CartItem item)
        {
            if (item.Quantity <= 0) return; // Tránh thêm sản phẩm với số lượng <= 0

            var existingItem = Items.FirstOrDefault(i => i.ProductId == item.ProductId);
            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
            }
            else
            {
                Items.Add(item);
            }
        }

        public void RemoveItem(int productId)
        {
            Items.RemoveAll(i => i.ProductId == productId);
        }

        // Bổ sung phương thức xóa toàn bộ giỏ hàng
        public void ClearCart()
        {
            Items.Clear();
        }

        // Bổ sung phương thức tính tổng tiền giỏ hàng
        public decimal GetTotalPrice()
        {
            return Items.Sum(i => i.Quantity * i.Price); // Giả sử CartItem có thuộc tính Price
        }
    }

}
