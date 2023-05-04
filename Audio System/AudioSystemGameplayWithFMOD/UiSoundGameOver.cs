using UnityEngine;
using UnityEngine.UI;

public class UiSoundGameOver : MonoBehaviour
{
    [SerializeField] private FMODUnity.EventReference _continue;
    [SerializeField] private Button _continueBtn;

    private void Start()
    {
        _continueBtn.onClick.AddListener(() => FmodExtensions.SetSfx(_continue));

    }
}
