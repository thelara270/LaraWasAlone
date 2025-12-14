using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetosActivos : MonoBehaviour
{
    public Plataforma plataforma;
    public int idPermitido = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Movimiento jugador = collision.gameObject.GetComponent<Movimiento>();

        if (jugador != null && jugador.jugadorID == idPermitido)
        {
            plataforma.enabled = true;
        }
    }
}
