using UnityEngine;

public class SfxSkills : MonoBehaviour
{
    [SerializeField] AudioSource _source;
    [SerializeField] MultiAudioFiles _audioFiles;

    public void PlaySfxSkill(int index)
    {
        var viewportPoint = Camera.main.WorldToViewportPoint(transform.position);
        if (viewportPoint.x <= 0.98f && viewportPoint.x >= 0.03f && viewportPoint.y <= 0.98f && viewportPoint.y >= 0.03f)
        {
            PlaySfx(_audioFiles, index);
        }
    }


    private void PlaySfx(MultiAudioFiles multiAudioFiles, int index)
    {
        _source.clip = multiAudioFiles.AudioFile[index];
        var randomPitch = Random.Range(0.95f, 1.05f);
        _source.pitch = randomPitch;
        _source.Play();
    }
}