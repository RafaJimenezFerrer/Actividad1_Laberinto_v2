using UnityEngine;

public class final_nivel : MonoBehaviour
{
    public GameObject canvas_nivel_superado;

    private void Start()
    {
        if (canvas_nivel_superado != null)
            canvas_nivel_superado.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (canvas_nivel_superado != null)
                canvas_nivel_superado.SetActive(true);

            Time.timeScale = 0f;
        }
    }
}

