using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelManager : MonoBehaviour
{
    public string levelToLoad;
    public int totalJugadores = 2;

    private HashSet<int> jugadoresListos = new HashSet<int>();

    public void JugadorEntro(int jugadorID)
    {
        jugadoresListos.Add(jugadorID);
        VerificarCambioDeEscena();
    }

    public void JugadorSalio(int jugadorID)
    {
        jugadoresListos.Remove(jugadorID);
    }

    private void VerificarCambioDeEscena()
    {
        if (jugadoresListos.Count >= totalJugadores)
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
