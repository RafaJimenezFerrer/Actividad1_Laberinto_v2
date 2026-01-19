using UnityEngine;
using System.Collections;
using TMPro;

public class muerte_jugador : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI texto_muerte;

    [Header("Respawn")]
    public float tiempo_espera = 2f;

    private Vector3 posicion_inicial;
    private Quaternion rotacion_inicial_jugador;
    private Quaternion rotacion_inicial_camara;

    private CharacterController controller;
    private Transform camara;
    private MonoBehaviour script_movimiento;

    void Start()
    {
        posicion_inicial = transform.position;
        rotacion_inicial_jugador = transform.rotation;

        camara = GetComponentInChildren<Camera>().transform;
        rotacion_inicial_camara = camara.localRotation;

        controller = GetComponent<CharacterController>();
        script_movimiento = GetComponent<MovimientoPersonaje>();
    }

    public void morir()
    {
        Debug.Log("Has muerto");
        StartCoroutine(mostrar_texto_muerte());
        StartCoroutine(reaparecer_con_pausa());
    }

    IEnumerator reaparecer_con_pausa()
    {
        if (script_movimiento != null)
            script_movimiento.enabled = false;

        if (controller != null)
            controller.enabled = false;

        transform.position = posicion_inicial;
        transform.rotation = rotacion_inicial_jugador;
        camara.localRotation = rotacion_inicial_camara;

        yield return new WaitForSeconds(tiempo_espera);

        if (controller != null)
            controller.enabled = true;

        if (script_movimiento != null)
            script_movimiento.enabled = true;
    }

    IEnumerator mostrar_texto_muerte()
    {
        if (texto_muerte != null)
        {
            texto_muerte.gameObject.SetActive(true);
            yield return new WaitForSeconds(2f);
            texto_muerte.gameObject.SetActive(false);
        }
    }
}
