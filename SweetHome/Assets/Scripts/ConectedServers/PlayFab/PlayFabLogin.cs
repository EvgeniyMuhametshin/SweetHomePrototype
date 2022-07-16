using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using System;

public class PlayFabLogin : MonoBehaviour
{
	/// <summary>
	/// номер id 7E723
	/// </summary>
	[SerializeField] private string _enterNumberID;
	[SerializeField] private InputField _InputField;
	[SerializeField] private Image _imageColor;

	private string _textId;
	
	public void EnterId()
	{
		_textId = _InputField.text;
	}

	private const string AuthGuidKey = "auth_guid";

	public void ConectedServer()
	{
		if (_textId == _enterNumberID)
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
			PlayFabSettings.staticSettings.TitleId = _textId;
		}

		var needCreation = PlayerPrefs.HasKey(AuthGuidKey);
		var id = PlayerPrefs.GetString(AuthGuidKey, 
			Guid.NewGuid().ToString());

		var request = new LoginWithCustomIDRequest()
		{
			CustomId = id,
			CreateAccount = !needCreation,
		};

		PlayFabClientAPI.LoginWithCustomID(request, 
			success =>
			{
				PlayerPrefs.SetString(AuthGuidKey, id);
				OnLoginSuccess(success);
			}, 
			OnLoginFailure);
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
