using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Confirm_password : MonoBehaviour
{
   
    public InputField senha;
    public InputField senha_confirm;
    public static Text error_email;
    public static Text msg_erro;
    public Button continuar;
    public InputField usuario;
    public InputField passwd;
    //Login log = new Login();
    //seta o text senha_igual para false, ou seja, não aparece

    void Start()
    {
        
        /*error_email.text = "Email já existente";
        msg_erro.text = "Senhas não coincidem";
        error_email.gameObject.SetActive(false);
        msg_erro.gameObject.SetActive(false);
        Instantiate(error_email);
        Instantiate(msg_erro);*/
    }
    public void password()
    {

        //compara o text dos dois inputfield (senha/senha_confirm)
        if (senha.text == senha_confirm.text)
        {
            //caso entre na condição, a mensagem de erro é desativada
            msg_erro.gameObject.SetActive(false);
            continuar.enabled = true;
        }
        else if (senha.text != senha_confirm.text)
        {
            Debug.Log("A senha n ta certa");
            //caso não entre, aparece o text senha_igual ("as senhas não coincidem")
            msg_erro.gameObject.SetActive(true);
            continuar.enabled = false;
        }
    }
    public static void conf_email()
    {
        Cadastrar cad = new Cadastrar();
        Conexao.desconectar();
        
        if (Conexao.Email(cad.sql_email) == false)
        {
            
            error_email.gameObject.SetActive(true);
        }
        else
            error_email.gameObject.SetActive(false);
        

    }

}
