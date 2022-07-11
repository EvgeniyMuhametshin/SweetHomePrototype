using UnityEngine;

public class ActionsPlayer 
{
	private Collider2D _colliderObject;

    public void Move(Collider2D colliderObject, KeyCode left, KeyCode right, KeyCode forward, KeyCode back, float speedMove)
	{
		_colliderObject = colliderObject;

		if (Input.GetKey(forward))
		{
			_colliderObject.transform.position = _colliderObject.transform.position + Vector3.up * speedMove * Time.deltaTime;
		}
		if (Input.GetKey(back))
		{
			_colliderObject.transform.position = _colliderObject.transform.position + Vector3.down * speedMove * Time.deltaTime;
		}
		if (Input.GetKey(left))
		{
			_colliderObject.transform.position = _colliderObject.transform.position + Vector3.left * speedMove * Time.deltaTime;
		}
		if (Input.GetKey(right))
		{
			_colliderObject.transform.position = _colliderObject.transform.position + Vector3.right * speedMove * Time.deltaTime;
		}
	}
}
