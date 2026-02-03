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
            VidaJugador vida = other.GetComponent<VidaJugador>();
            if (vida != null)
            {
                vida.RecibirDanio(danioInstantaneo);
            }
        }
    }
}
