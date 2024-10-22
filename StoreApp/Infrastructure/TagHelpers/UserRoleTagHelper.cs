using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace StoreApp.Infrastructure.TagHelpers
{
	[HtmlTargetElement("td",Attributes ="user-role")]
	public class UserRoleTagHelper :TagHelper
	{
		private readonly UserManager<IdentityUser> _userManager;

		[HtmlAttributeName("user-name")]
        public String? UserName { get; set; }

        public UserRoleTagHelper(UserManager<IdentityUser> userManager)
		{
			_userManager = userManager;
		}

		public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
		{
			var user = await _userManager.FindByNameAsync(UserName);
			if(user == null)
			{
				output.Content.SetHtmlContent(string.Empty);//kullanıcı yoksa boş içerik dön
				return;
			}
			var userRoles = await _userManager.GetRolesAsync(user);
			TagBuilder ul = new TagBuilder("ul");

			foreach (var role in userRoles)
			{
				TagBuilder li = new TagBuilder("li");
				li.InnerHtml.Append(role); 
				ul.InnerHtml.AppendHtml(li);
			}

			if (!userRoles.Any())
				output.Content.SetHtmlContent(string.Empty);

			output.Content.AppendHtml(ul);
		}
	}
}
