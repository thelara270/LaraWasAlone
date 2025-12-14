using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Audio Sources")]
    public AudioSource musicaFondo;    // Música de fondo en loop
    public AudioSource efectos;        // Efectos puntuales (PlayOneShot)
    public AudioSource caminar;      // Pasos en loop (Play / Stop)

    [Header("Clips")]
    public AudioClip cambioJugadorClip;
    public AudioClip portalClip;
    public AudioClip saltar;

    void Awake()
    {
        musicaFondo.volume = 0.3f;
        efectos.volume = 0.5f;
        caminar.volume = 1.0f;

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Mantener entre escenas
        }
        else
        {
            Destroy(gameObject); // Evitar duplicados
        }
    }
    void Update()
    {
        if (musicaFondo != null && !musicaFondo.isPlaying)
        {
            musicaFondo.Play();
        }
    }


    void Start()
    {
        // Iniciar música si no está sonando
        if (musicaFondo != null && !musicaFondo.isPlaying)
        {
            musicaFondo.loop = true;
            musicaFondo.Play();
           
        }
    }

    public void ReproducirSonido(AudioClip clip)
    {
        if (clip != null && efectos != null)
        {
            efectos.PlayOneShot(clip);
        }
    }

}
