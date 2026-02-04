using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemigoPatrullaNavMesh))]
public class EnemigoPersecucion : MonoBehaviour
{
    // Variables
    [Header("Variables publicas")]
    public float radioVision = 2.5f;
    public float distanciaRayo = 5f;
    public LayerMask layerMask;
    //public float distanciaAcercamiento = 1f;

    // Variables privadas
    private EnemigoPatrullaNavMesh enemigo;

    private void Awake()
    {
        enemigo = this.GetComponent<EnemigoPatrullaNavMesh>();
    }

    // Metodos
    private void Update()
    {
       Persecucion();
    }

    private void Persecucion()
    {
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, radioVision);
        //Debug.Log($"Colliders {colliders.Length}");
        for (int i = 0; i<colliders.Length; i++)
        {
            if (colliders[i].GetComponent<MovimientoPersonaje>())
            {
                Debug.Log("Personaje cerca");
                MovimientoPersonaje personaje = colliders[i].GetComponent<MovimientoPersonaje>();
                Debug.Log($"Prueba {Physics.Raycast(this.transform.position, transform.forward, out RaycastHit impacto2, distanciaRayo)}");
                if (Physics.Raycast(this.transform.position, transform.forward, out RaycastHit impacto, distanciaRayo))
                {
                    Debug.Log("Disparo" + impacto.collider.name);
                    if(impacto.collider.GetComponent<MovimientoPersonaje>())
                    {
                        Debug.Log("Personaje detectado");
                        enemigo.agente.SetDestination(personaje.transform.position);
                    }

                }
            }
            // && 



            //Debug.Log($"Colliders chocados {colliders[i].name}");
            //Vector3 direccion = (personaje.transform.position - this.transform.position).normalized;

        }
    }
}