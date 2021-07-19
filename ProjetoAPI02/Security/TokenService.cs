using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAPI02.Security
{
    public class TokenService
    {//ler a palavra secreta..
        private readonly TokenSettings _tokenSettings;

        //construtor para inicializar o atributo (injeção de dependencia)
        public TokenService(TokenSettings tokenSettings)
        {
            _tokenSettings = tokenSettings;
        }

        //método para gerar o TOKEN
        public string GenerateToken(string user, int expirationInHours)
        {
            //capturar a palavra secreta utilizada para criptografar o token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_tokenSettings.SecretKey);

            //definir o conteudo do token..
            var tokenDescription = new SecurityTokenDescriptor
            {
                //usuário para o qual estamos gerando o token..
                Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, user) }),

                //definindo o tempo de validade do token..
                Expires = DateTime.Now.AddHours(expirationInHours),

                //utilizando a palavra secreta para criptografar o TOKEN
                SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            //finalizar, gerar e retornar o token
            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);
        }
    }
}


