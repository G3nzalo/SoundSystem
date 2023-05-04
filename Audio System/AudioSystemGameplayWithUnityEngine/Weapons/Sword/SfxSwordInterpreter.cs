using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxSwordInterpreter : MonoBehaviour , ISowrdsListenerAnimation
{
    [SerializeField] AudioSource _source;
    [SerializeField] AudioFiles _katanaFiles;
    [SerializeField] Transform _position;

    private void Start()
    {
        SetSound();
    }

    public void SetSound()
    {
        _source.clip = _katanaFiles.audioFile;
    }

    public void StartSweetSpot()
    {
        var viewportPoint = Camera.main.WorldToViewportPoint(transform.position);
        if (viewportPoint.x <= 0.98f && viewportPoint.x >= 0.03f && viewportPoint.y <= 0.98f && viewportPoint.y >= 0.03f)
        {
            var rand = UnityEngine.Random.Range(0.9f, 1.2f);
            _source.pitch = rand;
            _source.Play();
        }
    }
}
