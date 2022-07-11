using UnityEngine;

public class GeneratedLevel 
{
	ILevel _generatedLevel;
	public void Start()
	{
		_generatedLevel = new GeneratedPlane();
		_generatedLevel.CreatedObject();
		_generatedLevel = new GeneratedWalls();
		_generatedLevel.CreatedObject();
	}
}
