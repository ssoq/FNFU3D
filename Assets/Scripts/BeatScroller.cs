using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    [Header("Beat Settings")]
    [SerializeField] private float tempo = 128f;
    [SerializeField] private float multiplier = 2f;

    void Start()
    {
        
    }

    void Update()
    {
        if (!GameManager.Instance.canPlay) return;

        ScrollNotes();
    }

    private void ScrollNotes() 
    {
        transform.Translate(Vector3.up * tempo * multiplier * Time.deltaTime);
    }
}
