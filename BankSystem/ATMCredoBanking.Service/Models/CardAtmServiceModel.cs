namespace AtmCredoBanking.Service.Models;
public class CardAtmServiceModel
{
    public int Id { get; set; }
    public int UserAccountId { get; set; }

    public bool Replaceable { get; set; } = false;


}
