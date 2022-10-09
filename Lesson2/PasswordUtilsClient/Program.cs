﻿using CardStorageService.Utils;

namespace PasswordUtilsClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
			var result = PasswordUtils.CreatePasswordHash("12345");
			//var result = PasswordUtils.CreatePasswordHash("");
			Console.WriteLine(result.passwordSalt);
            Console.WriteLine(result.passwordHash);
            Console.ReadKey(true);
        }
    }
}