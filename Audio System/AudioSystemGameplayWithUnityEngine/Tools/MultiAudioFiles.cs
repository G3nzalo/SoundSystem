using UnityEngine;

[CreateAssetMenu(fileName = "MultiAudio Files", menuName = "Kaizen/MultiAudioFiles")]
public class MultiAudioFiles : ScriptableObject
{
    [SerializeField] private AudioClip[] _audioFile;

    public AudioClip[] AudioFile => _audioFile;
}