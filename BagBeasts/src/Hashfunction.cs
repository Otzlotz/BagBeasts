using System.Security.Cryptography;
using System.Text;
namespace BagBeasts.src.Hashfunction;

public static class Hashfunction{
    public static string Hash(string input)
    {
        input += "DennisStinkt";
        var inputBytes = Encoding.UTF8.GetBytes(input);
        var inputHash = SHA256.HashData(inputBytes);
        return Convert.ToHexString(inputHash);
    }
}