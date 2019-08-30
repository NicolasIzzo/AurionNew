//References
using System;
using System.Data;
using System.IO;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Mono.Data.Sqlite;
public class SQLite : MonoBehaviour
{
    
    //private static IDbConnection connection;
    public static IDataReader dr;
   // SqliteDataReader dr;
    //SqliteConnection dbConnection;
//    string DatabaseName = "BiosysDB.s3db";
    string filepath;
    string sqlQuery;
    string connectionString;
    IDbConnection dbConnection;
    IDbCommand dbCmd;

    public void Start()
    {
        
        if (Application.platform != RuntimePlatform.Android) {
         
            filepath = Application.dataPath + "/StreamingAssets/" + "BiosysDB.s3db";
            
         } else {
        filepath = Application.persistentDataPath + "/" + "BiosysDB.s3db";
        
        if (!File.Exists(filepath) || new System.IO.FileInfo(filepath).Length == 0)
        {
            // If not found on android will create Tables and database
            Debug.LogWarning("File \"" + filepath + "\" does not exist. Attempting to create from \"" +
                             Application.dataPath + "!/assets/StreamingAssets/BiosysDB");
            // UNITY_ANDROID
            WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/BiosysDB.s3db");
            while (!loadDB.isDone) { }
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDB.bytes);
        }
    }

        connectionString = "URI=file:" + filepath;
    }

    public void Desconectar()
    {
        dbConnection.Close();
    }

    public int Inserir(TMPro.TMP_InputField txtnome, TMPro.TMP_InputField txtsenha)
    {
        int id_usuario = 0;
        try
        {

            dbConnection = new SqliteConnection(connectionString);
            dbConnection.Open();
            Debug.Log("Stablishing connection to: " + connectionString);
            string nome = txtnome.text.ToString();
            string senha = txtsenha.text.ToString();
            dbCmd = dbConnection.CreateCommand();
            sqlQuery = String.Format("INSERT INTO usuario(name_user, senha_user) VALUES(\"{0}\",\"{1}\") ", nome, senha);

            dbCmd.CommandText = sqlQuery;
            dbCmd.ExecuteScalar();

            id_usuario = Login(txtnome, txtsenha);
        }
        catch(Exception e)
        {
            Debug.Log(e.Message);
            
        }
        finally
        {
            dbConnection.Close();
            dbConnection.Dispose();
        }
        
        return id_usuario;
        
    }

    /* public void selectNome()
    {
        try
        {

            dbConnection = new SqliteConnection(connectionString);
            dbConnection.Open();
            Debug.Log("Stablishing connection to: " + connectionString);
            dbCmd = dbConnection.CreateCommand();
            sqlQuery = "SELECT * FROM usuario";

            dbCmd.CommandText = sqlQuery;

            dr = dbCmd.ExecuteReader();
            while(dr.Read())
            {
                Debug.Log(dr.GetString(1));
            }

            
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);

        }
        finally
        {
            dbConnection.Close();
            dbConnection.Dispose();
            dr.Close();
        }
    }*/

    public int Login(TMPro.TMP_InputField txtnome, TMPro.TMP_InputField txtsenha)
    {
        int id_usuario = 0;
        try
        {

            dbConnection = new SqliteConnection(connectionString);
            dbConnection.Open();
            Debug.Log("Stablishing connection to: " + connectionString);
            string nome = txtnome.text.ToString();
            string senha = txtsenha.text.ToString();
            dbCmd = dbConnection.CreateCommand();
            sqlQuery = String.Format("SELECT id_user FROM usuario WHERE name_user = \"{0}\" AND senha_user = \"{1}\" ", nome,senha);

            dbCmd.CommandText = sqlQuery;
            
            dr = dbCmd.ExecuteReader();
            if(dr.Read())
            {
                Debug.Log("As informações conferem");
                Debug.Log(dr.GetInt32(0));
            }
                id_usuario = dr.GetInt32(0);
                

            
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);

        }
        finally
        {
            dbConnection.Close();
            dbConnection.Dispose();
            dr.Close();

            txtnome.text = "Username";
            txtsenha.text = "Senha";
        }
        return id_usuario;
    }

    public string MostrarPerfil(int id_usu, int dado)
    {
        string dado_return = "";
        string nome = "";
        string senha = "";
        string pontuacao = "";
        try
        {
            
            dbConnection = new SqliteConnection(connectionString);
            dbConnection.Open();
            Debug.Log("Stablishing connection to: " + connectionString);
            dbCmd = dbConnection.CreateCommand();
            sqlQuery = String.Format("SELECT name_user, senha_user, pontuacao FROM usuario WHERE id_user = \"{0}\" ", id_usu);

            dbCmd.CommandText = sqlQuery;
            dr = dbCmd.ExecuteReader();
            while(dr.Read())
            {
               Debug.Log("Entrou");
               nome = dr.GetString(0);
               senha = dr.GetString(1);
               pontuacao = dr.GetInt32(2).ToString();
            }

            
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);

        }
        finally
        {
            dbConnection.Close();
            dbConnection.Dispose();
            dr.Close();
        }

        switch(dado)
        {
            case 0:
                dado_return = nome;
                break;
            case 1:
                dado_return = senha;
                break;
            case 2:
                dado_return = pontuacao;
                break;
        }
        return dado_return;
    }
    

    

    public void Delete(int id_usu)//Exclusão FÍSICA
    {
        try
        {
            dbConnection = new SqliteConnection(connectionString);
            dbConnection.Open();
            Debug.Log("Stablishing connection to: " + connectionString);
            dbCmd = dbConnection.CreateCommand();
            sqlQuery = String.Format("DELETE FROM usuario WHERE id_user = \"{0}\"", id_usu);

            dbCmd.CommandText = sqlQuery;
            dbCmd.ExecuteScalar();
        }
        catch (Exception e){Debug.Log(e.Message);}
        finally
        {
            dbConnection.Close();
            dbConnection.Dispose();
        }
    }

    public void AlterarUsuario(int id_usu, string nome, string senha)
    {
        try
        {

            dbConnection = new SqliteConnection(connectionString);
            dbConnection.Open();
            Debug.Log("Stablishing connection to: " + connectionString);
           
            dbCmd = dbConnection.CreateCommand();
            sqlQuery = String.Format("UPDATE usuario set name_user = \"{1}\", senha_user = \"{2}\" WHERE id_user = \"{0}\"", id_usu, nome, senha);

            dbCmd.CommandText = sqlQuery;
            dbCmd.ExecuteScalar();
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);

        }
        finally
        {
            dbConnection.Close();
            dbConnection.Dispose();
        }

    }

}