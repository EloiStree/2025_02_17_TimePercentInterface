using UnityEngine;
using UnityEngine.Events;

public class PctTimeMono_ScaleCurveToSize : MonoBehaviour, I_PercentHandler
{
    public Transform m_whatToLocalScale;
    public float m_multiplicator = 1;
    public AnimationCurve m_scaleCurve = AnimationCurve.Linear(0, 0, 1, 1);
    [Range(0, 1)]
    public double m_percent = 0f;

    public bool m_useOnValiddate = true;

    public void Reset()
    {
        m_whatToLocalScale = transform;
    }
    public void OnValidate()
    {
        if (m_useOnValiddate)
        {
            SetToPercent(m_percent);
        }
    }
    public void SetToPercent(double percent)
    {
        m_percent = percent;
        if (m_whatToLocalScale == null)
        {
            return;
        }
        m_whatToLocalScale.localScale = Vector3.one * m_scaleCurve.Evaluate((float)percent) * m_multiplicator;
    }
}
