using UnityEngine;

public class GeneratedWalls : ILevel
{
	private GameObject _createdObject;

	//TODO ���������� ������� �����, �������� ������� ����� �� ��� X = 3
	public void CreatedObject()
	{
		//TODO ������� � ��������� ����� �������� ������� (������� ������ ������� � ������� ������������)
		_createdObject = (GameObject)Object.Instantiate(Resources.Load("Prefabs/Walls/Walls"));
		_createdObject.AddComponent<BoxCollider2D>();
		_createdObject.GetComponent<BoxCollider2D>().size = new Vector3(20,30,0);
	}
}
