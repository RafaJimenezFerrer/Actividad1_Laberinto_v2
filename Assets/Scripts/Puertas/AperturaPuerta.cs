using UnityEngine;

public class AperturaPuerta : MonoBehaviour
{
    // Variables
    [Header("Variables publicas")]
    public float distanciaApertura = 1f;
    public float velocidad = 2f;
    [SerializeField] private int pointsOnOpen = 10;
    public bool abrirIzquierda = true;

    // Variables privadas
    private Vector3 posicionCerrada;
    private Vector3 posicionAbierta;
    private bool abriendo = false;

    // Metodos
    void Start()
    {
        posicionCerrada = transform.position;

        if (abrirIzquierda)
        {
            posicionAbierta = posicionCerrada - transform.right * distanciaApertura;
        }
        else
        {
            posicionAbierta = posicionCerrada + transform.right * distanciaApertura;
        }
    }

    void Update()
    {
        if (abriendo)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                posicionAbierta,
                velocidad * Time.deltaTime
            );
        }
    }

    public void Abrir()
    {
        if (!abriendo)
        {
            abriendo = true;
        }
        Debug.Log("[Door] Open() llamado por botón UI");
        ScoreManager.Instance.Add(pointsOnOpen);
    }
}
