using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.DAO.Conexao
{
    public static class DataDal
    {
        //Arquivo de caminho para os dados da string de conexão
        private static readonly string path = "stringConnection";       
        public static string Server { get; set; }
        public static string Database { get; set; }
        public static string User { get; set; }
        public static string Passaword { get; set; }

        public static void StringConexao()
        {

            if (!File.Exists(path))
            {
                StreamWriter sw = File.CreateText(path);
               //Pode-se preencher com dados caso deseje ter backup na linguagem de programação
            }

            StreamReader sr = new StreamReader(path);

            List<string> sb = new List<string>();

            string dados = " ";

            while ((dados = sr.ReadLine()) != null)
            {
                sb.Add(dados);
            }

            //Inicializa propriedades com os valores obtidos do arquivo
            Server = sb[0].ToString();
            Database = sb[1].ToString();
            User = sb[2].ToString();
            Passaword = sb[3].ToString();
            sr.Close();
        }
    }
}
