using UnityEngine;

public class SfxTriggerUi : MonoBehaviour
{
    public void PlaySfx() => PlaySfxBtn();
    private void PlaySfxBtn() =>  FmodExtensions.SetSfx("event:/Sounds/UI/Continue");
}
