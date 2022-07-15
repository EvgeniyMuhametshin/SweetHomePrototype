using PlayFab;
using PlayFab.ClientModels;
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