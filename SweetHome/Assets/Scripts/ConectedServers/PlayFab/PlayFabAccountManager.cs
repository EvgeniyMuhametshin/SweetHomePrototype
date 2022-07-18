using PlayFab;
using PlayFab.ClientModels;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayFabAccountManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _titleLabel;

	private void Start()
	{
		PlayFabClientAPI.GetAccountInfo(new GetAccountInfoRequest(),
			OnGetAccount, OnError);
		PlayFabClientAPI.GetCatalogItems(new GetCatalogItemsRequest(),
			OnGetCatalog, OnError);
	}

	private void OnGetCatalog(GetCatalogItemsResult result)
	{
		ShowCatalog(result.Catalog);
		Debug.Log($"OnGetCatalog complete!!!");
	}

	private void ShowCatalog(List<CatalogItem> items)
	{
		foreach (var item in items)
		{
			Debug.Log($"Item: {item.ItemId} complete!!!");
		}
	}

	private void OnGetAccount(GetAccountInfoResult result)
	{
		_titleLabel.text = $"User: {result.AccountInfo.PlayFabId}\n" +
			$"Create data: {result.AccountInfo.Created}\n" +
			$"Private info: {result.AccountInfo.PrivateInfo}\n" +
			$"Custom data: {result.CustomData}\n" +
			$"Title info: {result.AccountInfo.TitleInfo}";
	}

	private void OnError(PlayFabError error)
	{
		var errorMessage = error.GenerateErrorReport();
		Debug.Log($"Error: {errorMessage}");
	}
}