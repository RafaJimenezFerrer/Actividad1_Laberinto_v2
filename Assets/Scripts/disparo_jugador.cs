using UnityEngine;

public class disparo_jugador : MonoBehaviour
{
    public float distancia_disparo = 10f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            disparar();
        }
    }

    void disparar()
    {
        Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit impacto;

        int mascara = ~LayerMask.GetMask("Player");

        if (Physics.Raycast(rayo, out impacto, distancia_disparo, mascara))
        {
            Debug.Log("Has pulsado: " + impacto.collider.name);

            if (impacto.collider.CompareTag("Interruptor"))
            {
                impacto.collider.GetComponent<interruptor>().activar();
            }
        }
    }


}
