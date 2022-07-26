using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;

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
		
		SetUserData(result.PlayFabId);
		//MakePurchase();
		GetInventory();
	}

	private void SetUserData(string playFabId)
	{
		PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest()
		{
			Data = new Dictionary<string, string>()
			{
				{ "time_receive_dayly_reward", DateTime.UtcNow.ToString()}
			}
		}, 
		result =>
		{
			Debug.Log("Complete User Data!!!");
			GetUserData(playFabId, "time_receive_dayly_reward");
		}, OnLoginFailure);
	}

	private void GetUserData(string playFabId, string keyData)
	{
		PlayFabClientAPI.GetUserData(new GetUserDataRequest()
		{
			PlayFabId = playFabId
		},
		result =>
		{
			Debug.Log($"{keyData}: {result.Data[keyData].Value}");
		}, OnLoginFailure);
	}

	private void OnLoginFailure(PlayFabError error)
	{
		var errorMessage = error.GenerateErrorReport();
		Debug.Log($"Ошибка: {errorMessage}");
	}

	private void MakePurchase()
	{
		PlayFabClientAPI.PurchaseItem(new PurchaseItemRequest()
		{
			CatalogVersion = "MainCatalog",
			ItemId = "health_potion",
			Price = 1000,
			VirtualCurrency = "CO",
		},
		result =>
		{
			Debug.Log($"Complete MakePurchase!!!");
		}, OnLoginFailure);
	}

	private void GetInventory()
	{
		PlayFabClientAPI.GetUserInventory(new GetUserInventoryRequest(),
			result => ShowInventory(result.Inventory), OnLoginFailure);
	}

	private void ShowInventory(List<ItemInstance> items)
	{
		var ferstItem = items.First();
		Debug.Log($"{ferstItem.ItemId}");
		ConsumePotion(ferstItem.ItemInstanceId);
	}

	private void ConsumePotion(string ItemInstanceId)
	{
		PlayFabClientAPI.ConsumeItem(new ConsumeItemRequest()
		{
			ConsumeCount = 1,
			ItemInstanceId = ItemInstanceId
		},
		result => Debug.Log("Complete ConsumePotion"), OnLoginFailure);
	}
}
