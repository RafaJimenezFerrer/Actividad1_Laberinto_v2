using UnityEngine;
using UnityEngine.AI;

public class EnemigoPatrullaNavMesh : MonoBehaviour
{
    public Transform[] puntosPatrulla;
    public float tiempoEspera = 1f;

    private NavMeshAgent agente;
    private int indiceActual = 0;
    private float contadorEspera;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();

        if (puntosPatrulla.Length > 0)
            agente.SetDestination(puntosPatrulla[0].position);
    }

    void Update()
    {
        if (!agente.pathPending && agente.remainingDistance < 0.2f)
        {
            contadorEspera += Time.deltaTime;

            if (contadorEspera >= tiempoEspera)
            {
                CambiarPunto();
                contadorEspera = 0f;
            }
        }
    }

    void CambiarPunto()
    {
        indiceActual = (indiceActual + 1) % puntosPatrulla.Length;
        agente.SetDestination(puntosPatrulla[indiceActual].position);
    }
}
