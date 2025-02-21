using UnityEngine;
using UnityEngine.Events;

public class Experiment_SeeTheFuturGameplay : MonoBehaviour
{
    public long randomFromSeed;
    public int m_currentSeconds;
    public int m_secondsModulo = 5;

    public Renderer[] m_rendererToAffect;

    public void PushInTimeStampSeconds(long seconds) { 
    
        PushInTimeStampSeconds((int)seconds);
    }
    public void PushInTimeStampSeconds(int seconds)
    {
        if(m_currentSeconds==seconds)
            return;
        m_currentSeconds = seconds;
        if (m_currentSeconds % m_secondsModulo != 0)
            return;

        System.Random r = new System.Random(seconds);
        float red = r.Next(0,255)/255f;
        float green = r.Next(0, 255) / 255f;
        float blue = r.Next(0, 255) / 255f;
        Color color = new Color(red, green, blue);
        foreach (var renderer in m_rendererToAffect)
        {
            renderer.material.color = color;
        }

    }
}
