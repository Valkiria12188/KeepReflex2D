using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField] private float scrollingSpeed;
    private Vector2 offset;
    void Update()
    {
        offset += new Vector2(0, Time.deltaTime * scrollingSpeed);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
