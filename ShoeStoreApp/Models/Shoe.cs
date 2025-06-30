using ShoeStoreApp.Interfaces;

namespace ShoeStoreApp.Models;

public class Shoe : IPurchasable
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public int Size { get; set; }
    public string Color { get; set; }
    public double Price { get; set; }
    public int InStock { get; set; }

    public void Purchase()
    {
        if (InStock > 0)
        {
            InStock--;
        }
    }

    public override string ToString()
    {
        return $"{Id}. {Brand} - Size: {Size}, Color: {Color}, Price: {Price}, Stock: {InStock}";
    }
}