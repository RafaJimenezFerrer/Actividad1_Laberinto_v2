using UnityEngine;
using System.Collections;

public class Trampa_fuego : MonoBehaviour
{
    public float tiempo_encendido = 2f;
    public float tiempo_apagado = 2f;
    public float dañoPorSegundo = 20f;

    private ParticleSystem fuego;
    private Collider collider_fuego;
    private bool fuego_activo = false;

    void Start()
    {
        fuego = GetComponent<ParticleSystem>();
        collider_fuego = GetComponent<Collider>();

        fuego.Stop();
        collider_fuego.enabled = false;
        fuego_activo = false;

        StartCoroutine(ciclo_fuego());
    }

    IEnumerator ciclo_fuego()
    {
        while (true)
        {
            // encender fuego
            fuego_activo = true;
            fuego.Play();
            collider_fuego.enabled = true;
            yield return new WaitForSeconds(tiempo_encendido);

            // apagar fuego
            fuego_activo = false;
            fuego.Stop();
            collider_fuego.enabled = false;
            yield return new WaitForSeconds(tiempo_apagado);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (!fuego_activo)
            return;

        if (other.CompareTag("Player"))
        {
            VidaJugador vida = other.GetComponent<VidaJugador>();
            if (vida != null)
            {
                vida.RecibirDaño(dañoPorSegundo * Time.deltaTime);
            }
        }
    }
}


