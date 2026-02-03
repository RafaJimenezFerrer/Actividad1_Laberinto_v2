using UnityEngine;

public class MuerteRoca : MonoBehaviour
{
    // Variables
    // Variables privadas
    private TrampaRocaCaida trampa;

    // Metodos
    void Start()
    {
        trampa = GetComponentInParent<TrampaRocaCaida>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        if (trampa == null)
            return;

        MuerteJugador muerte = collision.gameObject.GetComponent<MuerteJugador>();
        if (muerte != null)
        {
            muerte.Morir();
        }
    }
}
