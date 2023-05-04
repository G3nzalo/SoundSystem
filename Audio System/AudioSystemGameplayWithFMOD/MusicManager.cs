using Fusion;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance = null;

    public enum ZONES {MENU,FOREST , DESERT , TEST};

    public static void SetStopMusic() => StopMusic();
    public void SetZoneMusic(ZONES zone) => _music.setParameterByName("Ambiences", (int)zone);
 
    private static FMOD.Studio.EventInstance _music;

    private void Awake()
    {
        Initialize();
        SetMusicInit();
    }

    private void SetMusicInit()
    {
        if (IsStoped())
        {
            _music = FMODUnity.RuntimeManager.CreateInstance("event:/Sounds/Ambiences/Environment");
            _music.start();
        }
    }

    private static void setZoneMusic(ZONES zone)
    {
        _music.setParameterByName("Ambiences", (int)zone);
    }
    private static void StopMusic()
    {
        _music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        _music.release();
    }

    private void Initialize()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private bool IsStoped()
    {
        FMOD.Studio.PLAYBACK_STATE state;
        _music.getPlaybackState(out state);
        return state == FMOD.Studio.PLAYBACK_STATE.STOPPED;
    }

}
