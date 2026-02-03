using UnityEngine;

public class EnemigoFantasmaDaño : MonoBehaviour
{
    // Variables
    [Header("Variables publicas")]
    [Header("Danio")]
    public float danio = 20f;
    public float tiempoEntreDanio = 1.2f;

    // Variables privadas
    private float siguienteDanio = 0f;

    // Metodos
    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (Time.time < siguienteDanio)
            return;

        VidaJugador vida = other.GetComponent<VidaJugador>();
        if (vida != null)
        {
            vida.RecibirDanio(danio);
            siguienteDanio = Time.time + tiempoEntreDanio;
        }
    }
}
