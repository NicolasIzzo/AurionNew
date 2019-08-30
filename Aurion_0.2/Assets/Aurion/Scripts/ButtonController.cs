using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public static int id_usuario = 0;
  

    [Header("OBJECTS")]
	public Button myButton;
    public TMPro.TMP_InputField txtnome;
    public TMPro.TMP_InputField txtsenha;
    public TMPro.TMP_Text lblnome;
    public TMPro.TMP_Text lblsenha;
    public TMPro.TMP_Text lblpontuacao;
    public TMPro.TMP_Text lblresp;
    public GameObject newPanel;
    public GameObject oldPanel;

    public SQLite banco;
    public SliderManager sliderManager;
    public PanelController panelController;
    


    void Start()
    {
        
        Button btn = myButton.GetComponent<Button>();
        
        if(myButton.name =="btnLogin")
            myButton.onClick.AddListener(Login);
        if(myButton.name =="btnCadastrar")
            myButton.onClick.AddListener(Cadastrar);
        if(myButton.name =="btnPerfil")
            myButton.onClick.AddListener(MostrarPerfil);
        if(myButton.name =="btnConfirmarAlteracao")
            myButton.onClick.AddListener(Alterar);
        if(myButton.name =="btnExit")
            myButton.onClick.AddListener(Sair);
        if(myButton.name == "btnEditarPerfil")
            myButton.onClick.AddListener(MostrarAlterarPerfil);


    
        
    }

    // Update is called once per frame
    void Login()
    {
        
        id_usuario = banco.Login(txtnome, txtsenha);
        if(id_usuario > 0)
        {
            newPanel.SetActive(true);
            oldPanel.SetActive(false);
        }
        else
        {
            sliderManager.CallPopup();
            Debug.Log("Erro no login, ButtonController");
        }
    }
    void Cadastrar()
    {
        id_usuario = banco.Inserir(txtnome, txtsenha);
        if(id_usuario > 0)
        {
            newPanel.SetActive(true);
            oldPanel.SetActive(false);
        }
        else
        {
            sliderManager.CallPopup();
            Debug.Log("Erro no cadastro, ButtonController");
        }
    }
    void MostrarPerfil()
    {
        newPanel.SetActive(true);
        oldPanel.SetActive(false);
        lblnome.text = banco.MostrarPerfil(id_usuario, 0);
        lblsenha.text = "Senha:" + banco.MostrarPerfil(id_usuario, 1);
        lblpontuacao.text = "Pontuacao: " + banco.MostrarPerfil(id_usuario, 2);
        //lblresp.text = banco.MostrarPerfil(id_usuario, "respondidas");
        lblresp.text = "Manutenção";
        
    }

    void Alterar()
    {
        if(txtnome.text != "" && txtsenha.text != "")
        {
            banco.AlterarUsuario(id_usuario, txtnome.text, txtsenha.text);
            sliderManager.CloseEditarPerfil();
        }
            
        
    }

    void Sair()
    {   
        id_usuario = 0;
       /*if (Input.GetKeyUp(KeyCode.Escape))
        {
             if (Application.platform == RuntimePlatform.Android)
             {
                 AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
                 activity.Call<bool>("moveTaskToBack", true);
             }
             else
             {
                 Application.Quit();
             }
         }*/
         txtsenha.text = "";
         txtsenha.inputType = TMPro.TMP_InputField.InputType.Standard;
         newPanel.SetActive(true);
         oldPanel.SetActive(false);
         
    }
    void MostrarAlterarPerfil()
    {
        
        sliderManager.CallEditarPerfil();
        txtnome.text = banco.MostrarPerfil(id_usuario, 0);
        txtsenha.text = banco.MostrarPerfil(id_usuario, 1);
    }

    /*void TrocarPaineis()
    {
        oldPanel.SetActive(false);
        
        newPanel.SetActive(true);
    } */
}
