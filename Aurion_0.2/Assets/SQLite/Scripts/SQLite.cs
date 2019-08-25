//References
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Mono.Data.Sqlite;
using System;
using System.Data;
using System.IO;
using UnityEngine.UI;

public class SQLite : MonoBehaviour
{
    public TMPro.TMP_InputField txtnome, txtsenha;
    public TMPro.TMP_Text lblnome; //colocar depois lblsenha e lblemail
    string nome, senha;
    public static int idusuario;
    private static string connectionString, sqlQuery;
    //private static IDbConnection connection;

    private static SqliteConnection connection;
    
    private static SqliteCommand command;

    private static SqliteDataReader reader;
    SqliteDataReader dr;
    SqliteConnection dbConnection;
    string DatabaseName = "BiosysDB.s3db";


    public void Desconectar()
    {
        connection.Close();
    }

    public void Inserir()
    {

        string DatabaseName = "BiosysDB.s3db";
        string filepath = Application.dataPath + "/" + DatabaseName;
        if (!File.Exists(filepath))
        {
            // If not found on android will create Tables and database
            Debug.LogWarning("File \"" + filepath + "\" does not exist. Attempting to create from \"" +
                             Application.dataPath + "!/assets/BiosysDB");
            // UNITY_ANDROID
            WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/BiosysDB.s3db");
            while (!loadDB.isDone) { }
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDB.bytes);
        }


        connectionString = "URI=file:" + filepath;

        try
        {

            dbConnection = new SqliteConnection(connectionString);
            dbConnection.Open();
            Debug.Log("Stablishing connection to: " + connectionString);
            nome = txtnome.text.ToString();
            senha = txtsenha.text.ToString();
            SqliteCommand dbCmd = dbConnection.CreateCommand();
            string SQL = String.Format("INSERT INTO usuario(name_user, senha_user) VALUES(\"{0}\",\"{1}\") ", nome, senha);

            dbCmd.CommandText = SQL;
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
        string DatabaseName = "BiosysDB.s3db";
        string filepath = Application.dataPath + "/" + DatabaseName;
     

        if (!File.Exists(filepath))
        {
            // If not found on android will create Tables and database
            Debug.LogWarning("File \"" + filepath + "\" does not exist. Attempting to create from \"" +
                             Application.dataPath + "!/assets/BiosysDB");
            // UNITY_ANDROID
            WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/BiosysDB.s3db");
            while (!loadDB.isDone) { }
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDB.bytes);
        }

        connectionString = "URI=file:" + filepath;
        
        try
        {

            dbConnection = new SqliteConnection(connectionString);
            dbConnection.Open();
            Debug.Log("Stablishing connection to: " + connectionString);
            SqliteCommand dbCmd = dbConnection.CreateCommand();
            string SQL = "SELECT * FROM usuario";

            dbCmd.CommandText = SQL;

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
        string DatabaseName = "BiosysDB.s3db";
        string filepath = Application.dataPath + "/" + DatabaseName;
        

        if (!File.Exists(filepath))
        {
            // If not found on android will create Tables and database
            Debug.LogWarning("File \"" + filepath + "\" does not exist. Attempting to create from \"" +
                             Application.dataPath + "!/assets/BiosysDB");
            // UNITY_ANDROID
            WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/BiosysDB.s3db");
            while (!loadDB.isDone) { }
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDB.bytes);
        }

        connectionString = "URI=file:" + filepath;
        
        try
        {

            dbConnection = new SqliteConnection(connectionString);
            dbConnection.Open();
            Debug.Log("Stablishing connection to: " + connectionString);
            nome = txtnome.text.ToString();
            senha = txtsenha.text.ToString();
            SqliteCommand dbCmd = dbConnection.CreateCommand();
            string SQL = String.Format("SELECT id_user FROM usuario WHERE name_user = \"{0}\" AND senha_user = \"{1}\" ", nome,senha);

            dbCmd.CommandText = SQL;
            
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
        }
    }

    public void MostrarPerfil()
    {
        string DatabaseName = "BiosysDB.s3db";
        string filepath = Application.dataPath + "/" + DatabaseName;
        //Debug.Log("O id setado ="+idusuario);
        //idusuario = 4;

        if (!File.Exists(filepath))
        {
            // If not found on android will create Tables and database
            Debug.LogWarning("File \"" + filepath + "\" does not exist. Attempting to create from \"" +
                             Application.dataPath + "!/assets/BiosysDB");
            // UNITY_ANDROID
            WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/BiosysDB.s3db");
            while (!loadDB.isDone) { }
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDB.bytes);
        }

        connectionString = "URI=file:" + filepath;
        
        try
        {
            
            dbConnection = new SqliteConnection(connectionString);
            dbConnection.Open();
            Debug.Log("Stablishing connection to: " + connectionString);
            SqliteCommand dbCmd = dbConnection.CreateCommand();
            string SQL = String.Format("SELECT name_user FROM usuario WHERE id_user = \"{0}\"", idusuario);

            dbCmd.CommandText = SQL;

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
        int id = 1;
        string DatabaseName = "BiosysDB.s3db";
        string filepath = Application.dataPath + "/" + DatabaseName;
        if (!File.Exists(filepath))
        {
            // If not found on android will create Tables and database
            Debug.LogWarning("File \"" + filepath + "\" does not exist. Attempting to create from \"" +
                             Application.dataPath + "!/assets/BiosysDB");
            // UNITY_ANDROID
            WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/BiosysDB.s3db");
            while (!loadDB.isDone) { }
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDB.bytes);
        }
        connectionString = "URI=file:" + filepath;

        try
        {

            dbConnection = new SqliteConnection(connectionString);
            dbConnection.Open();
            Debug.Log("Stablishing connection to: " + connectionString);
            nome = "Teemooo";
            senha = "123";
            SqliteCommand dbCmd = dbConnection.CreateCommand();
            string SQL = String.Format("DELETE FROM usuario WHERE id_user = \"{0}\"", id);

            dbCmd.CommandText = SQL;
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
        string DatabaseName = "BiosysDB.s3db";
        string filepath = Application.dataPath + "/" + DatabaseName;
        if (!File.Exists(filepath))
        {
            // If not found on android will create Tables and database
            Debug.LogWarning("File \"" + filepath + "\" does not exist. Attempting to create from \"" +
                             Application.dataPath + "!/assets/BiosysDB");
            // UNITY_ANDROID
            WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/BiosysDB.s3db");
            while (!loadDB.isDone) { }
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDB.bytes);
        }


        connectionString = "URI=file:" + filepath;

        try
        {

            dbConnection = new SqliteConnection(connectionString);
            dbConnection.Open();
            Debug.Log("Stablishing connection to: " + connectionString);
           
            SqliteCommand dbCmd = dbConnection.CreateCommand();
            string SQL = String.Format("UPDATE usuario set name_user = \"{1}\", senha_user = \"{2}\", pontuacao = \"{3}\" WHERE id_user = \"{0}\"", id, nome, senha, pontos);

            dbCmd.CommandText = SQL;
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