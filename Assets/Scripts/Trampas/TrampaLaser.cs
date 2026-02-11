using UnityEngine;
using System.Collections;

public class TrampaLaser : MonoBehaviour
{
    // Variables
    [Header("Variables publicas")]
    [Header("Movimiento")]
    public float distanciaSalida = 0.6f;
    public float tiempoFuera = 1.5f;
    public float tiempoDentro = 1.5f;
    public float velocidad = 3f;

    [Header("Danio")]
    public float danioInstantaneo = 50f;
    public float tiempoEntreDanio = 1.0f;
    private float siguienteDanio;

    [Header("Puntuacion y danio")]
    [SerializeField] private int pointsOnDamage = 10;
    [SerializeField] private int healthDamage = 10;

    [Header("Una sola vez por entrada")]
    [SerializeField] private bool oneTimePerEntry = true;
    private bool hasAppliedOnThisEntry = false;


    // Variables privadas
    private Vector3 posicionDentro;
    private Vector3 posicionFuera;

    // Metodos
    void Start()
    {
        posicionDentro = transform.localPosition;
        posicionFuera = posicionDentro + Vector3.forward * distanciaSalida;

        StartCoroutine(ciclo_laser());
    }

    IEnumerator ciclo_laser()
    {
        while (true)
        {
            // Salir
            while (Vector3.Distance(transform.localPosition, posicionFuera) > 0.01f)
            {
                transform.localPosition = Vector3.MoveTowards(
                    transform.localPosition,
                    posicionFuera,
                    velocidad * Time.deltaTime
                );
                yield return null;
            }

            yield return new WaitForSeconds(tiempoFuera);

            // Entrar
            while (Vector3.Distance(transform.localPosition, posicionDentro) > 0.01f)
            {
                transform.localPosition = Vector3.MoveTowards(
                    transform.localPosition,
                    posicionDentro,
                    velocidad * Time.deltaTime
                );
                yield return null;
            }

            yield return new WaitForSeconds(tiempoDentro);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Time.time >= siguienteDanio)
            {
                VidaJugador vida = other.GetComponent<VidaJugador>();
                if (vida != null)
                {
                    vida.RecibirDanio(danioInstantaneo);

                    siguienteDanio = Time.time + tiempoEntreDanio;
                }
            }
        }

        if (!other.CompareTag("Player")) return;

        if (oneTimePerEntry && hasAppliedOnThisEntry) return;
        hasAppliedOnThisEntry = true;

        ScoreManager.Instance.Subtract(pointsOnDamage);
        Debug.Log("[Trap] ¡Trampa activada! - puntos -" + pointsOnDamage);


        if (!other.CompareTag("Player")) return;
        hasAppliedOnThisEntry = false;
    }
}
