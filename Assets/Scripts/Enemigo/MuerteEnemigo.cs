using UnityEngine;

public class MuerteEnemigo : MonoBehaviour
{
    // Metodos
    public void RecibirDisparo()
    {
        Debug.Log("Un " + gameObject.name + " ha sido eliminado.");
        Destroy(gameObject);
    }
}