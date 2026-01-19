using UnityEngine;
using System.Collections;

public class trampa_roca_caida : MonoBehaviour
{
    public Transform roca;

    public float distancia_caida = 3.1f;
    public float velocidad_caida = 10f;
    public float velocidad_subida = 2f;
    public float tiempo_abajo = 1.5f;
    public float tiempo_arriba = 1f;

    public ParticleSystem particulas_impacto;

    private Vector3 posicion_arriba;
    private Vector3 posicion_abajo;

    private Rigidbody rb;

    void Start()
    {
        posicion_arriba = roca.position;
        posicion_abajo = posicion_arriba - Vector3.up * distancia_caida;

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
            rb.linearVelocity = Vector3.down * velocidad_caida;

            while (roca.position.y > posicion_abajo.y)
            {
                yield return null;
            }

            rb.linearVelocity = Vector3.zero;
            rb.isKinematic = true;
            roca.position = posicion_abajo;

            if (particulas_impacto != null)
            {
                particulas_impacto.Play();
            }

            yield return new WaitForSeconds(tiempo_abajo);


            while (Vector3.Distance(roca.position, posicion_arriba) > 0.01f)
            {
                roca.position = Vector3.MoveTowards(
                    roca.position,
                    posicion_arriba,
                    velocidad_subida * Time.deltaTime
                );
                yield return null;
            }

            roca.position = posicion_arriba;

            yield return new WaitForSeconds(tiempo_arriba);
        }
    }
}
