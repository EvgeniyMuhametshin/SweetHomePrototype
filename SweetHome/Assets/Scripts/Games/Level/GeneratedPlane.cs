using UnityEngine;

public class GeneratedPlane : ILevel
{
	private GameObject _createdObject;

	public void CreatedObject()
	{
		_createdObject = (GameObject)Object.Instantiate(Resources.Load("Prefabs/Level/Plane"));
	}
}
