﻿using MySql.Data.MySqlClient;
using ProgramacaoDoZero.Entities;
using System;

namespace ProgramacaoDoZero.Repositories
{
    public class UsuarioRepositoy
    {
        private string _connectionString;

        public UsuarioRepositoy(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Inserir(Usuario usuario)
        {
            var cnn = new MySqlConnection(_connectionString);

            var cmd = new MySqlCommand();
            cmd.Connection = cnn;

            cmd.CommandText = @"INSERT INTO usuario
                (nome, sobrenome, email, telefone, genero, senha, usuarioGuid) 
                VALUES 
                (@nome, @sobrenome, @email,@telefone, @genero, @senha, @usuarioGuid)";
          
            cmd.Parameters.AddWithValue("nome", usuario.Nome);
            cmd.Parameters.AddWithValue("sobrenome", usuario.Sobrenome);
            cmd.Parameters.AddWithValue("telefone", usuario.Telefone);
            cmd.Parameters.AddWithValue("email", usuario.Email);
            cmd.Parameters.AddWithValue("genero", usuario.Genero);
            cmd.Parameters.AddWithValue("senha", usuario.Senha);
            cmd.Parameters.AddWithValue("usuarioGuid", usuario.UsuarioGuid);


            cnn.Open();

            var affectedRows = cmd.ExecuteNonQuery();

            cnn.Close();

            return affectedRows;
        }

        public Usuario ObterUsuarioPorEmail(string email)
        {

            Usuario usuario = null;
            MySqlConnection cnn = new MySqlConnection(_connectionString);

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = cnn;

            cmd.CommandText = "SELECT * FROM usuario WHERE email = @email";

            cmd.Parameters.AddWithValue("email", email);

            cnn.Open();

            var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                usuario = new Usuario();
                usuario.Nome = reader["nome"].ToString();
                usuario.Sobrenome = reader["sobrenome"].ToString();
                usuario.Email = reader["email"].ToString();
                usuario.Telefone = reader["telefone"].ToString();
                usuario.Genero = reader["genero"].ToString();
                usuario.Senha = reader["senha"].ToString();

                var usuarioGuid = reader["usuarioGuid"].ToString();

                usuario.UsuarioGuid = new Guid(usuarioGuid);
                
            }

            cnn.Close();

            return usuario;
        }
        public Usuario ObterPorGuid(Guid usuarioGuid)
        {
            Usuario usuario = null;

            var cnn = new MySqlConnection(_connectionString);

            var cmd = new MySqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "SELECT * FROM usuario WHERE usuarioGuid = @usuarioGuid";

            cmd.Parameters.AddWithValue("usuarioGuid", usuarioGuid);
           
            cnn.Open();

            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                usuario = new Usuario();
                usuario.Nome = reader["nome"].ToString();
                usuario.Sobrenome = reader["sobrenome"].ToString();
                usuario.Email = reader["email"].ToString();
                usuario.Telefone = reader["telefone"].ToString();
                usuario.Genero = reader["genero"].ToString();
                usuario.Senha = reader["senha"].ToString();

                var guid = reader["usuarioGuid"].ToString();

                usuario.UsuarioGuid = new Guid(guid);
            }


            cnn.Close();
            return usuario;


        }
    }
}
