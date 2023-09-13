using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    [Header("Beat Settings")]
    [SerializeField] private float tempo = 190f;
    [SerializeField] private float beatsPerSecond = 60f;
    [SerializeField] private float multiplier = 2f;

    void Start()
    {
        tempo = tempo / beatsPerSecond * multiplier;
    }

    void Update()
    {
        if (!GameManager.Instance.canPlay) return;

        ScrollNotes();
    }

    private void ScrollNotes() 
    {
        transform.position += new Vector3(0f, tempo * multiplier * Time.deltaTime);
    }
}
