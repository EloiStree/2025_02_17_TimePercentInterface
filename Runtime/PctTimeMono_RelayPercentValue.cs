using UnityEngine;
using UnityEngine.Events;

public class PctTimeMono_RelayPercentValue : MonoBehaviour, I_PercentHandler
{
    [Range(0.0f, 1.0f)]
    public double m_lastPercentReceived;
    public UnityEvent<double> m_onDoublePercentRelayed;
    public UnityEvent<float> m_onFloatPercentRelayed;
    public void SetToRelativeMilliseconds(double percent)
    {
        m_lastPercentReceived = percent;
        m_onDoublePercentRelayed.Invoke(percent);
        m_onFloatPercentRelayed.Invoke((float)percent);

    }

    public bool m_useOnValidate = true;
    public void OnValidate()
    {
        if (m_useOnValidate)
        {
            SetToRelativeMilliseconds(m_lastPercentReceived);
        }
    }
    [ContextMenu("Push Current Value")]
    public void PushCurrentInspectorValue()
    {
        SetToRelativeMilliseconds(m_lastPercentReceived);
    }
}
