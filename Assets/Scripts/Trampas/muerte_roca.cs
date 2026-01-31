using UnityEngine;

public class muerte_roca : MonoBehaviour
{
    private trampa_roca_caida trampa;

    void Start()
    {
        trampa = GetComponentInParent<trampa_roca_caida>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        if (trampa == null)
            return;

        muerte_jugador muerte = collision.gameObject.GetComponent<muerte_jugador>();
        if (muerte != null)
        {
            muerte.morir();
        }
    }
}
