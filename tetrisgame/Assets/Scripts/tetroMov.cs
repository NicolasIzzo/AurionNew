using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tetroMov : MonoBehaviour
{
    public bool podeRodar;
    public bool roda360;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
            if (posicaoValida())
            {

            }
            else
            {
                transform.position += new Vector3(-1, 0, 0);
            }
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
            if(posicaoValida())
            {

            }
            else
            {
                transform.position += new Vector3(1, 0, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, -1, 0);
            if (posicaoValida())
            {

            }
            else
            {
                transform.position += new Vector3(0, 1, 0);
            }
        }
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            checaRoda();
        }
    }

    void checaRoda()
    {
        if (podeRodar)
        {
            if (!roda360)
            {
                if(transform.rotation.z < 0)
                {
                    transform.Rotate(0, 0, 90);
                    if (posicaoValida())
                    {

                    }
                    else
                    {
                        transform.Rotate(0, 0, -90);
                    }
                }
                else
                {
                    transform.Rotate(0, 0, -90);
                    if (posicaoValida())
                    {

                    }
                    else
                    {
                        transform.Rotate(0, 0, 90);
                    }
                }
            }
            else
            {
                transform.Rotate(0, 0, -90);
                if (posicaoValida())
                {

                }
                else
                {
                    transform.Rotate(0, 0, 90);
                }
            }
        }
    }

    bool posicaoValida()
    {
        foreach(Transform child in transform)
        {
            Vector2 posBloco = FindObjectOfType<gameManager>().arrendonda(child.position);
            if (FindObjectOfType<gameManager>().dentroGrade(posBloco) == false)
            {
                return false;
            }
        }
        return true;
    }
}
