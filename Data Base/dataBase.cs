﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;


namespace de_carga.Data_Base
{
    public class dataBase
    {
        public string connectionString = "Data Source=" + System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GilsonDB.db") + ";Version=3;";
        public bool ValidateUserCredentials(string name, string password)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Comando SQL para verificar se existe um registro com o nome e senha fornecidos
                string sql = "SELECT COUNT(*) FROM login WHERE name = @name AND password = @password";

                using (var command = new SQLiteCommand(sql, connection))
                {
                    // Adicionando parâmetros para evitar injeção de SQL
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@password", password);

                    // Executando o comando e obtendo o número de registros correspondentes
                    long count = (long)command.ExecuteScalar();

                    // Retorna true se o count for maior que 0, caso contrário, retorna false
                    return count > 0;
                }
            }
        }
        public void InsertUser(string name, string password)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                // Comando SQL ajustado para a tabela 'login'
                string sql = "INSERT INTO login (name, password) VALUES (@name, @password)";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    // Adicionando os parâmetros para o nome e a senha
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@password", password);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void InsertLampStatus(string date, string lamp1Status, string lamp2Status, string lamp3Status, string lamp4Status)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                // Comando SQL para inserir valores na tabela 'lampStatusRegist'
                string sql = "INSERT INTO lampStatusRegist (date, lamp1, lamp2, lamp3, lamp4) VALUES (@date, @lamp1, @lamp2, @lamp3, @lamp4)";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    // Adicionando os parâmetros para data e estado das lâmpadas
                    command.Parameters.AddWithValue("@date", date);
                    command.Parameters.AddWithValue("@lamp1", lamp1Status);
                    command.Parameters.AddWithValue("@lamp2", lamp2Status);
                    command.Parameters.AddWithValue("@lamp3", lamp3Status);
                    command.Parameters.AddWithValue("@lamp4", lamp4Status);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void InsertGateStatu(string date, string gateStatus, string userChange)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                // Comando SQL para inserir valores na tabela 'gateStatusLog'
                string sql = "INSERT INTO gateStatusLog (date, gateStatus, userOpenGate) VALUES (@date, @gateStatus, @userOpenGate)";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    // Adicionando os parâmetros para data, estado do portão e usuário
                    command.Parameters.AddWithValue("@date", date);
                    command.Parameters.AddWithValue("@gateStatus", gateStatus);
                    command.Parameters.AddWithValue("@userOpenGate", userChange);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void LoadLampStatusIntoDataGridView(DataGridView dataGridView)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Comando SQL para selecionar todos os registros da tabela 'lampStatusRegist'
                string sql = "SELECT * FROM lampStatusRegist";

                using (var command = new SQLiteCommand(sql, connection))
                {
                    using (var adapter = new SQLiteDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();

                        // Preenchendo o DataTable com os dados do banco de dados
                        adapter.Fill(dataTable);

                        // Definindo a fonte de dados do DataGridView
                        dataGridView.DataSource = dataTable;
                    }
                }

                connection.Close();
            }
        }

        public void LoadGateStatusIntoDataGridView(DataGridView dataGridView)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Comando SQL para selecionar todos os registros da tabela 'gateStatusLog'
                string sql = "SELECT * FROM gateStatusLog";

                using (var command = new SQLiteCommand(sql, connection))
                {
                    using (var adapter = new SQLiteDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();

                        // Preenchendo o DataTable com os dados do banco de dados
                        adapter.Fill(dataTable);

                        // Definindo a fonte de dados do DataGridView
                        dataGridView.DataSource = dataTable;
                    }
                }

                connection.Close();
            }
        }

    }
}