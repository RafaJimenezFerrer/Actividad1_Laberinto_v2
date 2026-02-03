using UnityEngine;

public class MusicaNivel : MonoBehaviour
{
    // Metodos
    private void Start()
    {
        MusicaMenu menu = Object.FindFirstObjectByType<MusicaMenu>();
        if (menu != null)
        {
            Destroy(menu.gameObject);
        }
    }
}
