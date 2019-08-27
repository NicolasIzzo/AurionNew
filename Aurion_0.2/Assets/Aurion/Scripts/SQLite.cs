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
    public TMPro.TMP_InputField txtnome, txtsenha;
    public TMPro.TMP_Text lblnome; //colocar depois lblsenha e lblemail
    string nome, senha;
    public static int idusuario;
    
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

    void Start()
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

    public void Inserir()
    {
        try
        {

            dbConnection = new SqliteConnection(connectionString);
            dbConnection.Open();
            Debug.Log("Stablishing connection to: " + connectionString);
            nome = txtnome.text.ToString();
            senha = txtsenha.text.ToString();
            dbCmd = dbConnection.CreateCommand();
            sqlQuery = String.Format("INSERT INTO usuario(name_user, senha_user) VALUES(\"{0}\",\"{1}\") ", nome, senha);

            dbCmd.CommandText = sqlQuery;
            dbCmd.ExecuteScalar();
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
        
    }

    public void selectNome()
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
    }

    public void Login()
    {
        try
        {

            dbConnection = new SqliteConnection(connectionString);
            dbConnection.Open();
            Debug.Log("Stablishing connection to: " + connectionString);
            nome = txtnome.text.ToString();
            senha = txtsenha.text.ToString();
            dbCmd = dbConnection.CreateCommand();
            sqlQuery = String.Format("SELECT id_user FROM usuario WHERE name_user = \"{0}\" AND senha_user = \"{1}\" ", nome,senha);

            dbCmd.CommandText = sqlQuery;
            
            dr = dbCmd.ExecuteReader();
            if(dr.Read())
            {
                Debug.Log("As informações conferem");
                Debug.Log(dr.GetInt32(0));
            }
                idusuario = dr.GetInt32(0);
                

            
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
    }

    public void MostrarPerfil()
    {
        try
        {
            
            dbConnection = new SqliteConnection(connectionString);
            dbConnection.Open();
            Debug.Log("Stablishing connection to: " + connectionString);
            dbCmd = dbConnection.CreateCommand();
            sqlQuery = String.Format("SELECT name_user FROM usuario WHERE id_user = \"{0}\"", idusuario);

            dbCmd.CommandText = sqlQuery;

            dr = dbCmd.ExecuteReader();
            while(dr.Read())
            {
                lblnome.text = dr.GetString(0);
                //lblsenha.text = dr.GetString(1);
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
    }

    public void Delete()//Exclusão FÍSICA
    {
        try
        {

            dbConnection = new SqliteConnection(connectionString);
            dbConnection.Open();
            Debug.Log("Stablishing connection to: " + connectionString);
            nome = "Teemooo";
            senha = "123";
            dbCmd = dbConnection.CreateCommand();
            sqlQuery = String.Format("DELETE FROM usuario WHERE id_user = \"{0}\"", idusuario);

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

    public void UpdateUser()
    {
        int pontos = 100;
        int id = 2;
        nome = "Jacinto";
        senha = "Bebas";

        try
        {

            dbConnection = new SqliteConnection(connectionString);
            dbConnection.Open();
            Debug.Log("Stablishing connection to: " + connectionString);
           
            dbCmd = dbConnection.CreateCommand();
            sqlQuery = String.Format("UPDATE usuario set name_user = \"{1}\", senha_user = \"{2}\", pontuacao = \"{3}\" WHERE id_user = \"{0}\"", id, nome, senha, pontos);

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