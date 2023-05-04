using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(UnityEngine.EventSystems.EventTrigger))]
public class UiSoundsSystem : MonoBehaviour
{
    #region Reference in Editor
    [SerializeField] private FMODUnity.EventReference _pauseSnapshot;
    [SerializeField] private FMODUnity.EventReference _btnPause;
    [SerializeField] private  FMODUnity.EventReference _btnOverSfx;
    [SerializeField] private FMODUnity.EventReference _btnContinuePause;
    [SerializeField] private FMODUnity.EventReference _btnHost;
    [SerializeField] private FMODUnity.EventReference _btnLeave;

    [Space(10)]
    [Header("Ui Reference")]
    [SerializeField] private GameObject _pauseMenu;

    [SerializeField] private GameObject _roomName;
    [SerializeField] private GameObject _nickName;

    [SerializeField] private Button _hostButton;
    [SerializeField] private Button _connectButton;
    [SerializeField] private Button _exitButton;

    #endregion

    #region Privare Variables
    private FMOD.Studio.EventInstance _snapshotInstance;
    private bool _isPause = false;

    private void OnMouseEnter(BaseEventData pointData) => FmodExtensions.SetSfx(_btnOverSfx);
    private void OnMouseClickInputFields(BaseEventData pointData) => ContinueSfx();

    private EventTrigger.Entry _entry = new EventTrigger.Entry();
    EventTrigger.Entry _triggerSfxInputFields = new EventTrigger.Entry();


    #endregion

    #region MonoBehaviour Methods
    private void Awake()
    {
        EventTrigger triggerInputFieldRoomName = _roomName.GetComponent<EventTrigger>();
        EventTrigger triggerInputFieldNickName = _nickName.GetComponent<EventTrigger>();

        EventTrigger triggerHostButton = _hostButton.GetComponent<EventTrigger>();
        EventTrigger triggerConnectButton = _connectButton.GetComponent<EventTrigger>();
        EventTrigger triggerExitButton = _exitButton.GetComponent<EventTrigger>();

        _entry.eventID = EventTriggerType.PointerEnter;
        _entry.callback = new EventTrigger.TriggerEvent();
        _entry.callback.AddListener(OnMouseEnter);


        _triggerSfxInputFields.eventID = EventTriggerType.PointerClick;
        _triggerSfxInputFields.callback = new EventTrigger.TriggerEvent();
        _triggerSfxInputFields.callback.AddListener(OnMouseClickInputFields);


        triggerInputFieldRoomName.triggers.Add(_triggerSfxInputFields);

        triggerInputFieldNickName.triggers.Add(_triggerSfxInputFields);

        triggerHostButton.triggers.Add(_entry);

        triggerConnectButton.triggers.Add(_entry);

        triggerExitButton.triggers.Add(_entry);

        _hostButton.onClick.AddListener(() => StartGameBtnSounds());
        _connectButton.onClick.AddListener(() => StartGameBtnSounds());
    }

    private void Update()
    {
        CheckPause();
        InPauseSounds();
    }
    #endregion

    #region Private Methods

    private void StartGameBtnSounds()
    {
        FmodExtensions.SetSfx(_btnHost);
        _entry.callback.RemoveAllListeners();
        _triggerSfxInputFields.callback.RemoveAllListeners();

    }

    private void CheckPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            {
            if (!_roomName.activeInHierarchy)
            {
                if (!_isPause)
                {
                    FmodExtensions.SetSfx(_btnPause);
                    StarSnapshotPause();
                }
                else
                {
                    FmodExtensions.SetSfx(_btnContinuePause);
                    StopSnapshotPause();
                }
            }
        }
    }

    private void StopSnapshotPause()
    {
        _snapshotInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        _snapshotInstance.release();
        _isPause = false;
    }

    private void StarSnapshotPause()
    {
        _snapshotInstance = FMODUnity.RuntimeManager.CreateInstance(_pauseSnapshot);
        _snapshotInstance.start();
        _snapshotInstance.release();
        _isPause = true;
    }

    private void ContinueSfx()
    {
        FmodExtensions.SetSfx(_btnContinuePause);
        StopSnapshotPause();
    }
    #endregion

}
