using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookstoreProject.ViewModel
{
	public class AddRoleViewModel
	{
		[Required]
		[Display(Name ="Role")]
        public string RoleName { get; set; }
    }
}
