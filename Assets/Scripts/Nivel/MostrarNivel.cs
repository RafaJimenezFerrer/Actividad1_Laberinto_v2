using UnityEngine;
using System.Collections;
using TMPro;

public class MostrarNivel : MonoBehaviour
{
    // Variables
    [Header ("Variables publicas")]
    public TextMeshProUGUI texto_nivel;
    public float tiempo_visible = 2f;
    public float duracion_fade = 1f;

    // Metodos
    void Start()
    {
        StartCoroutine(MostrarTexto());
    }

    IEnumerator MostrarTexto()
    {
        if (texto_nivel == null)
            yield break;

        texto_nivel.gameObject.SetActive(true);

        yield return StartCoroutine(Fade(0f, 1f));

        yield return new WaitForSeconds(tiempo_visible);

        yield return StartCoroutine(Fade(1f, 0f));

        texto_nivel.gameObject.SetActive(false);
    }

    IEnumerator Fade(float alpha_inicial, float alpha_final)
    {
        float tiempo = 0f;
        Color color = texto_nivel.color;

        while (tiempo < duracion_fade)
        {
            float alpha = Mathf.Lerp(alpha_inicial, alpha_final, tiempo / duracion_fade);
            texto_nivel.color = new Color(color.r, color.g, color.b, alpha);

            tiempo += Time.deltaTime;
            yield return null;
        }

        texto_nivel.color = new Color(color.r, color.g, color.b, alpha_final);
    }
}
