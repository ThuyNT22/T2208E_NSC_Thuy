using System;
using System.Security.Cryptography;
using System.Text;

public class AsymmetricEncryptionExample
{
    public static void Main()
    {
        using (RSA rsa = RSA.Create())
        {
            RSAParameters publicKey = rsa.ExportParameters(false); 
            RSAParameters privateKey = rsa.ExportParameters(true); 
            
            string originalData = "Nguyen Thanh Thuy";
            byte[] dataToEncrypt = Encoding.UTF8.GetBytes(originalData);

            byte[] encryptedData = EncryptData(dataToEncrypt, publicKey);

            byte[] decryptedData = DecryptData(encryptedData, privateKey);

            string decryptedString = Encoding.UTF8.GetString(decryptedData);

            Console.WriteLine("Original: " + originalData);
            Console.WriteLine("Encrypted: " + Convert.ToBase64String(encryptedData));
            Console.WriteLine("Decrypted: " + decryptedString);
        }
    }

    public static byte[] EncryptData(byte[] data, RSAParameters publicKey)
    {
        using (RSA rsa = RSA.Create())
        {
            rsa.ImportParameters(publicKey);
            return rsa.Encrypt(data, RSAEncryptionPadding.Pkcs1); 
        }
    }

    public static byte[] DecryptData(byte[] data, RSAParameters privateKey)
    {
        using (RSA rsa = RSA.Create())
        {
            rsa.ImportParameters(privateKey);
            return rsa.Decrypt(data, RSAEncryptionPadding.Pkcs1); 
        }
    }
}