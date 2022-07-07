using UnityEngine;

public class GeneratedWalls : ILevel
{
	private GameObject _createdObject;

	//TODO Установить позицию стены, изменить размеры стены по оси X = 3
	public void CreatedObject()
	{
		//TODO Вынести в отдельный метод Создание объекта (Создать четыре объекта с разными координатами)
		_createdObject = (GameObject)Object.Instantiate(Resources.Load("Prefabs/Walls/Walls"));
		_createdObject.AddComponent<BoxCollider2D>();
		_createdObject.GetComponent<BoxCollider2D>().size = new Vector3(20,30,0);
	}
}
