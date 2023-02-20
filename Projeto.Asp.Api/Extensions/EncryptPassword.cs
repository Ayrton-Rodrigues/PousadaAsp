using Projeto.Asp.Api.PousadaAsp.Domain.Services;
using Projeto.Asp.Api.PousadaAsp.Domain.ViewModels;
using System;
using System.Security.Cryptography;

namespace Projeto.Asp.Api.Extensions
{
    public static class EncryptPassword
    {
        public static (byte[] hash, byte[] salt) CreateHashAndSalt(string password)
        {
            const int saltSize = 16; // Define o tamanho do salt em bytes
            const int hashSize = 32; // Define o tamanho do hash em bytes
            const int iterations = 10000; // Define o número de iterações a serem usadas na derivação de chave

            // Gera um salt aleatório
            byte[] salt = new byte[saltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // Deriva uma chave usando a senha e o salt
            var encrypt = new Rfc2898DeriveBytes(password, salt, iterations);
            byte[] hash = encrypt.GetBytes(hashSize);

            return (hash, salt);

        }
    }
}
