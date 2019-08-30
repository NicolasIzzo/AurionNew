using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//igual ao changevisibility do login, mas com 2 inputfield (senha e confirmar senha)
public class ChangeVisibilityCadastro : MonoBehaviour
{
    public Button eye;
    public Sprite visibility;
    public Sprite visibility_off;
    public InputField senha;
    public InputField senha_confirm;
    private int cont = 0;

    void Start()
    {
        eye = eye.GetComponent<Button>();
    }

    public void changeButton()
    {
        cont++;
        if (cont % 2 != 0)
        {
            eye.transform.localScale = new Vector3(1, 0.7F, 1);
            eye.image.overrideSprite = visibility;
            senha.contentType = InputField.ContentType.Standard;
            senha_confirm.contentType = InputField.ContentType.Standard;
        }
        else
        {
            eye.transform.localScale = new Vector3(1, 1F, 1);
            eye.image.overrideSprite = visibility_off;
            senha.contentType = InputField.ContentType.Password;
            senha_confirm.contentType = InputField.ContentType.Password;
        }
        senha.ForceLabelUpdate();
        senha_confirm.ForceLabelUpdate();
    }
}
