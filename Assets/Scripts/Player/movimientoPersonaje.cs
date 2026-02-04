using UnityEngine;

[RequireComponent (typeof(CharacterController))] 
[RequireComponent(typeof(CapsuleCollider))]
public class MovimientoPersonaje : MonoBehaviour
{
    // Variables
    [Header("Variables publicas")]
    public float velocidadAvance = 5f;
    public float velocidadGiro = 90f;

    // Variables privadas
    private CharacterController controller;

    // Metodos
    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float turn = Input.GetAxis("Horizontal");
        transform.Rotate(0, turn * velocidadGiro * Time.deltaTime, 0);

        float forward = Input.GetAxis("Vertical");
        Vector3 avanceLocal = new Vector3(0, 0, forward);

        Vector3 avanceGlobal = transform.TransformDirection(avanceLocal);

        controller.Move(avanceGlobal * velocidadAvance * Time.deltaTime);
    }
}
