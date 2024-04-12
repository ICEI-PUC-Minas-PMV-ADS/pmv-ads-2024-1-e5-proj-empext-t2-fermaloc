using System.Globalization;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;

namespace Fermaloc.Domain.Validations;

public class DomainExceptionValidation : Exception
{
    public DomainExceptionValidation(string? message) : base(message)
    {
    }

    public static void ValidateString(string stringValue, int maxSize, int minSize, string propName){
        if (string.IsNullOrEmpty(stringValue)){
            throw new DomainExceptionValidation($"{propName} é nulo");
        }
        if(stringValue.Length > maxSize || stringValue.Length < minSize){
            throw new DomainExceptionValidation($"{propName} tem tamanho inválido");
        }
    }

    public static void ValidateGuid(Guid guid){
        string guidString = guid.ToString();
        if(!Guid.TryParse(guidString, out var value)){
            throw new DomainExceptionValidation("Id invalida");
        }
    }

    public static void ValidateInt(int value, string propName)
    {
        if(value < 0){
            throw new DomainExceptionValidation($"{propName} inválido");
        }
    }

    public static void ValidatePassword(string password){

        bool hasUppercase = password.Any(char.IsUpper);
        bool hasLowercase = password.Any(char.IsLower);
        bool hasNumber = password.Any(char.IsDigit);
        bool haveSpecialCharacter = password.Any(character => !char.IsLetterOrDigit(character));

        if(password.Length < 8 || password.Length > 100 || !hasUppercase || !hasLowercase || !hasNumber || !haveSpecialCharacter){
            throw new DomainExceptionValidation($"Senha invalida");
        }
    }

    public static void ValidateEmail(string email){
            try
            {
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper, RegexOptions.None, TimeSpan.FromMilliseconds(200));

                static string DomainMapper(Match match)
                {
                    var idn = new IdnMapping();
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                throw new DomainExceptionValidation($"Email inválido");
            }
            catch (ArgumentException e)
            {
                throw new DomainExceptionValidation($"Email inválido");
            }

            try
            {
                bool result = Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
                if(!result)
                throw new DomainExceptionValidation($"Email inválido");
            }
            catch (RegexMatchTimeoutException)
            {
                throw new DomainExceptionValidation($"Email inválido");
            }
        }

            public static void ValidateByte(int maxSize, string propName, byte[] value)
    {
        if (value.Length > maxSize)
        {
            throw new DomainExceptionValidation($"{propName} excede o tamanho máximo de {maxSize} bytes.");
        }
    }

    public static void ValidateRequiredValue(bool isNull, string propName)
    {
        if (isNull){
            throw new DomainExceptionValidation($"{propName} tem valor nulo");
        }
    }
}

