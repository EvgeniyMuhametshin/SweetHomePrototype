using UnityEngine;

public class GeneratedLevel : MonoBehaviour
{
	ILevel _generatedLevel;
	//TODO ����� �������� ��� ���������
	private void Start()
	{
		_generatedLevel = new GeneratedPlane();
		_generatedLevel.CreatedObject();
		_generatedLevel = new GeneratedWalls();
		_generatedLevel.CreatedObject();
	}
	//TODO ��������� ��� ��������� � GlobalBuilder
}
