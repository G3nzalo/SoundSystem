using UnityEngine;

[CreateAssetMenu(fileName = "Audio Files UI", menuName = "AudioTools/AudioFilesUI")]
public class AudioFilesUi : ScriptableObject
{
    public AudioClip[] audioFiles = null;
}