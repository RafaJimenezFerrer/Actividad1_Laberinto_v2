using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour
{
    // Variebles
    [Header("Variables publicas")]
    public string escena_juego = "SampleScene";

    // Metodos
    public void jugar()
    {
        SceneManager.LoadScene(escena_juego);
    }

    public void salir()
    {
        Application.Quit();
        Debug.Log("Salir del juego");
    }
}

