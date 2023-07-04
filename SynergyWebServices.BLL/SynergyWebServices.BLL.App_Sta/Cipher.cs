using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SynergyWebServices.BLL.App_Start;

public static class Cipher
{
	public static string passwordText = "Matrix$%15!123";

	public static string Encrypt(string plainText, string password)
	{
		if (plainText == null)
		{
			return null;
		}
		if (password == null)
		{
			password = string.Empty;
		}
		byte[] bytes = Encoding.UTF8.GetBytes(plainText);
		byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
		passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
		return Convert.ToBase64String(Encrypt(bytes, passwordBytes));
	}

	public static string Decrypt(string encryptedText, string password)
	{
		if (encryptedText == null)
		{
			return null;
		}
		if (password == null)
		{
			password = string.Empty;
		}
		byte[] bytesToBeDecrypted = Convert.FromBase64String(encryptedText);
		byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
		passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
		byte[] bytesDecrypted = Decrypt(bytesToBeDecrypted, passwordBytes);
		return Encoding.UTF8.GetString(bytesDecrypted);
	}

	private static byte[] Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
	{
		byte[] encryptedBytes = null;
		byte[] saltBytes = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
		using MemoryStream ms = new MemoryStream();
		using RijndaelManaged AES = new RijndaelManaged();
		Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
		AES.KeySize = 256;
		AES.BlockSize = 128;
		AES.Key = key.GetBytes(AES.KeySize / 8);
		AES.IV = key.GetBytes(AES.BlockSize / 8);
		AES.Mode = CipherMode.CBC;
		using (CryptoStream cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
		{
			cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
			cs.Close();
		}
		return ms.ToArray();
	}

	private static byte[] Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
	{
		byte[] decryptedBytes = null;
		byte[] saltBytes = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
		using MemoryStream ms = new MemoryStream();
		using RijndaelManaged AES = new RijndaelManaged();
		Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
		AES.KeySize = 256;
		AES.BlockSize = 128;
		AES.Key = key.GetBytes(AES.KeySize / 8);
		AES.IV = key.GetBytes(AES.BlockSize / 8);
		AES.Mode = CipherMode.CBC;
		using (CryptoStream cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
		{
			cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
			cs.Close();
		}
		return ms.ToArray();
	}
}
