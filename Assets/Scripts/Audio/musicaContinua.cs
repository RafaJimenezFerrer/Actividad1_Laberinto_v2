using UnityEngine;

public class MusicaMenu : MonoBehaviour
{
    private static MusicaMenu instancia;

    void Awake()
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

