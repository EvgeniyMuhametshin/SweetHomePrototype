using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoandingSceneWindowGame : MonoBehaviour
{
	private void Start()
	{
		StartCoroutine(Loanding());
	}

	IEnumerator Loanding()
	{
		yield return new WaitForSeconds(3);
		SceneManager.LoadScene(2);
	}
}