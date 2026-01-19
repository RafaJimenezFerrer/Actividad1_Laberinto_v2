using UnityEngine;

public class puerta : MonoBehaviour
{
    public float distancia_apertura = 1f;
    public float velocidad = 2f;

    public bool abrir_izquierda = true;

    private Vector3 posicion_cerrada;
    private Vector3 posicion_abierta;
    private bool abriendo = false;

    void Start()
    {
        posicion_cerrada = transform.position;

        if (abrir_izquierda)
        {
            posicion_abierta = posicion_cerrada - transform.right * distancia_apertura;
        }
        else
        {
            posicion_abierta = posicion_cerrada + transform.right * distancia_apertura;
        }
    }

    void Update()
    {
        if (abriendo)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                posicion_abierta,
                velocidad * Time.deltaTime
            );
        }
    }

    public void abrir()
    {
        if (!abriendo)
        {
            abriendo = true;
        }
    }
}
