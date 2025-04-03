using UnityEngine;

namespace Eloi.TimeSync
{
    public class PctTimeMono_PushToStaticNtpMillisecondsOffset : MonoBehaviour
    {
        public void SetOffsetInMilliseconds(long currentMillisecondsOffsetToServer)
        {
            PctTime_StaticNtpMillisecondsOffset.SetOffsetInMilliseconds(currentMillisecondsOffsetToServer);
        }
        public void SetOffsetInMilliseconds(ulong currentMillisecondsOffsetToServer)
        {
            PctTime_StaticNtpMillisecondsOffset.SetOffsetInMilliseconds( (long) currentMillisecondsOffsetToServer);
        }
        public void SetOffsetInMilliseconds(int currentMillisecondsOffsetToServer)
        {
            PctTime_StaticNtpMillisecondsOffset.SetOffsetInMilliseconds(currentMillisecondsOffsetToServer);
        }
    }
}
