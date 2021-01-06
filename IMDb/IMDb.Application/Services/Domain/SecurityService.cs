using IMDb.Application.Interfaces.Services.Domain;
using System;
using System.Security.Cryptography;
using System.Text;

namespace IMDb.Application.Services.Domain
{
    public class SecurityService: ISecurityService
    {
        public string Encrypt(string value, string salt)
        {
            byte[] byteRepresentation = Encoding.UTF8.GetBytes(value + salt);

            byte[] hashedTextInBytes = null;
            SHA1CryptoServiceProvider mySHA1 = new SHA1CryptoServiceProvider();
            hashedTextInBytes = mySHA1.ComputeHash(byteRepresentation);
            return Convert.ToBase64String(hashedTextInBytes);
        }
    }
}
