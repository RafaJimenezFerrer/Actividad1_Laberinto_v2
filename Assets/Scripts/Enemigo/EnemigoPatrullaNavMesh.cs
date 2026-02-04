using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemigoPatrullaNavMesh : MonoBehaviour
{
    // Variables
    [Header("Variables publicas")]
    public Transform[] puntosPatrulla;
    public float tiempoEspera = 1f;

    // Variables privadas
    public NavMeshAgent agente;
    private int indiceActual = 0;
    private float contadorEspera;

    //Métodos
    private void Awake()
    {
        agente = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        if (puntosPatrulla.Length > 0)
            agente.SetDestination(puntosPatrulla[0].position);
    }

    private void Update()
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

    private void CambiarPunto()
    {
        indiceActual = (indiceActual + 1) % puntosPatrulla.Length;
        agente.SetDestination(puntosPatrulla[indiceActual].position);
    }
}
