using System;


namespace Eloi.TimeSync
{
    public class PctTime_StaticGameTimePercent
{

    private static double m_currentGamePercentTime;
    private static Action<double> m_onPercentTimeChanged;
    public static void AddListener(Action<double> listener)
    {
        m_onPercentTimeChanged += listener;
    }
    public static void RemoveListener(Action<double> listener)
    {
        m_onPercentTimeChanged -= listener;
    }
    public static void SetPercent(double percent)
    {

        if (percent < 0.0)
            percent = 0.0;
        if (percent > 1.0)
            percent = 1.0;
        m_currentGamePercentTime = percent;
        m_onPercentTimeChanged?.Invoke(percent);
    }

    public static double GetPercent()
    {
        return m_currentGamePercentTime;
    }
    public static void GetPercent(out double percent)
    {
        percent = m_currentGamePercentTime;
    }

}

    public class PctTime_StaticNtpMillisecondsOffset
    {

        private static long m_currentMillisecondsOffsetToServer;
        private static Action<long> m_onMillisecondsOffsetChanged;
        public static void AddListener(Action<long> listener)
        {
            m_onMillisecondsOffsetChanged += listener;
        }
        public static void RemoveListener(Action<long> listener)
        {
            m_onMillisecondsOffsetChanged -= listener;
        }
        public static void SetOffsetInMilliseconds(long currentMillisecondsOffsetToServer)
        {

            m_currentMillisecondsOffsetToServer = currentMillisecondsOffsetToServer;
            m_onMillisecondsOffsetChanged?.Invoke(currentMillisecondsOffsetToServer);
        }

        public static double GetMillisecondsOffsetToServer()
        {
            return m_currentMillisecondsOffsetToServer;
        }
        public static void GetMillisecondsOffsetToServer(out double currentMillisecondsOffsetToServer)
        {
            currentMillisecondsOffsetToServer = m_currentMillisecondsOffsetToServer;
        }

    }


}