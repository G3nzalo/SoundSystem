using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(UnityEngine.EventSystems.EventTrigger))]
public class UISoundIntro : MonoBehaviour
{
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

    [SerializeField] private AudioSource _inputFieldsSfxSource;
    [SerializeField] private AudioSource _createSessionSource;
    [SerializeField] private AudioSource _closePanelCreateGameSource;
    [SerializeField] private AudioFilesUi _files;

    private EventTrigger.Entry _clickInputs = new EventTrigger.Entry();

    private void OnMouseClickInputFields(BaseEventData pointData) => PlaySfxBtn(_inputFieldsSfxSource);

    private void Awake()
    {
        SetSound(_closePanelCreateGameSource, 1);
        SetSound(_createSessionSource, 2);
        SetSound(_inputFieldsSfxSource, 3);

        EventTrigger triggerInputFieldRoomName = _roomName.GetComponent<EventTrigger>();
        EventTrigger triggerInputRegion = _regionGame.GetComponent<EventTrigger>();

        EventTrigger triggerMap1 = _map1.GetComponent<EventTrigger>();
        EventTrigger triggerMap2 = _map2.GetComponent<EventTrigger>();

        _clickInputs.eventID = EventTriggerType.PointerClick;
        _clickInputs.callback = new EventTrigger.TriggerEvent();
        _clickInputs.callback.AddListener(OnMouseClickInputFields);

        triggerInputFieldRoomName.triggers.Add(_clickInputs);
        triggerInputRegion.triggers.Add(_clickInputs);
        triggerMap1.triggers.Add(_clickInputs);
        triggerMap2.triggers.Add(_clickInputs);

        _gameType.onClick.AddListener(() => PlaySfxBtn(_createSessionSource));
        _newSession.onClick.AddListener(() => PlaySfxBtn(_createSessionSource));
        _closePanelSessionList.onClick.AddListener(() => PlaySfxBtn(_closePanelCreateGameSource));
        _removePlayer.onClick.AddListener(() => PlaySfxBtn(_inputFieldsSfxSource));
        _addplayer.onClick.AddListener(() => PlaySfxBtn(_inputFieldsSfxSource));
        _createSession.onClick.AddListener(() => PlaySfxBtn(_createSessionSource));
        _closePanelCreateGame.onClick.AddListener(() => PlaySfxBtn(_closePanelCreateGameSource));
    }

    private void SetSound(AudioSource source, int index) => source.clip = _files.audioFiles[index];

    private void PlaySfxBtn(AudioSource source)
    {
            SetRandPitch(source);
            source.Play();
    }

    private void SetRandPitch(AudioSource source)
    {
        var rand = UnityEngine.Random.Range(0.95f, 1.05f);
        source.pitch = rand;
    }
}