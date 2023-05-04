using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(UnityEngine.EventSystems.EventTrigger))]
public class UISoundIntro: MonoBehaviour
{
    #region Reference in Fmod editor
    [SerializeField] private FMODUnity.EventReference _btnOverSfx;
    [SerializeField] private FMODUnity.EventReference _btnContinuePause;
    [SerializeField] private FMODUnity.EventReference _btnHost;
    [SerializeField] private FMODUnity.EventReference _btnLeave;
    #endregion

    #region GameTypme
    [SerializeField] private Button _gameType;
    [SerializeField] private TMP_Dropdown _regionGame;
    #endregion

    #region SesionList
    [SerializeField] private Button _newSession;
    [SerializeField] private Button _closePanelSessionList;
    #endregion

    #region Create Session
    [SerializeField] private GameObject _roomName;
    [SerializeField] private Toggle _map1;
    [SerializeField] private Toggle _map2;
    [SerializeField] private Button _removePlayer;
    [SerializeField] private Button _addplayer;
    [SerializeField] private Button _createSession;
    [SerializeField] private Button _closePanelCreateGame;
    #endregion

    private EventTrigger.Entry _clickInputs = new EventTrigger.Entry();

    public void PlaySfx() => FmodExtensions.SetSfx("event:/Sounds/UI/Continue");
    private void OnMouseClickInputFields(BaseEventData pointData) => ContinueSfx();
    private void ContinueSfx() => FmodExtensions.SetSfx(_btnContinuePause);

    private void Awake()
    {
        EventTrigger triggerInputFieldRoomName = _roomName.GetComponent<EventTrigger>();
        EventTrigger triggerInputRegion = _regionGame.GetComponent<EventTrigger>();

        EventTrigger triggerGameType = _gameType.GetComponent<EventTrigger>();

        EventTrigger triggerCrateSession = _newSession.GetComponent<EventTrigger>();
        EventTrigger triggerCloseTabSessionsList = _closePanelSessionList.GetComponent<EventTrigger>();

        EventTrigger triggerRoomName = _roomName.GetComponent<EventTrigger>();
        EventTrigger triggerMap1 = _map1.GetComponent<EventTrigger>();
        EventTrigger triggerMap2 = _map2.GetComponent<EventTrigger>();
        EventTrigger triggerRemovePlayer = _removePlayer.GetComponent<EventTrigger>();
        EventTrigger triggerAddPlayer = _addplayer.GetComponent<EventTrigger>();
        EventTrigger triggerCreateSession = _createSession.GetComponent<EventTrigger>();
        EventTrigger triggerClosePlanelCreateGame = _closePanelCreateGame.GetComponent<EventTrigger>();

        _clickInputs.eventID = EventTriggerType.PointerClick;
        _clickInputs.callback = new EventTrigger.TriggerEvent();
        _clickInputs.callback.AddListener(OnMouseClickInputFields);

        triggerInputFieldRoomName.triggers.Add(_clickInputs);
        triggerInputRegion.triggers.Add(_clickInputs);
        triggerMap1.triggers.Add(_clickInputs);
        triggerMap2.triggers.Add(_clickInputs);

        _gameType.onClick.AddListener(() => FmodExtensions.SetSfx(_btnHost));
        _newSession.onClick.AddListener(() => FmodExtensions.SetSfx(_btnHost));
        _closePanelSessionList.onClick.AddListener(() => FmodExtensions.SetSfx(_btnLeave));

        _removePlayer.onClick.AddListener(() => FmodExtensions.SetSfx(_btnHost));
        _addplayer.onClick.AddListener(() => FmodExtensions.SetSfx(_btnHost));
        _closePanelCreateGame.onClick.AddListener(() => FmodExtensions.SetSfx(_btnLeave));
        _createSession.onClick.AddListener(() => FmodExtensions.SetSfx(_btnHost));
    }
}
