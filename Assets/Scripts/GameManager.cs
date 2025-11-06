using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject panelPrincipal;
    public GameObject panelPausa;
    public Image imgVida;
    public Image imgStamine;
    // Start is called before the first frame update
    public void Continuar()
    {
        Time.timeScale = 1;
        panelPausa.SetActive(false);
        panelPrincipal.SetActive(true);
    }
    public void Pausa()
    {
        Time.timeScale = 0;
        panelPausa.SetActive(true);
        panelPrincipal.SetActive(false);
    }

    private void DrawDataLife()
    {
        print("prueba");
    }

    public void Salir()
    {
        Application.Quit();
    }
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Pausa();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            Continuar();
        }
    }
}
