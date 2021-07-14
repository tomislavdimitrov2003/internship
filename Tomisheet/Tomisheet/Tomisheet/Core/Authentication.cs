using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Tomisheet.Models.UserModels;

namespace Tomisheet.Core
{
    public static class Authentication
    {
        public static void Login() 
        {
            
            string input = IO.ReadLine();
            string[] args = input.Split();
            string a;
            //Console.WriteLine(input);
            if (PasswordIsValid(args[0], args[1]))
            {
                User user = Database.Users.Where(x => x.Value.Name == args[0]).FirstOrDefault().Value;
                a = user.Name;

                Engine.Run(user);
            }
            else 
            {
                throw (new Exception("Wrong Password"));
            }
            Console.WriteLine(a);
        }

        public static string HashPassword(string password) 
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            string savedPasswordHash = Convert.ToBase64String(hashBytes);

            return savedPasswordHash;
        }

        public static bool PasswordIsValid(string name, string password)
        {
            User user = Database.Users.Where(x => x.Value.Name == name).FirstOrDefault().Value;
            string savedPasswordHash = user.Password;
            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            bool isValid = true;
            for (int i = 0; i < 20; i++) 
            { 
                if (hashBytes[i + 16] != hash[i])
                {
                    isValid = false;
                }
            }

            return isValid;
        }
    }
}
