using System.Security.Cryptography;
using System.Text;
namespace Common.Application.SecurityUtil;

public static class HashExtensions
{
    public static string ToMd5(this string input)
    {
        var inputBytes = Encoding.ASCII.GetBytes(input);
        var hashBytes = MD5.HashData(inputBytes);
        return ConvertToHex(hashBytes);
    }

    public static string ToSha1(this string input)
    {
        var inputBytes = Encoding.ASCII.GetBytes(input);
        var hashBytes = SHA1.HashData(inputBytes);
        return ConvertToHex(hashBytes);
    }

    public static string ToSha256(this string input)
    {
        var inputBytes = Encoding.ASCII.GetBytes(input);
        var hashBytes = SHA256.HashData(inputBytes);
        return ConvertToHex(hashBytes);
    }

    public static string ToSha384(this string input)
    {
        var inputBytes = Encoding.ASCII.GetBytes(input);
        var hashBytes = SHA384.HashData(inputBytes);
        return ConvertToHex(hashBytes);
    }

    public static string ToSha512(this string input)
    {
        var inputBytes = Encoding.ASCII.GetBytes(input);
        var hashBytes = SHA512.HashData(inputBytes);
        return ConvertToHex(hashBytes);
    }

    private static string ConvertToHex(byte[] hashBytes)
    {
        var sb = new StringBuilder();
        foreach (var b in hashBytes)
        {
            sb.Append(b.ToString("X2"));
        }
        return sb.ToString();
    }
}