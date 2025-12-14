using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public int jugadorID;

    float horizontal;
    Rigidbody2D rigid;
    private BoxCollider2D boxCollider;

    public float fuerzaSalto;
    public float velocidad;

    public Transform centroDeteccion;
    public Vector2 tamanoDeteccion;
    public LayerMask capaDeteccionJugador;
    public LayerMask capaDeteccionPiso;

    public bool tocaPiso;
    public bool tocaJugador;

    public bool Activar = false;

    Vector2 spawn;

    private bool caminando = false;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();

        spawn = transform.position;

    }
    void EstaEnSuelo()
    {
        tocaPiso = Physics2D.OverlapBox(centroDeteccion.position, tamanoDeteccion, 0, capaDeteccionPiso);
        tocaJugador = Physics2D.OverlapBox(centroDeteccion.position, tamanoDeteccion, 0, capaDeteccionJugador);
    }
    void Update()
    {
        if (Activar == true)
        {
            EstaEnSuelo();

            Caminar();
            Saltar();

            // Control de sonido de pasos
            if (Mathf.Abs(horizontal) > 0.1f && tocaPiso)
            {
                if (!caminando)
                {
                    caminando = true;
                    if (AudioManager.instance != null && AudioManager.instance.caminar != null && !AudioManager.instance.caminar.isPlaying)
                    {
                        AudioManager.instance.caminar.Play();
                    }
                }
            }
            else
            {
                if (caminando)
                {
                    caminando = false;
                    if (AudioManager.instance != null && AudioManager.instance.caminar != null)
                    {
                        AudioManager.instance.caminar.Stop();
                    }
                }
            }
        }
    }

    public void FuncionActivarSalto(bool enable)
    {
        Activar = enable;

        if (enable)
        {
            rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            rigid.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

            // También detener sonido de pasos si se desactiva el personaje
            if (AudioManager.instance != null && AudioManager.instance.caminar != null)
            {
                AudioManager.instance.caminar.Stop();
            }

            caminando = false;
        }
    }

    public void Caminar()
    {
        horizontal = Input.GetAxis("Horizontal");
        rigid.velocity = new Vector2(horizontal * velocidad, rigid.velocity.y);
    }

    public void Saltar()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (tocaPiso || tocaJugador))
        {
            rigid.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);

            // Reproducir sonido de salto
            if (AudioManager.instance != null && AudioManager.instance.saltar != null)
            {
                AudioManager.instance.ReproducirSonido(AudioManager.instance.saltar);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(centroDeteccion.position, tamanoDeteccion);
    }

    public void Reaparecer()
    {
        transform.position = spawn;
        rigid.velocity = Vector2.zero;
    }
}