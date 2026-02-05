using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.LowLevel;

[RequireComponent(typeof(EnemigoPatrullaNavMesh))]
public class EnemigoPersecucion : MonoBehaviour
{
    // Variables
    [Header("Variables publicas")]
    public float radioVision = 2.5f;
    public float distanciaRayo = 2.5f;

    // Variables privadas
    private EnemigoPatrullaNavMesh enemigo;

    private void Awake()
    {
        enemigo = null;
        enemigo = GetComponent<EnemigoPatrullaNavMesh>();
    }

    // Metodos
    private void Update()
    {
        Persecucion();
    }

    private void Persecucion()
    {
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, radioVision);
       
        for (int i = 0; i<colliders.Length; i++)
        {
            if (colliders[i].GetComponent<MovimientoPersonaje>())
            {
                MovimientoPersonaje personaje = colliders[i].GetComponent<MovimientoPersonaje>();
                Vector3 direccion = (personaje.transform.position  - this.transform.position).normalized; 
                if (Physics.Raycast(this.transform.position, direccion, out RaycastHit impacto, distanciaRayo))
                {
                    if ((impacto.collider.GetComponent<MovimientoPersonaje>()))
                    {
                        Debug.Log("Personaje encontrado. Persiguiendo");
                        enemigo.agente.SetDestination(personaje.transform.position);
                    }
                }
            }
        }
    }
}