using UnityEngine;
using Cinemachine;

public class CameraTargetSwitcher : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;

    public void CambiarObjetivo(Transform nuevo)
    {
        if (vcam != null)
        {
            vcam.Follow = nuevo;
        }
    }
}