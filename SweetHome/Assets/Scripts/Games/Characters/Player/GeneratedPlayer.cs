using UnityEngine;

public class GeneratedPlayer : IPlayer
{
	private ActionsPlayer _actionsPlayer;
    private GameObject _gameObject;

	public void CreatedObject()
	{
		_gameObject = (GameObject)Object.Instantiate(Resources.Load("Prefabs/Characters/Player/Player"));
		_gameObject.tag = "Player";
		_gameObject.layer = 3;
		_gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
		_gameObject.AddComponent<BoxCollider2D>();

		_actionsPlayer = new ActionsPlayer();
	}

	private float _speedPlayerMove = 5f;

	public void Update()
	{
		_actionsPlayer.Move(_gameObject.GetComponent<BoxCollider2D>(), KeyCode.A, KeyCode.D, KeyCode.W, 
			KeyCode.S, _speedPlayerMove);
	}
}
