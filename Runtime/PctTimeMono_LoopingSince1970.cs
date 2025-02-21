using System;
using UnityEngine;
using UnityEngine.Events;



public class PctTimeMono_LoopingSince1970 : MonoBehaviour
{


 
    public long m_loopTimeInMilliseconds = 30000;
    [Tooltip("That is the official offset of a NTP server to sync the time")]
    public long m_ntpOffsetMilliseconds;

    [Tooltip("It allows to offset the start of the game.")]
    public long m_startOffsetAdjustementInMilliseconds;

    public long m_millisecondsSince1970;
    public long m_secondsSince1970;
    public int m_secondRandomFromSeed;
    public long m_relativeTimeInMilliseconds;
    public long m_relativeTimeInSeconds;
    [Range(0,1)]
    public double m_relativePercent;

    public UnityEvent<double> m_onPercentChanged;
    public UnityEvent<long> m_onRelativeMillisecondsChanged;
    public UnityEvent<long> m_onRelativeSecondsChanged;
    public UnityEvent m_onArriving;
    public UnityEvent m_onRestart;


    public void GetCurrentNtpSeconds(out long seconds)
    {
        seconds= GetTimeNowUtcOffsetAsMilliseconds()/1000;
    }

    public  void GetRandomBasedOnCurrentSeconds( out int random, int nextIteration=0)
    {
        long seconds = GetTimeNowUtcOffsetAsMilliseconds() / 1000L;
        GetRandomBasedOnSeconds(seconds, out random, nextIteration);
    }
    public static void GetRandomBasedOnSeconds(long seconds, out int random, int nextIteration = 0)
    {
        int seed = (int)seconds;
        System.Random r = new System.Random(seed);
        random = r.Next();
        for (int i = 0; i < nextIteration; i++)
           random = r.Next();
    }

    private void Start()
    {
        m_onArriving.Invoke();
    }

    public void SetNtpOffsetToTimer(long offset)
    {
        m_ntpOffsetMilliseconds = offset;
    }
    public void SetStartOffsetAdjustement(long startOffsetAdjustement)
    {
        m_startOffsetAdjustementInMilliseconds = startOffsetAdjustement;
    }


    public void Update()
    {
        long previousSecondsTime = m_relativeTimeInSeconds;
        double previousPercent = m_relativePercent;
        m_millisecondsSince1970 = GetTimeNowUtcOffsetAsMilliseconds();
        if (m_loopTimeInMilliseconds == 0)
            m_loopTimeInMilliseconds = 22 * 60 * 1000;
        m_secondsSince1970 = m_millisecondsSince1970 / 1000;
        m_relativeTimeInMilliseconds = m_millisecondsSince1970 % m_loopTimeInMilliseconds;
        m_relativeTimeInSeconds = m_relativeTimeInMilliseconds / 1000;
        m_onRelativeMillisecondsChanged.Invoke(m_relativeTimeInMilliseconds);
        m_relativePercent = ((double)m_relativeTimeInMilliseconds) / ((double)m_loopTimeInMilliseconds);
        if (previousSecondsTime != m_relativeTimeInSeconds)
        {
            m_onRelativeSecondsChanged.Invoke(m_relativeTimeInSeconds);
        }


        if (m_relativePercent < previousPercent)
        {
            m_onRestart.Invoke();
        }
        m_onPercentChanged.Invoke(m_relativePercent);

        GetRandomBasedOnCurrentSeconds(out m_secondRandomFromSeed);
    }
    private long GetTimeNowUtcOffsetAsMilliseconds()
    {
        long now = DateTime.UtcNow.Ticks / TimeSpan.TicksPerMillisecond;
        long start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Ticks / TimeSpan.TicksPerMillisecond;
        return (now - start) + (m_ntpOffsetMilliseconds+ m_startOffsetAdjustementInMilliseconds);
    }
}
