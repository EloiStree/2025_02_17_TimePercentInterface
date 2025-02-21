using UnityEngine;
using UnityEngine.Events;

public class UIPctTimeMono_NtpOffset : MonoBehaviour
{
    public string m_textFormat = "{0}";
    public UnityEvent<long> m_onMillisecondsLongRelayed;
    public UnityEvent<string> m_onMillisecondsTextRelayed;
    public long m_offsetInMilliseconds;
    public void SetTimeNtpOffset(long offsetInMilliseconds)
    {
        m_offsetInMilliseconds = offsetInMilliseconds;
        m_onMillisecondsLongRelayed.Invoke(offsetInMilliseconds);
        m_onMillisecondsTextRelayed.Invoke(string.Format(m_textFormat, offsetInMilliseconds));
    }
}