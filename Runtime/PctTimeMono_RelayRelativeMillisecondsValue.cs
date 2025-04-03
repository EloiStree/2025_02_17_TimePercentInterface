using UnityEngine;
using UnityEngine.Events;
namespace Eloi.TimeSync
{

    public class PctTimeMono_RelayRelativeMillisecondsValue : MonoBehaviour
{
    public long m_lastRelativeMilliseconds;
    public UnityEvent<long> m_onRelativeMillisecondsRelayed;
    public UnityEvent<long> m_onRelativeSecondsRelayed;

    private long m_seconds = 0;
    public void SetToRelativeMilliseconds(long relativeMilliseconds)
    {
        m_lastRelativeMilliseconds = relativeMilliseconds;
        m_onRelativeMillisecondsRelayed.Invoke(relativeMilliseconds);
        long seconds = relativeMilliseconds / 1000;
        if (seconds != m_seconds)
        {
            m_seconds = seconds;
            m_onRelativeSecondsRelayed.Invoke(m_seconds);
        }
    }

    public bool m_useOnValidate = true;
    public void OnValidate()
    {
        if (m_useOnValidate)
        {
            SetToRelativeMilliseconds(m_lastRelativeMilliseconds);
        }
    }
    [ContextMenu("Push Current Value")]
    public void PushCurrentInspectorValue()
    {
        SetToRelativeMilliseconds(m_lastRelativeMilliseconds);
    }
}
}