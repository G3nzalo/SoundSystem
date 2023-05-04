using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MusicSystem : MonoBehaviour
{
    public static MusicSystem instance = null;
    public enum TRACK { MENU, FOREST }

    [SerializeField] private AudioSource[] trackSource = null;
    [SerializeField] private AudioClip[] tracks = null;

    [SerializeField] private float[] modeVolumes = null;
    [SerializeField] private float volumeTransitionTime = 1.0f;

    private FloatLerper volumeLerperA = null;
    private FloatLerper volumeLerperB = null;

    public readonly int MENU = 0;
    public readonly int FOREST = 1;

    private bool isFirst = true;


    private void Awake()
    {
        Initialize();
        volumeLerperA = new FloatLerper(volumeTransitionTime, AbstractLerper<float>.SMOOTH_TYPE.STEP_SMOOTHER);
        volumeLerperB = new FloatLerper(volumeTransitionTime, AbstractLerper<float>.SMOOTH_TYPE.STEP_SMOOTHER);

    }
    private void Start()
    {
        SetVolumeMode(volumeLerperA, 2, trackSource[0]);
        SetTrack(TRACK.MENU, 0);
        trackSource[MENU].Play();
        trackSource[MENU].loop = true;
    }
    private void Update()
    {
        if (volumeLerperA.On)
        {
            volumeLerperA.Update();
            trackSource[0].volume = volumeLerperA.CurrentValue;
        }
        if (!volumeLerperA.On && GetAudioSource(MENU).volume == 0f) GetAudioSource(MENU).Stop();

        if (volumeLerperB.On)
        {
            volumeLerperB.Update();
            trackSource[1].volume = volumeLerperB.CurrentValue;
        }

        if (SceneManager.GetActiveScene().buildIndex == 3 && isFirst)
        {
            TransitionMenuToForest();
        }
    }
    public AudioSource GetAudioSource(int trackSources) => trackSource[trackSources];

    public FloatLerper GetVolumenLerperA() => volumeLerperA;
    public FloatLerper GetVolumenLerperB() => volumeLerperB;

    public void SetVolumeMode(FloatLerper lerperSource, int mode, AudioSource source)
    {
        lerperSource.SetValues(source.volume, modeVolumes[mode], true);
    }

    public void SetTrack(TRACK track, int trackSourceFile)
    {
        trackSource[trackSourceFile].clip = tracks[(int)track];
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
    public void TransitionMenuToForest()
    {
        SetVolumeMode(GetVolumenLerperA(), 0, GetAudioSource(MENU));
        SetVolumeMode(GetVolumenLerperB(), 1, GetAudioSource(FOREST));
        SetTrack(TRACK.FOREST, 1);
        GetAudioSource(FOREST).Play();
        GetAudioSource(FOREST).loop = true;
        isFirst = false;

    }
}
