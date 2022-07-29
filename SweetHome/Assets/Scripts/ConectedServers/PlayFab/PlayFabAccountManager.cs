using PlayFab;
using PlayFab.ClientModels;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayFabAccountManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _titleLabel;

	[SerializeField]
	private GameObject _newCharacterCreatePanel;

	[SerializeField]
	private Button _creatCharacterButton;

	[SerializeField]
	private TMP_InputField _inputField;

	[SerializeField]
	private List<SlotCharacterWidged> _slots;

	private string _characterName;

	private void Start()
	{
		PlayFabClientAPI.GetAccountInfo(new GetAccountInfoRequest(),
			OnGetAccount, OnError);
		PlayFabClientAPI.GetCatalogItems(new GetCatalogItemsRequest(),
			OnGetCatalog, OnError);

		GetChacters();

		foreach (var slot in _slots)
		{
			slot.Button.onClick.AddListener(OpenCreateNewCharacter);
		}

		_creatCharacterButton.onClick.AddListener(CreateCharacterWithItem);

		_inputField.onValueChanged.AddListener(OnNameChanged);
	}

	private void CreateCharacterWithItem()
	{
		PlayFabClientAPI.GrantCharacterToUser(new GrantCharacterToUserRequest()
		{
			CharacterName = _characterName,
			ItemId = "character_item"
		}, result => 
		{
			UpdateCharacterStatisticsRequest(result.CharacterId);
		}, OnError);
	}

	private void UpdateCharacterStatisticsRequest(string characterId)
	{
		PlayFabClientAPI.UpdateCharacterStatistics(new UpdateCharacterStatisticsRequest()
		{
			CharacterId = characterId,
			CharacterStatistics = new Dictionary<string, int>()
			{
				{ "Level", 1 },
				{ "Gold", 0}
			}
		}, result =>
		{
			Debug.Log("UpdateCharacterStatistics complete!!!");
			CloseCreateNewCharacter();
			GetChacters();
		}, OnError);
	}

	private void GetChacters()
	{
		PlayFabClientAPI.GetAllUsersCharacters(new ListUsersCharactersRequest(),
			result =>
			{
				Debug.Log($"Character count: {result.Characters.Count}");
				ShowCharacterInSlot(result.Characters);
			}, OnError);
	}

	private void ShowCharacterInSlot(List<CharacterResult> characters)
	{
		if (characters.Count == 0)
		{
			foreach (var slot in _slots)
			{
				slot.ShowEmptySlot();
			}
		}
		else if (characters.Count > 0 && characters.Count <= _slots.Count)
		{
			PlayFabClientAPI.GetCharacterStatistics(new GetCharacterStatisticsRequest()
			{
				CharacterId = characters.First().CharacterId
			}, result =>
			{
				var level = result.CharacterStatistics["Level"].ToString();
				var gold = result.CharacterStatistics["Gold"].ToString();

				_slots.First().ShowInfoCharacterSlot(characters.First().CharacterName, level, gold);
			}, OnError);
		}
		else
		{
			Debug.LogError("Added slots of characters");
		}
	}

	private void OpenCreateNewCharacter()
	{
		_newCharacterCreatePanel.SetActive(true);
	}
	
	private void CloseCreateNewCharacter()
	{
		_newCharacterCreatePanel.SetActive(false);
	}

	private void OnNameChanged(string changedName)
	{
		_characterName = changedName;
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