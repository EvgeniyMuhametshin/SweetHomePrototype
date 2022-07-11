using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class PlayFabLogin : MonoBehaviour
{
	/// <summary>
	/// номер id 7E723
	/// </summary>
	[SerializeField] private string _enterNumberID;
	[SerializeField] private InputField _InputField;
	[SerializeField] private Image _imageColor;

	private string textId;
	
	public void EnterId()
	{
		textId = _InputField.text;
	}

	public void ConectedServer()
	{
		if (textId == _enterNumberID)
		{
			Debug.Log("Соединение с сервером: загружаем");
			_imageColor.color = Color.green;
		}
		else
		{
			Debug.Log("Неверный логин, повторите");
			_imageColor.color = Color.red;
		}

		if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId))
		{
			PlayFabSettings.staticSettings.TitleId = textId;
		}

		var request = new LoginWithCustomIDRequest()
		{
			CustomId = "Player One",
			CreateAccount = true,
		};

		PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess,
			OnLoginFailure);
	}

	public void DisconectedServer()
	{

	}


	private void OnLoginSuccess(LoginResult result)
	{
		Debug.Log("Соединение с сервером: ОК");
	}

	private void OnLoginFailure(PlayFabError error)
	{
		var errorMessage = error.GenerateErrorReport();
		Debug.Log($"Ошибка: {errorMessage}");
	}

}
