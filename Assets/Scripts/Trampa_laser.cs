using UnityEngine;
using System.Collections;

public class trampa_laser : MonoBehaviour
{
    public float distancia_salida = 0.6f;
    public float tiempo_fuera = 1.5f;
    public float tiempo_dentro = 1.5f;
    public float velocidad = 3f;

    private Vector3 posicion_dentro;
    private Vector3 posicion_fuera;

    void Start()
    {
        posicion_dentro = transform.localPosition;
        posicion_fuera = posicion_dentro + Vector3.forward * distancia_salida;

        StartCoroutine(ciclo_laser());
    }

    IEnumerator ciclo_laser()
    {
        while (true)
        {
            //salir
            while (Vector3.Distance(transform.localPosition, posicion_fuera) > 0.01f)
            {
                transform.localPosition = Vector3.MoveTowards(
                    transform.localPosition,
                    posicion_fuera,
                    velocidad * Time.deltaTime
                );
                yield return null;
            }

            yield return new WaitForSeconds(tiempo_fuera);

            //entrar
            while (Vector3.Distance(transform.localPosition, posicion_dentro) > 0.01f)
            {
                transform.localPosition = Vector3.MoveTowards(
                    transform.localPosition,
                    posicion_dentro,
                    velocidad * Time.deltaTime
                );
                yield return null;
            }

            yield return new WaitForSeconds(tiempo_dentro);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            muerte_jugador muerte = other.GetComponent<muerte_jugador>();
            if (muerte != null)
            {
                muerte.morir();
            }
        }
    }
}

