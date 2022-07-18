using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoandingGameSceneWindow : MonoBehaviour
{
	private void Start()
	{
		StartCoroutine(Loading());
	}

	IEnumerator Loading()
	{
		yield return new WaitForSeconds(3);
		SceneManager.LoadScene(2);
	}
}