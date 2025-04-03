using UnityEngine;
using UnityEngine.Events;


namespace Eloi.TimeSync
{

    public class PctTimeMono_ListenToStaticGameTimePercent: MonoBehaviour
{
    public double m_lastPercentReceived;
    public UnityEvent<double> m_onDoublePercentRelayed;

    public void OnEnable()
    {
        PctTime_StaticGameTimePercent.AddListener(OnPercentChanged);
    }
    public void OnDisable()
    {
        PctTime_StaticGameTimePercent.RemoveListener(OnPercentChanged);
    }
    private void OnPercentChanged(double percent01Changed)
    {
        m_lastPercentReceived = percent01Changed;
        m_onDoublePercentRelayed.Invoke(percent01Changed);
    }
}

}