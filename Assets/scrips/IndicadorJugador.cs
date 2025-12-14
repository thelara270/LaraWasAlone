using UnityEngine;

public class IndicadorJugadorActivo : MonoBehaviour
{
    public int jugadorActivoID = 0;
    public float altura = 1.5f; // Altura sobre el jugador

    private Movimiento[] jugadores;

    void Start()
    {
        jugadores = FindObjectsOfType<Movimiento>();
    }

    void Update()
    {
        foreach (var jugador in jugadores)
        {
            if (jugador.jugadorID == jugadorActivoID)
            {
                Vector3 posicion = jugador.transform.position;
                posicion.y += altura;
                posicion.z -= altura;
                transform.position = posicion;
                break;
            }
        }

        // Cambiar de jugador al presionar F (opcional)
        if (Input.GetKeyDown(KeyCode.F))
        {
            CambiarJugador();
        }
    }

    void CambiarJugador()
    {
        jugadorActivoID++;
        if (jugadorActivoID >= jugadores.Length)
        {
            jugadorActivoID = 0;
        }
    }
}
