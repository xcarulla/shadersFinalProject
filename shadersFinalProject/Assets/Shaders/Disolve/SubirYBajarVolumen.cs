using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubirYBajarVolumen : MonoBehaviour
{
    public AudioSource audioSource;
    public float volumenMax = 1.0f;

    private void Start()
    {
        StartCoroutine(SubirYBajar());
    }

    private IEnumerator SubirYBajar()
    {
        // Esperar 5 segundos
        yield return new WaitForSeconds(5.0f);

        // Subir el volumen durante 8 segundos
        float tiempoSubida = 8.0f;
        float tiempoInicio = Time.time;
        audioSource.volume = 0.0f;
        audioSource.Play();
        while (Time.time - tiempoInicio < tiempoSubida)
        {
            float t = (Time.time - tiempoInicio) / tiempoSubida;
            audioSource.volume = Mathf.Lerp(0.0f, volumenMax, t);
            yield return null;
        }

        // Esperar 7 segundos
        yield return new WaitForSeconds(9.0f);

        // Bajar el volumen durante 7 segundos
        float tiempoBajada = 7.0f;
        tiempoInicio = Time.time;
        while (Time.time - tiempoInicio < tiempoBajada)
        {
            float t = (Time.time - tiempoInicio) / tiempoBajada;
            audioSource.volume = Mathf.Lerp(volumenMax, 0.0f, t);
            yield return null;
        }
    }
}
