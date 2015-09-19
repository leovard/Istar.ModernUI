using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;

namespace IstarWindows.Code
{
    public class PasswordDecryptor : SqlMembershipProvider
    {
        public static string Protect(string password, string purpose)
        {
            var unprotectedBytes = Encoding.UTF8.GetBytes(password);
            var protectedBytes = MachineKey.Protect(unprotectedBytes, purpose);
            password = Convert.ToBase64String(protectedBytes);
            return password;
        }

        public static string Unprotect(string password, string purpose)
        {
            var protectedBytes = Convert.FromBase64String(password);
            var unprotectedBytes = MachineKey.Unprotect(protectedBytes, purpose);
            if (unprotectedBytes != null) password = Encoding.UTF8.GetString(unprotectedBytes);
            return password;
        }

        public static string Encrypt(string password, string purpose)
        {
            var clearBytes = Encoding.Unicode.GetBytes(password);
            using (var encryptor = Aes.Create())
            {
                var pdb = new Rfc2898DeriveBytes(purpose, new byte[] { 0x49, 0x76, 0x61, 0x6E, 0x20, 0x4D, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                if (encryptor == null) return password;
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    password = Convert.ToBase64String(ms.ToArray());
                }
            }
            return password;
        }

        public static string Decrypt(string password, string purpose)
        {
            var cipherBytes = Convert.FromBase64String(password);
            using (var encryptor = Aes.Create())
            {
                var pdb = new Rfc2898DeriveBytes(purpose, new byte[] { 0x49, 0x76, 0x61, 0x6E, 0x20, 0x4D, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                if (encryptor == null) return password;
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    password = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return password;
        }

    }
}
