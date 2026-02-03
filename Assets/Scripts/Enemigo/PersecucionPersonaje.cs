using UnityEngine;
using UnityEngine.AI;

public class PersecucionPersonaje : MonoBehaviour
{
    // Variables
    [Header("Variables publicas")]
    public float radio = 5f;
   
    public MovimientoPersonaje personaje;
    public float distanciaEscucha = 0.01f;
    //public GameObject personaje;

    // Variables privadas
    private NavMeshAgent agente;

    // Metodos
    private void Persecucion()
    {
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, radio);
        for (int i = 0; i < colliders.Length; i++)
        {

            if(Vector3.Distance(personaje.transform.position, agente.destination) < distanciaEscucha)
            {

            }
            {

            }
        }
    }
}
