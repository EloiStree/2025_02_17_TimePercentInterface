using UnityEngine;
using UnityEngine.Events;

public class PctTimeMono_GenerateRandomFromSecondsSeed : MonoBehaviour
{
    public long randomFromSeed;
    public int m_currentSeconds;

    public RandomSequene[] m_sequences = new RandomSequene[] {

        new RandomSequene(){ m_secondsModulo=1},
        new RandomSequene(){ m_secondsModulo=5},
        new RandomSequene(){ m_secondsModulo=10}
    }; 

    public void PushInTimeStampSeconds(long seconds)
    {

        PushInTimeStampSeconds((int)seconds);
    }
    public void PushInTimeStampSeconds(int seconds)
    {
       foreach (var sequence in m_sequences)
        {
            if (sequence != null) { 
                sequence.PushInTimeStampSeconds(seconds);
            }
        }
    }

    [System.Serializable]
    public class RandomSequene
    {
        public int m_currentSeconds;
        public int m_secondsModulo = 5;

        public Color m_randomColor;
        public int m_randomInteger;
        public float m_randomFloat;

        public UnityEvent<float> m_onRandomFloatGenerated;
        public UnityEvent<int> m_onRandomIntegerGenerated;
        public UnityEvent<Color> m_onRandomColorGenerated;
        public void PushInTimeStampSeconds(int seconds)
        {
            if (m_currentSeconds == seconds)
                return;
            m_currentSeconds = seconds;
            if (m_currentSeconds % m_secondsModulo != 0)
                return;

            System.Random r = new System.Random(seconds);
            float red = r.Next(0, 255) / 255f;
            float green = r.Next(0, 255) / 255f;
            float blue = r.Next(0, 255) / 255f;
            Color color = new Color(red, green, blue);
            m_randomColor = color;
            m_randomFloat = (float)r.NextDouble();
            m_randomInteger = r.Next();

            m_onRandomColorGenerated.Invoke(m_randomColor);
            m_onRandomFloatGenerated.Invoke(m_randomFloat);
            m_onRandomIntegerGenerated.Invoke(m_randomInteger);

        }
    }
}