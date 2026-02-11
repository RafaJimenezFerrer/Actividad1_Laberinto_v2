using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem))]
[RequireComponent (typeof(Collider))]
public class TrampaFuego : MonoBehaviour
{
    [Header("Danio periodico")]
    [SerializeField] private int pointsPerTick = 5;
    [SerializeField] private int healthDamagePerTick = 5;
    [SerializeField] private float tickInterval = 1.0f;

    private float nextTickTime = 0f;
    private bool playerInside = false;
    private VidaJugador cachedPlayer;

    public float tiempo_encendido = 2f;
    public float tiempo_apagado = 2f;
    public float danioPorSegundo = 20f;

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
                vida.RecibirDanio(danioPorSegundo * Time.deltaTime);
            }
        }
        if (!playerInside || !other.CompareTag("Player")) return;

        if (Time.time >= nextTickTime)
        {
            // Resta puntos
            ScoreManager.Instance.Subtract(pointsPerTick);

            // Daño a vida
            if (cachedPlayer != null)
                cachedPlayer.RecibirDanio(healthDamagePerTick);

            nextTickTime = Time.time + tickInterval;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        playerInside = true;
        cachedPlayer = other.GetComponent<VidaJugador>();
        nextTickTime = Time.time; // aplica inmediatamente en el siguiente Update
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        playerInside = false;
        cachedPlayer = null;
    }

}


