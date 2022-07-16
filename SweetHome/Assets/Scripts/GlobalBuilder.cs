using UnityEngine;

public class GlobalBuilder : MonoBehaviour
{
    void Start()
    {
        GeneratedLevel generatedLevel = new GeneratedLevel();
        generatedLevel.Start();
    }
}
