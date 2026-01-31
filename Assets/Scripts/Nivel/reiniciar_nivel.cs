using UnityEngine;
using UnityEngine.SceneManagement;

public class reiniciar_nivel : MonoBehaviour
{
    public void reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
