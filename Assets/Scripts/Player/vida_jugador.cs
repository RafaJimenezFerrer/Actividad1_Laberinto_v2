using UnityEngine;
using UnityEngine.UI;

public class VidaJugador : MonoBehaviour
{
    [Header("Vida")]
    public float vidaMaxima = 100f;
    public float vidaActual;

    [Header("UI")]
    public Image barraVida;

    [Header("Sonido Daño")]
    public AudioSource audioDaño;
    public float tiempoEntreSonidos = 1f;

    private float siguienteSonido = 0f;

    void Start()
    {
        vidaActual = vidaMaxima;
        ActualizarBarra();
    }

    public void RecibirDaño(float daño)
    {
        vidaActual -= daño;
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMaxima);

        if (audioDaño != null && Time.time >= siguienteSonido)
        {
            audioDaño.Play();
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
        muerte_jugador muerte = GetComponent<muerte_jugador>();
        if (muerte != null)
        {
            muerte.morir();
        }
    }
}
