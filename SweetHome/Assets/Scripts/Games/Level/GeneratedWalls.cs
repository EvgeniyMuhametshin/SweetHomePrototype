using UnityEngine;

public class GeneratedWalls : ILevel
{
	private GameObject _createdObject;

	public void CreatedObject()
	{
		CreatedWalls(-10,0,0,0);
		CreatedWalls(10,0,0,0);
		CreatedWalls(0,15,0,90);
		CreatedWalls(0,-15,0,90);
	}

	private void CreatedWalls(int positionX, int positionY, int positionZ, int rotations)
	{
		_createdObject = (GameObject)Object.Instantiate(Resources.Load("Prefabs/Walls/Walls"));
		_createdObject.AddComponent<BoxCollider2D>();
		_createdObject.GetComponent<BoxCollider2D>().size = new Vector3(2, 31, 0);
		_createdObject.GetComponent<Transform>().position = new Vector3(positionX, positionY, positionZ);
		_createdObject.GetComponent<Transform>().rotation = Quaternion.Euler(0,0, rotations);
		_createdObject.tag = "Walls";
		_createdObject.layer = 6;
		_createdObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
	}
}
