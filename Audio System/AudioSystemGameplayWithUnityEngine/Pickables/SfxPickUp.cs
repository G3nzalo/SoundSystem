using UnityEngine;
using static SkillAbility;

public abstract class SfxPickUp : MonoBehaviour
{

    public void PlaySfx(SKILL_TYPE type = SKILL_TYPE.typeless)
    {
        CheckViewport(type);
    }

    private void CheckViewport(SKILL_TYPE type)
    {
        var viewportPoint = Camera.main.WorldToViewportPoint(transform.position);

        if (viewportPoint.x <= 0.98f && viewportPoint.x >= 0.03f && viewportPoint.y <= 0.98f && viewportPoint.y >= 0.03f)
        {
            Play(type);
        }
    }

    protected abstract void Play(SKILL_TYPE type);
}