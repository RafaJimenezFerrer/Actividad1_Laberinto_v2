using UnityEngine;
using UnityEngine.EventSystems;

public class SonidoHoverBoton : MonoBehaviour, IPointerEnterHandler
{
    public AudioClip sonidoHover;
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (sonidoHover != null)
        {
            audioSource.PlayOneShot(sonidoHover);
        }
    }
}
