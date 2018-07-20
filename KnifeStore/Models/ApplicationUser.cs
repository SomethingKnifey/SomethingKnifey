using Microsoft.AspNetCore.Identity;

namespace KnifeStore.Models
{
    public class ApplicationUser: IdentityUser
    {
		public string FirstName { get; set; }
		public string LastName { get; set; }
        public bool IsMilitaryOrLE { get; set; }
        public int BasketID { get; set; }
    }

	public static class ApplicationUserRoles
	{
		public const string Member = "Member";
		public const string Admin = "Admin";
	}
}
