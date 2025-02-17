using System;
using UnityEngine;
using UnityEngine.Events;

public class PctTimeMono_LoopingSince1970 : MonoBehaviour
{

    public long m_loopTimeInMilliseconds = 30000;
    public long m_ntpOffsetMilliseconds;

    public long m_millisecondsSince1970;
    public long m_secondsSince1970;
    public long m_relativeTimeInMilliseconds;
    [Range(0,1)]
    public double m_relativePercent;

    public UnityEvent<double> m_onPercentChanged;
    public UnityEvent<long> m_onRelativeMillisecondsChanged;
    public UnityEvent m_onArriving;
    public UnityEvent m_onRestart;

    private void Start()
    {
        m_onArriving.Invoke();
    }

    public void SetTimeOffset(long offset)
    {
        m_ntpOffsetMilliseconds = offset;
    }

    public void Update()
    {
        double previousPercent = m_relativePercent;
        m_millisecondsSince1970 = GetTimeNowUtcOffsetAsMilliseconds();
        if (m_loopTimeInMilliseconds == 0)
            m_loopTimeInMilliseconds = 22 * 60 * 1000;
        m_secondsSince1970 = m_millisecondsSince1970 / 1000;
        m_relativeTimeInMilliseconds = m_millisecondsSince1970 % m_loopTimeInMilliseconds;
        m_onRelativeMillisecondsChanged.Invoke(m_relativeTimeInMilliseconds);
        double percent = ((double)m_relativeTimeInMilliseconds) / ((double)m_loopTimeInMilliseconds);

        if (percent < previousPercent)
        {
            m_onRestart.Invoke();
        }
        m_onPercentChanged.Invoke(percent);
    }

    private long GetTimeNowUtcOffsetAsMilliseconds()
    {
        long now = DateTime.UtcNow.Ticks / TimeSpan.TicksPerMillisecond;
        long start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Ticks / TimeSpan.TicksPerMillisecond;
        return (now - start) + m_ntpOffsetMilliseconds;
    }
}
