using UnityEngine;
using UnityEngine.Events;
namespace Eloi.TimeSync
{

    public class PctTimeMono_GameTimeInSecondsToPercent : MonoBehaviour
{
    public UnityEvent<double> m_onPercentChanged;
    public double m_secondsToComplete = 30f;
    [Range(0,1)]
    public float m_currentPercent = 0f;
    void Update()
    {
        double percent = Time.time / m_secondsToComplete;
        percent = percent % 1.0f;
        m_currentPercent = (float)percent;
        m_onPercentChanged.Invoke(percent);
    }
}
}