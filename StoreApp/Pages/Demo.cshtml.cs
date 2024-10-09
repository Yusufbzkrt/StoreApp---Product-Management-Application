using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StoreApp.Pages
{
	public class DemoModel : PageModel
	{
		public String? FullName => HttpContext?.Session?.GetString("name");//bilgiyi oku

        public void OnGet()
		{
		}
		public void OnPost([FromForm] String name)
		{
			HttpContext.Session.SetString("name",name);//key value mantýðý ile parametreleri doldurduk. Key demo.cshtmldeki input name inden gelir	
		}
	}
}
