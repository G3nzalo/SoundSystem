using UnityEngine;

public class SfxWeapons : MonoBehaviour
{
    [SerializeField] AudioSource _source;
    [SerializeField] MultiAudioFiles _gunAudioFiles;
    [SerializeField] MultiAudioFiles _sniperAudioFiles;
    [SerializeField] MultiAudioFiles _assaultRiffleAudioFiles;

    public void PlaySfxFire(string id , Transform position)
    {
        var viewportPoint = Camera.main.WorldToViewportPoint(transform.position);
        if (viewportPoint.x <= 0.98f && viewportPoint.x >= 0.03f && viewportPoint.y <= 0.98f &&viewportPoint.y >= 0.03f)
        {
            if (id.Equals("Pistol"))
            {
                PlaySfx(_gunAudioFiles);
            }

            if (id.Equals("Sniper"))
            {
                PlaySfx(_sniperAudioFiles);
            }

            if (id.Equals("AssaultRifle"))
            {
                PlaySfx(_assaultRiffleAudioFiles);
            }
        }
    }

    private void PlaySfx(MultiAudioFiles multiAudioFiles)
    {
        var random = Random.Range(0, multiAudioFiles.AudioFile.Length);
        _source.clip = multiAudioFiles.AudioFile[random];
        var randomPitch = Random.Range(0.9f, 1.2f);
        _source.pitch = randomPitch;
        _source.Play();
    }
}
