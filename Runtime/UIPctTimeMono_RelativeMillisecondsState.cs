using UnityEngine;
using UnityEngine.Events;
namespace Eloi.TimeSync
{

    public class UIPctTimeMono_RelativeMillisecondsState : MonoBehaviour
{

    public string m_textFormat = "{H}:{M}:{S},{MS}";
    public UnityEvent<string> m_onTextRelayed;

    public long m_lastRelativeMilliseconds;
    public void SetToRelativeMilliseconds(long relativeMilliseconds)
    {
        m_lastRelativeMilliseconds = relativeMilliseconds;
        int milliseconds = (int)(relativeMilliseconds % 1000);
        int seconds = (int)(relativeMilliseconds / 1000 % 60);
        int minutes = (int)(relativeMilliseconds / 1000 / 60 % 60);
        int hours = (int)(relativeMilliseconds / 1000 / 60 / 60);
        string t = m_textFormat.Replace("{H}", hours.ToString("D2"));
        t = t.Replace("{M}", minutes.ToString("D2"));
        t = t.Replace("{S}", seconds.ToString("D2"));
        t = t.Replace("{MS}", milliseconds.ToString("D3"));
        m_onTextRelayed.Invoke(t);
    }
}
}