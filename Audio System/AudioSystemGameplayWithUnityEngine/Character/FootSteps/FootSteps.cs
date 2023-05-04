using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    [SerializeField] AudioFilesFootSteps surfaces;
    [SerializeField] AudioSource source;
    [SerializeField] Transform _position;

    public void RunStep() => PlayFootstep();

    private void PlayFootstep()
    {
        var viewportPoint = Camera.main.WorldToViewportPoint(transform.position);
        if (viewportPoint.x <= 0.98f && viewportPoint.x >= 0.03f && viewportPoint.y <= 0.98f && viewportPoint.y >= 0.03f)
        {
            if (!source.isPlaying)
            {
                var lenght = surfaces.concrete.Length;
                var rand = Random.Range(0, lenght);
                source.clip = surfaces.concrete[rand];
                source.Play();
            }
        }
    }
}

