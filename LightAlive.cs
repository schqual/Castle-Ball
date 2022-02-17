using UnityEngine;
using System.Collections;

public class LightAlive : MonoBehaviour {

    private float intensity;

    void Start()
    {
        intensity = light.intensity;
        StartCoroutine(ChangeLightIntensity());
    }

	IEnumerator ChangeLightIntensity() {
        while (true)
        {
            light.intensity = Random.Range(.5f, 1f) * intensity;
            yield return new WaitForSeconds(0.05f);
        }
	}
}
