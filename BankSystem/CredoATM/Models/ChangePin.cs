using CredoATM.Infrastracture.Resources;
using System.ComponentModel.DataAnnotations;

namespace CredoATM.Models;

public class ChangePin
{
    [Required]
    [RegularExpression("^[0-9]{4}$", ErrorMessage = ErrorMessage.Pin)]
    public string Pin { get; set; }
}