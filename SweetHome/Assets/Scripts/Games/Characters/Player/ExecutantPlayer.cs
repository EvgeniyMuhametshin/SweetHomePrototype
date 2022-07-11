using UnityEngine;

public class ExecutantPlayer 
{
	IPlayer _player;

    public void Start()
	{
		_player = new GeneratedPlayer();
		_player.CreatedObject();
	}

	public void Update()
	{
		_player.Update();
	}
}
