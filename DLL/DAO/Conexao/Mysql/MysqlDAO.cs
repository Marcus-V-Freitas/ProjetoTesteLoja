using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MySql.Data.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Infraestructure;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;


namespace DLL.DAO.Conexao.Mysql
{
    public class MysqlDAO:AbstractDatabase
    {
        //String de Conexão que recebe os dados de DataDal e se torna de somente leitura
        private static readonly MySqlConnection Connection = new MySqlConnection($"Server={DataDal.Server};Database={DataDal.Database};Uid={DataDal.User};Pwd={DataDal.Passaword};Sslmode=none;Charset=utf8;convert zero datetime=True");
        private static readonly MysqlDAO _instance=new MysqlDAO();

        //Singleton seguro para threads
        public static MysqlDAO Instance()
        {
            try
            {
                Connection.Open();
            }catch(MySqlException e)
            {
                Log.Log.Registrar(e.Message);
            }catch(InvalidOperationException e)
            {
                Log.Log.Registrar(e.Message);
            }
            catch(Exception e)
            {
                Log.Log.Registrar(e.Message);
            }

            return _instance;
        }


        private MysqlDAO() { }

        //Espera um parametro do tipo string contendo um comando SQL do tipo SELECT
        public override DataTable RetDataTable(string sql)
        {
            DataTable data = new DataTable();
            MySqlCommand command = new MySqlCommand(sql, Connection);
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            da.Fill(data);
            return data;
        }

        //Comando utilizado para recuperar dados de forma segura (evitando sql injection)
        public DataTable RetDataTable(MySqlCommand command)
        {
            DataTable data = new DataTable();
            command.Connection = Connection;
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            da.Fill(data);
            return data;
        }

        //Espera um parametro do tipo string contendo um comando SQL do tipo INSERT, UPDATE, DELETE
        public override void ExecutarComandoSQL(string sql)
        {
            
            MySqlCommand command = new MySqlCommand(sql, Connection);
            
            command.ExecuteNonQuery();

        }

        //Espera vários parametros do tipo string para que só sejam aceitos casos todos sejam realizados 
        public override void ExecutarComandoSQLTransaction(string[] paramsSQL)
        {
            MySqlTransaction tn = Connection.BeginTransaction(IsolationLevel.Serializable);
            try
            {
                MySqlCommand command;
                for (int i = 0; i < paramsSQL.Length; i++)
                {
                    command = new MySqlCommand(paramsSQL[i], Connection);
                    command.Transaction = tn;
                    command.ExecuteNonQuery();
                }

                tn.Commit();
            }
            catch (Exception ex)
            {
                tn.Rollback();
                Console.WriteLine(ex.Message);
            }
        }

        //Fecha a Conexão
        public override void FecharConexaoSQL()
        {
            Connection.Close();
        }
    }
}
