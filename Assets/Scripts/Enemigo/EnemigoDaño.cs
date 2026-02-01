using UnityEngine;

public class EnemigoFantasmaDaño : MonoBehaviour
{
    [Header("Daño")]
    public float daño = 20f;
    public float tiempoEntreDaño = 1.2f;

    private float siguienteDaño = 0f;

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (Time.time < siguienteDaño)
            return;

        VidaJugador vida = other.GetComponent<VidaJugador>();
        if (vida != null)
        {
            vida.RecibirDaño(daño);
            siguienteDaño = Time.time + tiempoEntreDaño;
        }
    }
}
