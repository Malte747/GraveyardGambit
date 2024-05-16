using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class GetChased : MonoBehaviour
{

    public float intensity = 0f;

    PostProcessVolume _volume;
    Vignette _vignette;
    private bool _isChased = false;



    void Start()
    {
        _volume =GetComponent<PostProcessVolume>();
        _volume.profile.TryGetSettings<Vignette>(out _vignette);

        if(!_vignette)
        {
            print("error, vignette empty");
        }

        else
        {
            _vignette.enabled.Override(false);
        }
    }

    public void Chase()
    {
        if (!_isChased)
        {
            _isChased = true;
            StartCoroutine(ChaseEffect());
        }
        

    }

    public void DontChase()
    {
        _isChased = false;
    }

    private IEnumerator ChaseEffect()
{
    intensity = 0f;

    _vignette.enabled.Override(true);

    float duration = 3f; // Dauer der Intensitätserhöhung
    float maxIntensity = 0.4f;

    float elapsedTime = 0f;
    while (elapsedTime < duration)
    {
        elapsedTime += Time.deltaTime;

        intensity = Mathf.Lerp(0f, maxIntensity, elapsedTime / duration);
        _vignette.intensity.Override(intensity);

        yield return null;
    }

    // Überprüfen, ob der Spieler noch verfolgt wird
    while (_isChased)
    {
        yield return null;
    }

    // Zurücksetzen der Intensität, wenn der Spieler nicht mehr verfolgt wird
    duration = 1f; // Dauer der Intensitätsabnahme
    elapsedTime = 0f;
    while (elapsedTime < duration)
    {
        elapsedTime += Time.deltaTime;

        intensity = Mathf.Lerp(maxIntensity, 0f, elapsedTime / duration);
        _vignette.intensity.Override(intensity);

        yield return null;
    }

    _vignette.enabled.Override(false);
}

}
