using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Destroyer_ice : MonoBehaviour
{
    public AssetBundle assetPong;
    private string[] scenePaths;

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collider = collision.collider.gameObject;
        //bool morte = true;
        Debug.Log("BOLINHA FOI PRO BREJO");
        Debug.Log("Quit");
        Debug.Log("PONTUAÇÃO:" + Bloco.pontos);
        //Show_point.MostraPontos(Bloco.pontos);
        GameObject.Destroy(collider);
        //SceneManager.LoadScene("scene");
        // Application.Quit();
        /*if(morte)
        {
            LoadPongLevel();
        }*/
        /*assetPong = AssetBundle.LoadFromFile("C:/Biosys/Aureon/AurionNew/Arkanoid/Arkanoid/Pong/Assets");
        scenePaths = assetPong.GetAllScenePaths();
        SceneManager.LoadScene(scenePaths[0], LoadSceneMode.Single);*/
    }
 
    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject.Destroy(collider.gameObject);
    }
    /*void LoadPongLevel()
    {
        SceneManager.LoadScene("scene");
    }*/
}
