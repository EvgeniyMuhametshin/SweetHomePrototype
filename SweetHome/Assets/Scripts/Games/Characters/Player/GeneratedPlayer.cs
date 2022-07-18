using UnityEngine;

public class GeneratedPlayer : IPlayer
{
	private ActionsPlayer _actionsPlayer;
    private GameObject _gameObject;

	private GameObject _camera;

	public void CreatedObject()
	{
		_gameObject = (GameObject)Object.Instantiate(Resources.Load("Prefabs/Characters/Player/Player"));
		_gameObject.tag = "Player";
		_gameObject.layer = 3;
		_gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
		_gameObject.AddComponent<Rigidbody2D>();
		_gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
		_gameObject.GetComponent<Transform>().position = new Vector3(0,0,0);
		_gameObject.AddComponent<BoxCollider2D>();
		Debug.Log($"Player: {_gameObject.transform.position}");

		_actionsPlayer = new ActionsPlayer();

		//TODO Вынести камеру в отдельный класс
		#region Camera
		_camera = (GameObject)Object.Instantiate(Resources.Load("Prefabs/Characters/Player/Camera"));
		_camera.AddComponent<Camera>();
		_camera.tag = "CameraPlayer";
		_camera.GetComponent<Camera>().orthographic = true;
		_camera.GetComponent<Transform>().position = new Vector3(0,0,-10);
		_camera.transform.SetParent(_gameObject.transform);
		Debug.Log($"Camera: {_camera.transform.position}");
		#endregion
	}

	private float _speedPlayerMove = 5f;

	public void Update()
	{
		_actionsPlayer.Move(_gameObject.GetComponent<BoxCollider2D>(), KeyCode.A, KeyCode.D, KeyCode.W, 
			KeyCode.S, _speedPlayerMove);
	}
}
