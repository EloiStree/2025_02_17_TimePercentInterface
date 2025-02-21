using UnityEngine;
using UnityEngine.Events;

public class UIPctTimeMono_Timestamp: MonoBehaviour
{
    public long m_lastTimestampInMilliseconds;
    public long m_lastTimestampInSeconds;
    public string m_textFormatMilliseconds = "{0} MS";
    public string m_textFormatSeconds = "{0} S";
    [Header("Milliseconds")]
    public UnityEvent<long> m_onTimestampMillisecondsRelayed;
    public UnityEvent<string> m_onTimestampMillisecondsTextRelayed;
    [Header("Seconds")]
    public UnityEvent<long> m_onTimestampSecondRelayed;
    public UnityEvent<string> m_onTimestampSecondTextRelayed;

    public void SetToTimestampInMilliseconds(long timestampInMilliseconds)
    {
        m_lastTimestampInMilliseconds = timestampInMilliseconds;
        m_onTimestampMillisecondsRelayed.Invoke(timestampInMilliseconds);
        m_onTimestampMillisecondsTextRelayed.Invoke(string.Format(m_textFormatMilliseconds, timestampInMilliseconds));
        long seconds = timestampInMilliseconds / 1000;
        m_lastTimestampInSeconds = seconds;
        m_onTimestampSecondRelayed.Invoke(seconds);
        m_onTimestampSecondTextRelayed.Invoke(string.Format(m_textFormatSeconds, seconds));
    }
}