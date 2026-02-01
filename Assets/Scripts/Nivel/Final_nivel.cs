using UnityEngine;

public class final_nivel : MonoBehaviour
{
    [Header("UI")]
    public GameObject canvas_nivel_superado;
    public GameObject barraVida;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip sonidoWin;

    private bool nivelCompletado = false;

    private void Start()
    {
        if (canvas_nivel_superado != null)
            canvas_nivel_superado.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (nivelCompletado)
            return;

        if (other.CompareTag("Player"))
        {
            nivelCompletado = true;

            if (canvas_nivel_superado != null)
                canvas_nivel_superado.SetActive(true);

            if (barraVida != null)
                barraVida.SetActive(false);

            if (audioSource != null && sonidoWin != null)
            {
                audioSource.PlayOneShot(sonidoWin);
            }

            Time.timeScale = 0f;
        }
    }
}

