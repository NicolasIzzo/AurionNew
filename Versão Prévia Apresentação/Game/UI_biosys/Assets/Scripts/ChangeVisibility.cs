using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//diz ao código q precisa de um botão para o script funcionar

public class ChangeVisibility : MonoBehaviour
{
    //criação dos atributos de classe (objetos q serão trabalhos e modificados)

    public Button eye;
    public Sprite visibility;
    public Sprite visibility_off;
    public InputField senha;
    private int cont = 0;

    //ao iniciar o script seleciona o botão q é chamado pelo unity
    void Start()
    {
        eye = eye.GetComponent<Button>();
    }

    public void changeButton()
    {
        //a cada vez que for clicado o botão, é adicionado 1 a variavel cont
        cont++;

        //caso cont % 2 dê diferente de 0, entra no if
        if (cont % 2 != 0)
        {
            //muda a escala utilizada no objeto eye (btnVisibility)
            //tive q fazer isso pq as imagens, quando na mesma proporção, ficam em tamanhos diferentes --> vulgo improvisação
            eye.transform.localScale = new Vector3(1, 0.7F, 1);

            //muda o Sprite (imagem) do botão eye
            eye.image.overrideSprite = visibility;

            //muda o tipo de entrada do campo de digitação da senha
            senha.contentType = InputField.ContentType.Standard;
            //Standard = aceita qualquer entrada
        }
        else
        {
            //volta o botão e o campo de senha para o padrão
            eye.transform.localScale = new Vector3(1, 1F, 1);
            eye.image.overrideSprite = visibility_off;
            senha.contentType = InputField.ContentType.Password;
            //Password = aceita qualquer entrada, porém são substituídos por * apenas visualmente
        }
        //força o campo de senha a atualizar, para modificar o ContentType --> se quiser entender melhor, exclua a linha abaixo e teste
        senha.ForceLabelUpdate();
    }
}
