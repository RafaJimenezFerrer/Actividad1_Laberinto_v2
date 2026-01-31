using UnityEngine;

public class interruptor : MonoBehaviour
{
    public puerta puerta_asociada;
    private bool activado = false;

    public void activar()
    {
        if (activado)
            return;

        activado = true;
        Debug.Log("Interruptor ACTIVADO");

        if (puerta_asociada != null)
        {
            puerta_asociada.abrir();
        }
    }
}

