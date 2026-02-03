using UnityEngine;

public class MusicaMenu : MonoBehaviour
{
    // Variables
    // Variables privadas
    private static MusicaMenu instancia;

    // Métodos
    private void Awake()
    {
        if (instancia != null)
        {
            Destroy(gameObject);
            return;
        }

        instancia = this;
        DontDestroyOnLoad(gameObject);
    }
}

