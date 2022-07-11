using UnityEngine;

public class GeneratedPlane : ILevel
{
	private GameObject _createdObject;

	//TODO Переход на второй уровень
	public void CreatedObject()
	{
		_createdObject = (GameObject)Object.Instantiate(Resources.Load("Prefabs/Level/Plane"));
		_createdObject.AddComponent<MeshCollider>();
		_createdObject.tag = "Level";
		_createdObject.layer = 6;
		_createdObject.GetComponent<SpriteRenderer>().sortingOrder = 0;
		Debug.Log("First Level!!!");
	}
	//TODO Удаление первого уровня и генерация второго уровня
}
