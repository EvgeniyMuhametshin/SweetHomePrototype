using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalBuilder : MonoBehaviour
{
    GeneratedLevel generatedLevel;
    
    void Start()
    {
        generatedLevel = new GeneratedLevel();
        generatedLevel.Start();
    }
}
