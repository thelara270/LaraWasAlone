using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class ControladorMenu : MonoBehaviour
{
    [SerializeField] GameObject juego;
    [SerializeField] GameObject panelTuto;
    [SerializeField] GameObject panelInicio;
    
    private void Start()
    {
        juego.SetActive(false);
        panelTuto.SetActive(false);
        panelInicio.SetActive(true);
            
        Time.timeScale = 0f;
    }

    public void IniciarJuego()
    {
        panelInicio.SetActive(false);   
        panelTuto.SetActive(true);
        juego.SetActive(true);

        Time.timeScale = 1f;
    }
  
}
