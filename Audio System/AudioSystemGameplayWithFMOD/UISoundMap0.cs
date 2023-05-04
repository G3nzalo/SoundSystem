using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UISoundMap0 : MonoBehaviour
{
    [SerializeField] private FMODUnity.EventReference _btnLeave;
    [SerializeField] private Button _gameOver;
    [SerializeField] private Button _diconnect;

    private void Start()
    {
        _gameOver.onClick.AddListener(() => SetReturnMenu());
        _diconnect.onClick.AddListener(() => SetReturnMenu());
    }

    private void SetReturnMenu()
    {
        FmodExtensions.SetSfx(_btnLeave);
        MusicManager.instance.SetZoneMusic(MusicManager.ZONES.MENU);
    }
}
