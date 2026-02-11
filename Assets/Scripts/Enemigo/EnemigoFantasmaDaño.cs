using UnityEngine;

public class EnemigoFantasmaDaño : MonoBehaviour
{
    // Variables
    [Header("Variables publicas")]
    [Header("Danio")]
    [Header("penalizacion")]
    [SerializeField] private int pointsOnTouchPenalty = 5;
    [SerializeField] private bool useTrigger = true;

    public float danio = 20f;
    public float tiempoEntreDanio = 1.2f;

    [Header("Sonido")]
    public AudioSource fuenteSonido;

    // Variables privadas
    private float siguienteDanio = 0f;


    private void Awake()
    {

        if (fuenteSonido == null)
        {
            fuenteSonido = GetComponent<AudioSource>();
        }
    }
    // Metodos
    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (Time.time < siguienteDanio)
            return;

        VidaJugador vida = other.GetComponent<VidaJugador>();
        if (vida != null)
        {
            vida.RecibirDanio(danio);
            siguienteDanio = Time.time + tiempoEntreDanio;

            if (fuenteSonido != null)
            {
                if (vida.vidaActual > 0)
                {
                    fuenteSonido.Play();
                }
                else
                {
                    fuenteSonido.Stop();
                }
            }
        }
    }
    
private void OnTriggerEnter(Collider other)
    {
        if (!useTrigger) return;
        if (!other.CompareTag("Player")) return;

        ApplyPenaltyAndDamage(other.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (useTrigger) return;
        if (!collision.collider.CompareTag("Player")) return;

        ApplyPenaltyAndDamage(collision.collider.gameObject);
    }

    private void ApplyPenaltyAndDamage(GameObject player)
    {
        ScoreManager.Instance.Subtract(pointsOnTouchPenalty);
        Debug.Log($"[EnemyContactDamage] Toque enemigo: -{pointsOnTouchPenalty} puntos");
    }
 }

