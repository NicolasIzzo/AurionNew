using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Data;
using Npgsql;

public class Conexao : MonoBehaviour
{
    //public static string conn;
    public static NpgsqlConnection cn = new NpgsqlConnection("Server=200.145.153.172;Port=5432;User Id=biosys;" +
            "Password=051217202228293235;Database=biosysdb;");
    public void Start()
    {
        /*conn = "Server=200.145.153.172;Port=5432;User Id=biosys;" +
            "Password=051217202228293235;Database=biosysdb;";*/

        //conn.Open();

        //NpgsqlCommand command = new NpgsqlCommand("insert into tes values(1, 1)", conn);
        //Int32 rowsaffected;
        
        
    }
    public static void conectar()
    {
        if (cn == null)
            cn = new NpgsqlConnection("Server=200.145.153.172;Port=5432;User ID=biosys;" +
            "Password=051217202228293235;Database=biosysdb;");
        /*if(!Convert.ToBoolean(cn.State))
        {*/
            
            cn.Open();
            
            Debug.Log(cn);

    }

    public static void executar(string sql)
    {
        conectar();
        try
        {            
            NpgsqlCommand cmd = new NpgsqlCommand(sql, cn);
            cmd.ExecuteNonQuery();
        }
        catch (NpgsqlException ex)
        {
            Debug.Log(ex.Message);//throw new ApplicationException(ex.Message);
        }
        desconectar();
    }
    public static void desconectar()
    {
        cn.Close(); // fecha a conexão com o banco de dados
        cn.Dispose(); // libera os recursos utilizados
        cn = null;
    }
    public static bool Email(string sql_email)
    {
        desconectar();
        Debug.Log("Estou em Email");
        conectar();
        NpgsqlCommand c = new NpgsqlCommand();
        c.Connection = cn;
        Debug.Log(c);
        c.CommandText = sql_email;
        NpgsqlDataReader d = c.ExecuteReader();

        if (d.Read())
        {
            Debug.Log("email ja existe");
            desconectar();
            return false;
        }
        else
        {
            //EMAIL NÃO EXISTE
            Debug.Log("blibli");
            desconectar();
            return true;
        }
    }

    public static string Fk(string sql)
    {
        string aux_id;
        desconectar();
        Debug.Log("Vou tentar pegar a chave estrangeira");
        conectar();
        NpgsqlCommand cmd = new NpgsqlCommand(sql, cn);
        //cmd.Connection = cn;
        Debug.Log(cmd);
        //cmd.CommandText = sql;
        NpgsqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            aux_id = dr["id"].ToString();
            Debug.Log(aux_id);
            return aux_id;
        }
        else
        {
            Debug.Log("Nao deu");
            return "ERRO";
        }
        
    }

}