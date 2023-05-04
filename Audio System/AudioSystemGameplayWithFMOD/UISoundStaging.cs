using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(UnityEngine.EventSystems.EventTrigger))]
public class UISoundStaging : MonoBehaviour
{
    [SerializeField] private FMODUnity.EventReference _btnOverSfx;
    [SerializeField] private FMODUnity.EventReference _btnContinuePause;
    [SerializeField] private FMODUnity.EventReference _connect;
    [SerializeField] private FMODUnity.EventReference _btnHost;
    [SerializeField] private FMODUnity.EventReference _btnLeave;

    [SerializeField] private GameObject _roomName;
    [SerializeField] private Button _toggleReadyToGame;
    [SerializeField] private Slider _sliderR;
    [SerializeField] private Slider _sliderG;
    [SerializeField] private Slider _sliderB;
    [SerializeField] private Button _initGame;
    [SerializeField] private Button _diconnect;

    EventTrigger.Entry _clickInputs = new EventTrigger.Entry();

    private void OnMouseClickInputFields(BaseEventData pointData) => FmodExtensions.SetSfx(_btnContinuePause);

    private void Awake()
    {

        _clickInputs.eventID = EventTriggerType.PointerClick;
        _clickInputs.callback = new EventTrigger.TriggerEvent();
        _clickInputs.callback.AddListener(OnMouseClickInputFields);

        EventTrigger triggerInputFieldRoomName = _roomName.GetComponent<EventTrigger>();
        triggerInputFieldRoomName.triggers.Add(_clickInputs);

        EventTrigger TriggerReadyToGame = _toggleReadyToGame.GetComponent<EventTrigger>();
        _toggleReadyToGame.onClick.AddListener(() => FmodExtensions.SetSfx(_connect));

        EventTrigger TriggerColorRed = _sliderR.GetComponent<EventTrigger>();
        TriggerColorRed.triggers.Add(_clickInputs);

        EventTrigger TriggerColorGreen = _sliderG.GetComponent<EventTrigger>();
        TriggerColorGreen.triggers.Add(_clickInputs);

        EventTrigger TriggerColorBlue = _sliderB.GetComponent<EventTrigger>();
        TriggerColorBlue.triggers.Add(_clickInputs);

        EventTrigger TriggerInitGame = _initGame.GetComponent<EventTrigger>();
        _initGame.onClick.AddListener(() => SetInitGames());

        EventTrigger TriggerDisconnect = _diconnect.GetComponent<EventTrigger>();
        _diconnect.onClick.AddListener(() => FmodExtensions.SetSfx(_btnLeave));
    }

    private void SetInitGames()
    {
        FmodExtensions.SetSfx(_btnHost);
        MusicManager.instance.SetZoneMusic(MusicManager.ZONES.FOREST);
    }

}
