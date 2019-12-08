
using UnityEngine;

public class Need : MonoBehaviour
{

    public float value = 0;
    public float incrementPerHour = 10;
    public string needName = "Need";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float deltaTimeInSeconds = Time.deltaTime;
        float deltaTimeInHours = deltaTimeInSeconds / 3600;

        float currentFrameIncrement = incrementPerHour * deltaTimeInHours;

        value += currentFrameIncrement;
    }
}
