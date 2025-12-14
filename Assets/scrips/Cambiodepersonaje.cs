using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cambiodepersonaje : MonoBehaviour
{
    public List<GameObject> characterList = new List<GameObject>();
    public int player;

    void Start()
    {
        ActivateCharacter();
        CambiarCamaraObjetivo(); // Asegura que la cámara comience con el personaje activo
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            NextCharcter();
            ActivateCharacter();

            // 🔊 Sonido de cambio
            if (AudioManager.instance != null && AudioManager.instance.cambioJugadorClip != null)
            {
                AudioManager.instance.ReproducirSonido(AudioManager.instance.cambioJugadorClip);
            }
            else
            {
                Debug.LogWarning("AudioManager o sonido de cambio no asignado.");
            }

            // 🎥 Cambio de objetivo de cámara
            CambiarCamaraObjetivo();
        }
    }

    void NextCharcter()
    {
        player++;
        if (player > characterList.Count - 1)
        {
            player = 0;
        }
    }

    void ActivateCharacter()
    {
        for (int i = 0; i < characterList.Count; i++)
        {
            bool activo = (i == player);
            characterList[i].GetComponent<Movimiento>().FuncionActivarSalto(activo);
        }
    }

    void CambiarCamaraObjetivo()
    {
        CameraTargetSwitcher camSwitcher = FindObjectOfType<CameraTargetSwitcher>();
        if (camSwitcher != null)
        {
            camSwitcher.CambiarObjetivo(characterList[player].transform);
        }
        else
        {
            Debug.LogWarning("No se encontró CameraTargetSwitcher en la escena.");
        }
    }
}
