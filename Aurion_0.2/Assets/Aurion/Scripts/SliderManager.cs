using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SliderManager : MonoBehaviour
{
    // Start is called before the first frame update
    public RectTransform popup, editarperfil;
    public Button closePopup, closeEP;
    void Start()
    {
        Button btnPopup = closePopup.GetComponent<Button>();
        closePopup.onClick.AddListener(ClosePopup);
        popup.DOAnchorPos(new Vector2(-450,2000),0.01f);

        Button btnEP = closeEP.GetComponent<Button>();
        closeEP.onClick.AddListener(CloseEditarPerfil);
        editarperfil.DOAnchorPos(new Vector2(-2000,200),0.025f);
    }

    // Update is called once per frame
    public void CallPopup()
    {
        popup.DOAnchorPos(new Vector2(-450,50),0.25f);
    }
    public void ClosePopup()
    {
        popup.DOAnchorPos(new Vector2(-450,2000),0.25f);
    }

    public void CallEditarPerfil()
    {
        editarperfil.DOAnchorPos(new Vector2(-465,40),0.025f);
    }

    public void CloseEditarPerfil()
    {
        editarperfil.DOAnchorPos(new Vector2(-2000,200),0.025f);
    }
}
