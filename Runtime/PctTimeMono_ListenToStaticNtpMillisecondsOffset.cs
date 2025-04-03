using UnityEngine;
using UnityEngine.Events;


namespace Eloi.TimeSync
{
    public class PctTimeMono_ListenToStaticNtpMillisecondsOffset : MonoBehaviour
    {
        public long m_lastMillisecondsOffsetToServerReceived;
        public UnityEvent<long> m_onMillisecondsOffsetToServerChanged;

        public void OnEnable()
        {
            PctTime_StaticNtpMillisecondsOffset.AddListener(OnNtpOffsetInMillisecondsChanged);
        }
        public void OnDisable()
        {
            PctTime_StaticNtpMillisecondsOffset.RemoveListener(OnNtpOffsetInMillisecondsChanged);
        }
        private void OnNtpOffsetInMillisecondsChanged(long millisecondsOffsetToServer)
        {
            m_lastMillisecondsOffsetToServerReceived = millisecondsOffsetToServer;
            m_onMillisecondsOffsetToServerChanged.Invoke(millisecondsOffsetToServer);
        }
    }

}