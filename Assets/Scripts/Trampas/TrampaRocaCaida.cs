using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class TrampaRocaCaida : MonoBehaviour
{
    // Variables
    [Header("Variables publicas")]
    public Transform roca;

    public float distanciaCaida = 3.1f;
    public float velocidadCaida = 10f;
    public float velocidadSubida = 2f;
    public float tiempoAbajo = 1.5f;
    public float tiempoArriba = 1f;

    public ParticleSystem particulasImpacto;

    // Variables privadas
    private Vector3 posicionArriba;
    private Vector3 posicionAbajo;

    private Rigidbody rb;

    // Metodos
    void Start()
    {
        posicionArriba = roca.position;
        posicionAbajo = posicionArriba - Vector3.up * distanciaCaida;

        rb = roca.GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true;

        StartCoroutine(ciclo_roca());
    }

    IEnumerator ciclo_roca()
    {
        while (true)
        {
            rb.isKinematic = false;
            rb.linearVelocity = Vector3.down * velocidadCaida;

            while (roca.position.y > posicionAbajo.y)
            {
                yield return null;
            }

            rb.linearVelocity = Vector3.zero;
            rb.isKinematic = true;
            roca.position = posicionAbajo;

            if (particulasImpacto != null)
            {
                particulasImpacto.Play();
            }

            yield return new WaitForSeconds(tiempoAbajo);


            while (Vector3.Distance(roca.position, posicionArriba) > 0.01f)
            {
                roca.position = Vector3.MoveTowards(
                    roca.position,
                    posicionArriba,
                    velocidadSubida * Time.deltaTime
                );
                yield return null;
            }

            roca.position = posicionArriba;

            yield return new WaitForSeconds(tiempoArriba);
        }
    }
}
