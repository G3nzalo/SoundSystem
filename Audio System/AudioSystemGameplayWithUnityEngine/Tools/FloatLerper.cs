using UnityEngine;

public class FloatLerper : AbstractLerper<float>
{
    #region CONSTRUCTORS
    public FloatLerper(float lerpTime, SMOOTH_TYPE smoothType = SMOOTH_TYPE.NONE) : base(lerpTime, smoothType) { }
    public FloatLerper(float start, float end, float lerpTime, SMOOTH_TYPE smoothType = SMOOTH_TYPE.NONE) : base(start, end, lerpTime, smoothType) { }
    #endregion

    #region OVERRIDE
    protected override void UpdateCurrentPosition(float perc)
    {
        CurrentValue = Mathf.Lerp(start, end, perc);
    }

    protected override bool CheckReached()
    {
        if (CurrentValue == end)
            return true;
        else
            return false;
    }
    #endregion
}