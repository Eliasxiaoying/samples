using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _16_RazorSample.Pages;

public class IndexModel : PageModel
{
    public string Name { get; set; }

    public int Age { get; set; }

    public string Address { get; set; }

    public void OnGet()
    {
        Name = "Elias";
        Age = 22;
        Address = "浙江省杭州市余杭区";
    }
}