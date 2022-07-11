using UnityEngine;

public class ExecutantCharacter : MonoBehaviour
{
    ExecutantPlayer executantPlayer;
    
    void Start()
    {
        executantPlayer = new ExecutantPlayer();
        executantPlayer.Start();
    }

    void Update()
    {
        executantPlayer.Update();
    }
}
