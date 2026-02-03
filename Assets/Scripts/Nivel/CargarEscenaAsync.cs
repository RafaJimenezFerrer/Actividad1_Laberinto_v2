using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CargarEscenaAsync : MonoBehaviour
{
    // Variables
    [Header("Variables publicas")]
    [Header("Carga")]
    public GameObject pantallaCarga;
    public string nombreEscena = "SampleScene";

    // Metodos
    public void CargarNivel()
    {
        StartCoroutine(Cargar());
    }

    IEnumerator Cargar()
    {
        // Mostrar pantalla de carga
        pantallaCarga.SetActive(true);

        yield return null;

        AsyncOperation operacion = SceneManager.LoadSceneAsync(nombreEscena);
        operacion.allowSceneActivation = false;

        // Esperar a que termine de cargar
        while (operacion.progress < 0.9f)
        {
            yield return null;
        }

        yield return new WaitForSeconds(1f);

        operacion.allowSceneActivation = true;
    }
}
