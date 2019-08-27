using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NewBehaviourScript : MonoBehaviour
{

    public int totalLife;
    private int currentLife;
    // Use this for initialization
    protected void Start()
    {
        currentLife = totalLife;
    }

    // Update is called once per frame
    protected void Update()
    {

    }

    public void Comparation(int cards)
    {
        currentLife -= cards;
        OnDamage();

        if (currentLife <= 0)
        {
            Defeat();
        }

    }

    public abstract void OnDamage();
    public abstract void Defeat();
}
