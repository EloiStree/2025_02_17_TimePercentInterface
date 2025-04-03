using UnityEngine;

namespace Eloi.TimeSync
{
    public class PctTimeMono_PushToStaticGameTimePercent : MonoBehaviour
    {
        public void PushPercent01(float percent)
        {
            PctTime_StaticGameTimePercent.SetPercent(percent);
        }
        public void PushPercent01(double percent)
        {
            PctTime_StaticGameTimePercent.SetPercent(percent);
        }
        public void PushPercent0100(int percent)
        {
            PctTime_StaticGameTimePercent.SetPercent(percent / 100.0);
        }
    }
}
