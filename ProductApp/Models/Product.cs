namespace ProductApp.Models // Product modelini tanımlamak için Models klasöründe bir Product sınıfı oluşturun.
{
    public class Product // Product sınıfı, ürünlerin özelliklerini tanımlamak için kullanılır.
    {
        public int Id { get; set; } // Ürünün benzersiz kimliğini temsil eden Id özelliği.
        public string? ProductName { get; set; } // Ürünün adını temsil eden ProductName özelliği. Nullable olarak tanımlanmıştır.
    }
}