using UnityEngine;
using UnityEngine.UI;

public class VidaJugador : MonoBehaviour
{
    // Variables
    [Header("Variables publicas")]
    [Header("Vida")]
    public float vidaMaxima = 100f;
    public float vidaActual;

    [Header("UI")]
    public Image barraVida;

    [Header("Sonido Danio")]
    public AudioSource audioDanio;
    public float tiempoEntreSonidos = 1f;

    // Variables privadas
    private float siguienteSonido = 0f;

    // Metodos
    void Start()
    {
        vidaActual = vidaMaxima;
        ActualizarBarra();
    }

    public void RecibirDanio(float daño)
    {
        vidaActual -= daño;
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMaxima);

        if (audioDanio != null && Time.time >= siguienteSonido)
        {
            audioDanio.Play();
            siguienteSonido = Time.time + tiempoEntreSonidos;
        }

        ActualizarBarra();

        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    void ActualizarBarra()
    {
        if (barraVida != null)
            barraVida.fillAmount = vidaActual / vidaMaxima;
    }

    void Morir()
    {
        MuerteJugador muerte = GetComponent<MuerteJugador>();
        if (muerte != null)
        {
            muerte.Morir();
        }
    }
}
