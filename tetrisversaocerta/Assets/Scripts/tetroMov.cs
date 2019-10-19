using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tetroMov : MonoBehaviour
{
    public bool podeRodar;
    public bool roda360;
    public float queda;
    public float velocidade;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = velocidade;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= 21f)
        {
            Debug.Log("Voce perdeu");
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            timer = velocidade;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            timer += Time.deltaTime;
            if (timer > velocidade)
            {
                transform.position += new Vector3(1, 0, 0);
                timer = 0;
            }
            if (posicaoValida())
            {
                FindObjectOfType<gameManager>().atualizaGrade(this);
            }
            else
            {
                transform.position += new Vector3(-1, 0, 0);
            }
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            timer += Time.deltaTime;
            if (timer > velocidade)
            {
                transform.position += new Vector3(-1, 0, 0);
                timer = 0;
            }
            if (posicaoValida())
            {
                FindObjectOfType<gameManager>().atualizaGrade(this);
            }
            else
            {
                transform.position += new Vector3(1, 0, 0);
            }
        }
        if (Input.GetKey(KeyCode.DownArrow)) //|| Time.time - queda >= 1)
        {
            timer += Time.deltaTime;
            if (timer > velocidade)
            {
                transform.position += new Vector3(0, -1, 0);
                timer = 0;
            }
            if (posicaoValida())
            {
                FindObjectOfType<gameManager>().atualizaGrade(this);
            }
            else
            {
                transform.position += new Vector3(0, 1, 0);
                FindObjectOfType<gameManager>().apaga();
                enabled = false;
                FindObjectOfType<spawnTetro>().proximaPeca();
            }

            //queda = Time.time;
        }
        if(Time.time - queda >= 1 && !Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, -1, 0);
            if (posicaoValida())
            {
                FindObjectOfType<gameManager>().atualizaGrade(this);
            }
            else
            {
                transform.position += new Vector3(0, 1, 0);
                FindObjectOfType<gameManager>().apaga();
                enabled = false;
                FindObjectOfType<spawnTetro>().proximaPeca();
            }
            queda = Time.time; 
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
                        FindObjectOfType<gameManager>().atualizaGrade(this);
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
                        FindObjectOfType<gameManager>().atualizaGrade(this);
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
                    FindObjectOfType<gameManager>().atualizaGrade(this);
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
        foreach (Transform child in transform)
        {
            Vector2 posBloco = FindObjectOfType<gameManager>().arrendonda(child.position);
            if (FindObjectOfType<gameManager>().dentroGrade(posBloco) == false)
            {
                return false;
            }
            if (FindObjectOfType<gameManager>().posicaoTransGrade(posBloco) != null && FindObjectOfType<gameManager>().posicaoTransGrade(posBloco).parent != transform)
            {
                return false;
            }
        }
        return true;
    }
}
