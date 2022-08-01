using System.ComponentModel.DataAnnotations;

namespace CarApp.Common.ViewModels;

public class UserEditViewModel
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Email { get; set; }
}