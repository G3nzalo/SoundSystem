using UnityEngine;

public abstract class AbstractLerper<T>
{
    #region PROTECTED FIELDS
    protected T start;
    protected T end;

    protected float lerpTime;
    protected float currentLerpTime;

    protected SMOOTH_TYPE smoothType;
    #endregion

    #region ENUMS
    public enum SMOOTH_TYPE { NONE, EASE_IN, EASE_OUT, EXPONENTIAL, STEP_SMOOTH, STEP_SMOOTHER }
    #endregion

    #region PROPERTIES
    public T CurrentValue { get; protected set; }
    public bool On { get; private set; }
    public bool Reached { get; private set; }
    #endregion

    #region CONSTRUCTORS
    public AbstractLerper(float lerpTime, SMOOTH_TYPE smoothType = SMOOTH_TYPE.NONE)
    {
        this.lerpTime = lerpTime;
        this.smoothType = smoothType;
        Reached = false;
    }

    public AbstractLerper(T start, T end, float lerpTime, SMOOTH_TYPE smoothType = SMOOTH_TYPE.NONE)
    {
        this.start = start;
        this.end = end;
        this.lerpTime = lerpTime;
        this.smoothType = smoothType;
        Reached = false;
    }
    #endregion

    #region PUBLIC METHODS
    public void Update()
    {
        if (!On)
            return;

        currentLerpTime += Time.deltaTime;
        if (currentLerpTime > lerpTime)
        {
            currentLerpTime = lerpTime;
        }

        float perc = currentLerpTime / lerpTime;
        perc = SmoothLerp(perc, smoothType);

        UpdateCurrentPosition(perc);
        if (CheckReached())
        {
            Reached = true;
            SwitchState(false);
        }
    }

    public void SetValues(T start, T end, bool on = false)
    {
        this.start = start;
        this.end = end;
        On = on;
        Reset();
    }

    public void SwitchState(bool on)
    {
        On = on;
    }

    public void SetLerpTime(float time)
    {
        lerpTime = time;
    }
    #endregion

    #region PROTECTED METHODS
    protected abstract void UpdateCurrentPosition(float perc);

    protected abstract bool CheckReached();

    protected void Reset()
    {
        currentLerpTime = 0.0f;
        Reached = false;
    }

    protected float SmoothLerp(float value, SMOOTH_TYPE mode)
    {
        float smooth = value;

        switch (mode)
        {
            case SMOOTH_TYPE.NONE:
                break;
            case SMOOTH_TYPE.EASE_IN:
                smooth = 1f - Mathf.Cos(value * Mathf.PI * 0.5f);
                break;
            case SMOOTH_TYPE.EASE_OUT:
                smooth = Mathf.Sin(value * Mathf.PI * 0.5f);
                break;
            case SMOOTH_TYPE.EXPONENTIAL:
                smooth = value * value;
                break;
            case SMOOTH_TYPE.STEP_SMOOTH:
                smooth = value * value * (3f - 2f * value);
                break;
            case SMOOTH_TYPE.STEP_SMOOTHER:
                smooth = value * value * value * (value * (6f * value - 15f) + 10f);
                break;
        }

        return smooth;
    }
    #endregion
}
