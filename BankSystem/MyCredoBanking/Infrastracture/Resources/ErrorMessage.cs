namespace MyCredoBanking.Infrastracture.Resources;

public static class ErrorMessage
{
    public const string IdNumber = "პირადი ნომერი უნდა იყოს რიცხვი და რაოდენობა უნდა იყოს 11";
    public const string CardNumber = "ბარათის ნომერი უნდა იყოს რიცხვი და რაოდენობა უნდა იყოს 16";
    public const string Cvv = "ბარათის Cvv უნდა იყოს რიცხვი და რაოდენობა უნდა იყოს 3";
    public const string Pin = "ბარათის Pin უნდა იყოს რიცხვი და რაოდენობა უნდა იყოს 4";
    public const string Iban = "თქვენს მიერ შეყვანილი ანგარიშის ნომერი არ არის სწორი";
    public const string Email = "თქვენს მიერ შეყვანილი მაილი არ არის სწორი ";
    public const string Amount = "შეიტანე სწორი რიცხვი ";
}
