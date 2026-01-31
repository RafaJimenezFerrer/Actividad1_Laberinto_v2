using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class muerte_jugador : MonoBehaviour
{
    [Header("UI")]
    public GameObject pantallaMuerte; 
    public GameObject barraVidaUI; 

    [Header("Respawn")]
    public float tiempo_espera = 2f;

    private CharacterController controller;
    private MonoBehaviour script_movimiento;
    private bool yaMuerto = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        script_movimiento = GetComponent<MovimientoPersonaje>();

        if (pantallaMuerte != null)
            pantallaMuerte.SetActive(false);
    }

    public void morir()
    {
        if (yaMuerto) return;
        yaMuerto = true;

        StartCoroutine(SecuenciaMuerte());
    }

    IEnumerator SecuenciaMuerte()
    {
        // Bloquear jugador
        if (script_movimiento != null)
            script_movimiento.enabled = false;

        if (controller != null)
            controller.enabled = false;

        // Ocultar barra de vida
        if (barraVidaUI != null)
            barraVidaUI.SetActive(false);

        // Mostrar pantalla de muerte
        if (pantallaMuerte != null)
            pantallaMuerte.SetActive(true);

        // Espera
        yield return new WaitForSeconds(tiempo_espera);

        // Reiniciar escena completa
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

