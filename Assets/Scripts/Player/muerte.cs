using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MuerteJugador : MonoBehaviour
{
    // Variables
    [Header("Variables publicas")]
    [Header("UI")]
    public GameObject pantallaMuerte; 
    public GameObject barraVidaUI; 

    [Header("Respawn")]
    public float tiempo_espera = 2f;

    // Variables privadas
    private CharacterController controller;
    private MonoBehaviour script_movimiento;
    private bool yaMuerto = false;

    // Metodos
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        script_movimiento = GetComponent<MovimientoPersonaje>();
    }

    void Start()
    {
        if (pantallaMuerte != null)
            pantallaMuerte.SetActive(false);
    }

    public void Morir()
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

