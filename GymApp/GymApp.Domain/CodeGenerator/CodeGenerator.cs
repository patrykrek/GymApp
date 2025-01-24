using GymApp.GymApp.Application.Services.Interfaces;
using System.Security.Cryptography;

namespace GymApp.GymApp.Domain.CodeGenerator
{
    public static class CodeGenerator
    {
        public static int GenerateSixDigitsCode()
        {
            byte[] randomBytes = new byte[4]; // tworze tablice byte

            using (var rnd = RandomNumberGenerator.Create()) // generuje mi losowe bajty
            {
                rnd.GetBytes(randomBytes); 
            }

            int randomInt = BitConverter.ToInt32(randomBytes, 0); // konwertuje byte w liczbe

            int generatedCode = Math.Abs(randomInt % 900000) + 100000; // dzieki temu liczba jest 6 cyfrowa

            return generatedCode;
        }
    }
}
