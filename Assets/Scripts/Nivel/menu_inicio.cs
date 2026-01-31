using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_inicio : MonoBehaviour
{
    public string escena_juego = "SampleScene";

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

