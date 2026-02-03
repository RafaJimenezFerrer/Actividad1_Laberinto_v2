using UnityEngine;

public class DisparoJugador : MonoBehaviour
{
    // Variables
    [Header("Variables publicas")]
    public float distanciaDisparo = 10f;

    // Metodos
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Disparar();
        }
    }

    void Disparar()
    {
        Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit impacto;

        int mascara = ~LayerMask.GetMask("Player");

        if (Physics.Raycast(rayo, out impacto, distanciaDisparo, mascara))
        {
            Debug.Log("Has pulsado: " + impacto.collider.name);

            if (impacto.collider.CompareTag("Interruptor"))
            {
                impacto.collider.GetComponent<Interruptor>().Activar();
            }
        }
    }


}
