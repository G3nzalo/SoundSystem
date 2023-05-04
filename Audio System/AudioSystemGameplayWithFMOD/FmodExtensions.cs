//using static AdapterFxTrail;

public enum Weapons { Sword, Sonic , Default};

public class FmodExtensions
{
    private static bool _isPressedBtn1 = false;
    private static bool _isPressedBtn2 = false;
    private static bool _isPressedBtn3 = false;

    private static Weapons _weapons;

    private static FMOD.Studio.EventInstance instanceTrail;
    private static FMOD.Studio.EventInstance instanceInstaKill;

    public static Weapons WeaponType { get => _weapons; set => _weapons = value; }

    public static void SetSfx(FMODUnity.EventReference path) => SetInstanceSfx(path);

    public static void SetSfx(string path) => SetInstanceSfx(path);

    public static void SetSfxChangeWeapon(string path , bool is1 , bool is2, bool is3) => SetInstanceSfxChangeWeapon(path , is1, is2 , is3);

    public static void SetTrailSfx() => SfxTrail();

    public static void EndTrail() => FinishTrail();

    public static void SetSfxInstakill() => SfxInstaKill();

    public static void EndInstakill() => FinishInstakill();

    private static void SetInstanceSfx(FMODUnity.EventReference path)
    {
        FMOD.Studio.EventInstance instance;
        instance =  FMODUnity.RuntimeManager.CreateInstance(path);
        instance.start();
        instance.release();
    }

    private static void SetInstanceSfx(string path)
    {
        FMOD.Studio.EventInstance instance;
        instance = FMODUnity.RuntimeManager.CreateInstance(path);
        instance.start();
        instance.release();
    }

    private static void SetInstanceSfxChangeWeapon(string path , bool is1, bool is2, bool is3 )
    {
        if (is1 && !_isPressedBtn1 && !is2 && !is3)
        {
            _isPressedBtn1 = true;
            _isPressedBtn2 = false;
            _isPressedBtn3 = false;

            FMOD.Studio.EventInstance instance;
            instance = FMODUnity.RuntimeManager.CreateInstance(path);
            instance.start();
            instance.release();
        }

        if (is2 && !_isPressedBtn2 && !is1 && !is3)
        {
            _isPressedBtn1 = false;
            _isPressedBtn2 = true;
            _isPressedBtn3 = false;

            FMOD.Studio.EventInstance instance;
            instance = FMODUnity.RuntimeManager.CreateInstance(path);
            instance.start();
            instance.release();
        }

        if (is3 && !_isPressedBtn3 && !is1 && !is2)
        {
            _isPressedBtn1 = false;
            _isPressedBtn2 = false;
            _isPressedBtn3 = true;

            FMOD.Studio.EventInstance instance;
            instance = FMODUnity.RuntimeManager.CreateInstance(path);
            instance.start();
            instance.release();
        }
    }

    private static void SfxTrail()
    {
        if (WeaponType == WeaponFX.Sonic)
        {
            if (IsStoped())
            {
                instanceTrail = FMODUnity.RuntimeManager.CreateInstance("event:/Sounds/Player/Skills/Speed Up");
                instanceTrail.start();
            }
        }
    }

    private static void SfxInstaKill()
    {
        if (IsStopedInstaKill())
        {
            instanceInstaKill = FMODUnity.RuntimeManager.CreateInstance("event:/Sounds/Player/Instakill");
            instanceInstaKill.start();
        }
    }


    private static bool IsStoped()
    {
        FMOD.Studio.PLAYBACK_STATE state;
        instanceTrail.getPlaybackState(out state);
        return state == FMOD.Studio.PLAYBACK_STATE.STOPPED;
    }

    private static bool IsStopedInstaKill()
    {
        FMOD.Studio.PLAYBACK_STATE state;
        instanceInstaKill.getPlaybackState(out state);
        return state == FMOD.Studio.PLAYBACK_STATE.STOPPED;
    }

    private static void FinishTrail() => instanceTrail.release();

    private static void FinishInstakill() => instanceInstaKill.release();

}
