using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activarobejtos : MonoBehaviour
{
    public GameObject objetos;
    public int idPermitido = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Movimiento jugador = collision.gameObject.GetComponent<Movimiento>();

        if (jugador != null && jugador.jugadorID == idPermitido)
        {
            objetos.SetActive(false);
        }
    }
}
