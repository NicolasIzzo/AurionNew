using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnTetro : MonoBehaviour
{
    public Transform[] criaPecas;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(criaPecas[Random.Range(0,7)], transform.position, Quaternion.identity); 
    }
    public void proximaPeca()
    {
        Instantiate(criaPecas[Random.Range(0, 7)], transform.position, Quaternion.identity);
    }
    public void cancelaPeca()
    {
        Instantiate(null, transform.position, Quaternion.identity);
    }

}
