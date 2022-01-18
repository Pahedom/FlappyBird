using System.Collections;
using UnityEngine;

public class Effects : MonoBehaviour
{
    public GameObject whiteScreen;
    public static bool paused;
    public float whiteScreenDuration;
    float whiteScreenHold;
    public float pauseDuration;
    public float shakeDuration;
    public float shakeAmount;
    float shake;
    public Transform cam;

    void Update()
    {
        if (whiteScreenHold > 0)
        {
            whiteScreen.SetActive(true);
            whiteScreenHold -= Time.deltaTime;
        }
        else
        {
            whiteScreen.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        whiteScreen.SetActive(false);

        if (shake > 0)
        {
            cam.transform.position = new Vector3 (Random.Range(-shakeAmount, shakeAmount), Random.Range(-shakeAmount, shakeAmount), -10);

            shake -= Time.deltaTime;
        }
        else
        {
            cam.transform.position = new Vector3(0, 0, -10);
        }
    }

    public void ApplyEffects()
    {
        whiteScreenHold = whiteScreenDuration;

        StartCoroutine(Freeze());

        shake = shakeDuration;
    }

    IEnumerator Freeze()
    {
        Time.timeScale = 0;

        yield return new WaitForSecondsRealtime(pauseDuration);

        Time.timeScale = 1;
    }
}
