using UnityEngine;

public class NextLevelPortal : MonoBehaviour
{
    public int jugadorEsperadoID; // ID que debe tener el jugador que activa este portal
    public NextLevelManager manager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Movimiento movimiento = other.GetComponent<Movimiento>();
        if (movimiento != null && movimiento.jugadorID == jugadorEsperadoID)
        {
            manager.JugadorEntro(movimiento.jugadorID);

            // 🔊 Reproducir sonido de entrada al portal
            if (AudioManager.instance != null && AudioManager.instance.portalClip != null)
            {
                AudioManager.instance.ReproducirSonido(AudioManager.instance.portalClip);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Movimiento movimiento = other.GetComponent<Movimiento>();
        if (movimiento != null && movimiento.jugadorID == jugadorEsperadoID)
        {
            manager.JugadorSalio(movimiento.jugadorID);
        }
    }
}
