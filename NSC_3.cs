using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main()
    {
        string username = "Admin";
        string password = "Awdx!@#$%xdwa";

        string hashedPassword = HashPassword(password);

        DisplayUserInfo(username, hashedPassword);
    }

    static string HashPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return ByteArrayToHexString(hashedBytes);
        }
    }

    static string ByteArrayToHexString(byte[] byteArray)
    {
        StringBuilder builder = new StringBuilder(byteArray.Length * 2);
        foreach (byte b in byteArray)
        {
            builder.Append(b.ToString("x2"));
        }
        return builder.ToString();
    }

    static void DisplayUserInfo(string username, string hashedPassword)
    {
        Console.WriteLine($"Username: {username}");
        Console.WriteLine($"Hashed Password (SHA-256): {hashedPassword}");
    }
}
