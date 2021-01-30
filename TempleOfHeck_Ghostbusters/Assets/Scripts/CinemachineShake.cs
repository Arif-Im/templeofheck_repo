using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Cinemachine;

public class CinemachineShake : MonoBehaviour
{
    /*
    public static CinemachineShake Instance {get; private set;}
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private float startingIntensity;
    private float shakeTimer;
    private float shateTimerTotal;


    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
            cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        shakeTimer = timer;
        shakeTimerTotal = timer;
        StartCoroutine("shakingCamera");
    }

    IEnumerator shakingCamera()
    {
        while(shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                    cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                float currentIntensity = Mathf.Lerp(startingIntensity, 0.0f, 1-(shakeTimer/shakeTimerTotal));
                
                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = currentIntensity;
            yield return null;
        }
    }
    */
}
