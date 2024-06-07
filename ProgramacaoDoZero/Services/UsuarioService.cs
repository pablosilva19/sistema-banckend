using ProgramacaoDoZero.Common;
using ProgramacaoDoZero.Entities;
using ProgramacaoDoZero.Models;
using ProgramacaoDoZero.Repositories;
using System;

namespace ProgramacaoDoZero.Services
{
    public class UsuarioService
    {
        private string  _connectionString;
        public UsuarioService(string connectionString)
        {
            _connectionString = connectionString;
        }
        public LoginResult Login(string email, string senha)
        {
            var result = new LoginResult();

            var usuarioRepository = new UsuarioRepositoy(_connectionString);

            var usuario =  usuarioRepository.ObterUsuarioPorEmail(email);

            if (usuario != null)
            {
                //usuário existe
                if(usuario.Senha == senha)
                {
                    //senha válida
                    result.sucesso = true;
                    result.usuarioGuid = usuario.UsuarioGuid;
                }
                else
                {
                    //senha inválida
                    result.sucesso = false;
                    result.mensagem = "Usuario ou senha inválidos";
                }
            }
            else
            {
                //usuário não existe
                result.sucesso = false;
                result.mensagem = "Usuario ou senha invalidos";
            }

            return result;
        }

        public CadastroResult Cadastro(string nome, 
            string sobrenome,
            string telefone,
            string email, 
            string genero, 
            string senha)
        {
            var result = new CadastroResult();

            var usuarioRepository = new UsuarioRepositoy(_connectionString);

            var usuario =  usuarioRepository.ObterUsuarioPorEmail(email);

            if(usuario != null)
            {
                //usurio já existe
                result.sucesso = false;
                result.mensagem = "Usuário já existe no sistema";
            }
            else
            {
                // usuário não existe
                usuario = new Usuario();
                usuario.Nome = nome;
                usuario.Sobrenome = sobrenome;
                usuario.Telefone = telefone;
                usuario.Email = email;
                usuario.Genero = genero;
                usuario.Senha = senha;
                usuario.UsuarioGuid = Guid.NewGuid();

                var insertResult = usuarioRepository.Inserir(usuario);

                if(insertResult > 0)
                {
                    //inseriu com sucesso
                    result.sucesso = true;
                    result.usuarioGuid = usuario.UsuarioGuid;
                }
                else
                {
                    //erro ao inserir
                    result.sucesso = false;
                    result.mensagem = "Erro ao inserir usuário. Tente novamente";
                }
              
            }


            return result;
        }

        public EsqueceuSenhaResult EsqueceuSenha(string email)
        {
            var result = new EsqueceuSenhaResult();

            var usuario = new UsuarioRepositoy(_connectionString).ObterUsuarioPorEmail(email);

            

            if(usuario == null)
            {
                
               result.mensagem = "Usuario não existe para esse email";
            }
            else
            {
                var assunto = "Programção do Zero - Reciperação se Senha";

                var corpo = "Sua senha de acesso é: " + usuario.Senha;

                var emailSender = new EmailSender();

                emailSender.Enviar(assunto, corpo, usuario.Email);

                result.sucesso = true;

            }

          
            return result;
        }
        public Usuario ObterUsuario(Guid usuarioGuid)
        {
            var usuario = new UsuarioRepositoy(_connectionString).ObterPorGuid(usuarioGuid);

            return usuario;
        }

    }
    
}
