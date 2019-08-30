/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsistenciaData : MonoBehaviour
{
    public Dropdown dia;
    public Dropdown mes;
    public Dropdown ano;


    


    int month;
    int day;
    int year;
    private bool bissexto = false;
    private int dmax = 30;

    List<string> meses = new List<string>() { "Mês", "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro" };
    List<string> anos = new List<string>() { "Ano" };
    List<string> dias = new List<string>();

    void Start()
    {
        PreencherListAno();
        PreencherListMes();
        PreencherListDia();
    }

    void PreencherListAno()
    {
        for (int i = 2018; i >= 1910; i--)
        {
            anos.Add(i.ToString());
        }
        ano.AddOptions(anos);
    }
    void PreencherListMes()
    {
        mes.AddOptions(meses);
    }

    void PreencherListDia()
    {
        dia.ClearOptions();
        dias.Clear();


        dias.Add("Dia");


        for (int j = 1; j <= dmax; j++)
        {
            dias.Add(j.ToString());
        }
        dia.AddOptions(dias);
    }

    public void AnoBissexto(int indexano)
    {
        year = int.Parse(anos[indexano]);

        if (year % 4 == 0 && year % 100 != 0)
            bissexto = true;
        else if (year % 400 == 0)
            bissexto = true;
        else
            bissexto = false;

        VerificarMes(month);
        PreencherListDia();
    }

    public void VerificarMes(int indexmes)
    {
        month = indexmes;

        if (indexmes == 2)
        {
            if (bissexto)
                dmax = 29;
            else
                dmax = 28;
        }
        else
        {
            if (indexmes % 2 == 0 && indexmes != 8)
            {
                dmax = 30;
            }
            else
            {
                dmax = 31;
            }
        }
        PreencherListDia();
    }

    
}
*/