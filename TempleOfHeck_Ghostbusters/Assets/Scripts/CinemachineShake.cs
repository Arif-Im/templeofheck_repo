using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineShake : MonoBehaviour
{
    public static CinemachineShake Instance {get; private set;}
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private float startingIntensity;
    private float shakeTimer;
    private float shakeTimerTotal;


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
        startingIntensity = intensity;
        shakeTimer = time;
        shakeTimerTotal = time;
    }

    void Update()
    {
        if(shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                    cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = Mathf.Lerp(startingIntensity, 0.0f, 1 - (shakeTimer / shakeTimerTotal));
        }
    }
}
