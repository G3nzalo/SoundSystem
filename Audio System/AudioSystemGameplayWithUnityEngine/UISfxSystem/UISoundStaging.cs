using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Fusion;

[RequireComponent(typeof(UnityEngine.EventSystems.EventTrigger))]
public class UISoundStaging : MonoBehaviour
{
    [SerializeField] private Button _startGame;
    [SerializeField] private AudioSource _startGameSource;

    [SerializeField] private Button _btnDisconnect;
    [SerializeField] private AudioSource _btnDisconnectSource;

    [SerializeField] private Button _btnReady;
    [SerializeField] private AudioSource _btnReadySource;

    //[SerializeField] private AudioSource _sourcebtnDisconnect;

    //[SerializeField] private AudioSource _sourcebtnReady;

    [SerializeField] private InputField _playerName;
    [SerializeField] private AudioSource _inputFieldsSfxSource;


    [SerializeField] private Slider [] _sliders;
    [SerializeField] private AudioFilesUi _files;

    EventTrigger.Entry _clickInputs = new EventTrigger.Entry();

    private void OnMouseClickInputFields(BaseEventData pointData) => PlaySfxBtn(_inputFieldsSfxSource);

    private void Awake()
    {
        SetSound(_startGameSource, 0);
        _startGame.onClick.AddListener(() => PlaySfxBtn(_startGameSource));

        SetSound(_btnDisconnectSource, 1);
        _btnDisconnect.onClick.AddListener(() => PlaySfxBtn(_btnDisconnectSource));

        SetSound(_btnReadySource, 2);
        _btnReady.onClick.AddListener(() => PlaySfxBtn(_btnReadySource));

        SetSound(_inputFieldsSfxSource, 3);

        _clickInputs.eventID = EventTriggerType.PointerClick;
        _clickInputs.callback = new EventTrigger.TriggerEvent();
        _clickInputs.callback.AddListener(OnMouseClickInputFields);

        EventTrigger _playerNameTrigger = _playerName.GetComponent<EventTrigger>();
        _playerNameTrigger.triggers.Add(_clickInputs);

        EventTrigger TriggerColorRed = _sliders[0].GetComponent<EventTrigger>();
        TriggerColorRed.triggers.Add(_clickInputs);

        EventTrigger TriggerColorGreen = _sliders[1].GetComponent<EventTrigger>();
        TriggerColorGreen.triggers.Add(_clickInputs);

        EventTrigger TriggerColorBlue = _sliders[2].GetComponent<EventTrigger>();
        TriggerColorBlue.triggers.Add(_clickInputs);
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
