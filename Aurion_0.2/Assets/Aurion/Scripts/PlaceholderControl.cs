using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlaceholderControl : MonoBehaviour
{
    // Start is called before the first frame update
    public TMPro.TMP_InputField txt;
    public TMPro.TMP_InputField txtsenha;
    void Start()
    {
        TMPro.TMP_InputField input = txt.GetComponent<TMPro.TMP_InputField>();
        txt.onSelect.AddListener(TaskOnSelect);
        txt.onDeselect.AddListener(TaskOnDeselect);
        txt.placeholder.GetComponent<TMPro.TMP_Text>().text = "Username";
        txt.text ="";

        TMPro.TMP_InputField input2 = txtsenha.GetComponent<TMPro.TMP_InputField>();
        txtsenha.onSelect.AddListener(TaskSenhaOnSelect);
        txtsenha.onDeselect.AddListener(TaskSenhaOnDeselect);
        txtsenha.onValueChanged.AddListener(TaskSenhaOnValueChanged);
        txtsenha.placeholder.GetComponent<TMPro.TMP_Text>().text = "Senha";
        txtsenha.text ="";
    }

    public void TaskOnSelect(string ae)
    {
          txt.placeholder.GetComponent<TMPro.TMP_Text>().text = "";
          txt.text ="";
    }
    
    public void TaskSenhaOnSelect(string ae)
    {
        txtsenha.placeholder.GetComponent<TMPro.TMP_Text>().text = "";
        txtsenha.text ="";
    }
    public void TaskSenhaOnValueChanged(string ae)
    {
        txtsenha.inputType = TMPro.TMP_InputField.InputType.Password;
    }

    public void TaskOnDeselect(string ae)
    {
        if(txt.text == "")
            txt.placeholder.GetComponent<TMPro.TMP_Text>().text = "Username";
    }

    public void TaskSenhaOnDeselect(string ae)
    {
        if(txtsenha.text == "")
        {
            txtsenha.inputType = TMPro.TMP_InputField.InputType.Standard;
            txtsenha.placeholder.GetComponent<TMPro.TMP_Text>().text = "Senha";
        }
    }
}
