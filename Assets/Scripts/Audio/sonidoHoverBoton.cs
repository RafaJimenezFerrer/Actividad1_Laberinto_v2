using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(AudioSource))]

public class SonidoHoverBoton : MonoBehaviour, IPointerEnterHandler
{
    // Variables
    [Header("Variables publicas")]
    public AudioClip sonidoHover;

    // Variables privadas
    private AudioSource audioSource;

    // Metodos
   private void Awake()
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
