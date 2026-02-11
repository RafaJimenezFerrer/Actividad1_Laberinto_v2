using UnityEngine;

public class MuerteEnemigo : MonoBehaviour
{
    [SerializeField] private int puntosPorMatar = 25;
    // Metodos
    public void RecibirDisparo()
    {
        Debug.Log("Un " + gameObject.name + " ha sido eliminado.");
        ScoreManager.Instance.Add(puntosPorMatar);
        Destroy(gameObject);
    }
}