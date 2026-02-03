using UnityEngine;

public class Interruptor : MonoBehaviour
{
    [Header("Variables publicas")]
    public AperturaPuerta puertaAsociada;

    // Variables privadas
    private bool activado = false;

    public void Activar()
    {
        if (activado)
            return;

        activado = true;
        Debug.Log("Interruptor ACTIVADO");

        if (puertaAsociada != null)
        {
            puertaAsociada.Abrir();
        }
    }
}

