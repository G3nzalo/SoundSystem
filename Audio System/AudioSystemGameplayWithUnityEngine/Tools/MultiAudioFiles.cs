using UnityEngine;

[CreateAssetMenu(fileName = "MultiAudio Files", menuName = "AudioTools/MultiAudioFiles")]
public class MultiAudioFiles : ScriptableObject
{
    [SerializeField] private AudioClip[] _audioFile;

    public AudioClip[] AudioFile => _audioFile;
}