using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualEffect : MonoBehaviour
{
    private AudioManager audioManager;
    private GameObject centerPoint;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>().GetComponent<AudioManager>();
        centerPoint = GameObject.Find("InsideCircle");
    }

    private void Update()
    {
        PulsateCenterPoint();
    }

    private void PulsateCenterPoint()
    {
        float currentVolume = audioManager.GetVolume();
        centerPoint.transform.localScale = new Vector3(1.7f + currentVolume, 1.7f + currentVolume, 1);
    }
}
