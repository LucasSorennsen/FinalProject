using EventManagerProject.Classes;

namespace EventManagerProject;

public partial class InventoryPage : ContentPage
{
    public InventoryPage()
    {
        InitializeComponent();
    }
    private List<Inventory> _allProducts = new List<Inventory>();

    public string viewAllProducts()
    {
        var allProducts = new System.Text.StringBuilder();

        allProducts.AppendLine("ID\t\tName\tPrice\tStock\tSold");
        foreach (var item in _allProducts)
        {
            allProducts.AppendLine($"{item.prodID}\t{item.prodName}\t{item.prodPrice}\t{item.prodStock}\t{item.prodSold}");
        }

        return allProducts.ToString();
    }

    void OnProductIDTextChanged(object sender, TextChangedEventArgs e)
    {
        string oldText = e.OldTextValue;
        string newText = e.NewTextValue;
        string myText = productID.Text;
    }
    void OnProductIDCompleted(object sender, EventArgs e)
    {
        int id = Int32.Parse(((Entry)sender).Text);
    }

    void OnProductNameTextChanged(object sender, TextChangedEventArgs e)
    {
        string oldText = e.OldTextValue;
        string newText = e.NewTextValue;
        string myText = productName.Text;
    }
    void OnProductNameCompleted(object sender, EventArgs e)
    {
        string name = ((Entry)sender).Text;
    }
    void OnProductPriceTextChanged(object sender, TextChangedEventArgs e)
    {
        string oldText = e.OldTextValue;
        string newText = e.NewTextValue;
        string myText = productPrice.Text;
    }
    void OnProductPriceCompleted(object sender, EventArgs e)
    {
        int price = Int32.Parse(((Entry)sender).Text);
    }

    void OnProductStockTextChanged(object sender, TextChangedEventArgs e)
    {
        string oldText = e.OldTextValue;
        string newText = e.NewTextValue;
        string myText = productStock.Text;
    }
    void OnProductStockCompleted(object sender, EventArgs e)
    {
        int stock = Int32.Parse(((Entry)sender).Text);
    }

    void OnProductSoldTextChanged(object sender, TextChangedEventArgs e)
    {
        string oldText = e.OldTextValue;
        string newText = e.NewTextValue;
        string myText = productSold.Text;
    }
    void OnProductSoldCompleted(object sender, EventArgs e)
    {
        int sold = Int32.Parse(((Entry)sender).Text);
    }

    public void AddProducts(int id, string name, int price, int stock, int sold)
    {

        var product = new Inventory(id, name, price, stock, sold);
        _allProducts.Add(product);
    }

    public void SubmitProductInfo(object sender, EventArgs e)
    {
        submitproduct.Text = viewAllProducts().ToString();
    }
}