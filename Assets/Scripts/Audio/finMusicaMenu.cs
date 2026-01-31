using UnityEngine;

public class MusicaNivel : MonoBehaviour
{
    void Start()
    {
        MusicaMenu menu = FindObjectOfType<MusicaMenu>();
        if (menu != null)
        {
            Destroy(menu.gameObject);
        }
    }
}
