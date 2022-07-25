using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using ExitGames.Client.Photon;
using System.Linq;

public class ConectedOnJoinRandomLobi : MonoBehaviour, IConnectionCallbacks, IMatchmakingCallbacks, ILobbyCallbacks
{

	[SerializeField]
	private ServerSettings _serverSettings;

	[SerializeField]
	private TMP_Text _stateUiText;

	private LoadBalancingClient _lbc;

	private const string AI_KEY = "ai";
	private const string PLAYERS_KEY = "rp";

	private const string EXP_KEY = "C0";
	private const string MAP_KEY = "C1";

	private TypedLobby _sqlLobby = new TypedLobby("sqlLobby",
		LobbyType.SqlLobby);

	private void Start()
	{
		_lbc = new LoadBalancingClient();
		_lbc.AddCallbackTarget(this);

		_lbc.ConnectUsingSettings(_serverSettings.AppSettings);
	}

	public void OnConnected()
	{
		_lbc.RemoveCallbackTarget(this);
	}

	private void Update()
	{
		if (_lbc == null)
		{
			return;
		}

		_lbc.Service();

		var state = _lbc.State.ToString();
		_stateUiText.text = $"State {state}, user id {_lbc.UserId}" +
			$"\nRooms count: {_lbc.RoomsCount}";
	}

	public void OnConnectedToMaster()
	{
		Debug.Log("On Conected To Master");

		var roomOptions = new RoomOptions()
		{
			MaxPlayers = 4,
			IsVisible = true,
			CustomRoomPropertiesForLobby = new[] { AI_KEY, MAP_KEY },
			CustomRoomProperties = new ExitGames.Client.Photon.Hashtable { { EXP_KEY, 400 },
				{ MAP_KEY, "Map3"}}
		};

		var enterParams = new EnterRoomParams()
		{
			RoomName = "NewRoom",
			RoomOptions = roomOptions,
			ExpectedUsers = new[] { "2dsa2132as2" },
			Lobby = _sqlLobby,
		};
		_lbc.OpCreateRoom(enterParams);

		_lbc.OpJoinRandomRoom();
	}

	public void OnCreatedRoom()
	{
		
	}

	public void OnCreateRoomFailed(short returnCode, string message)
	{
		
	}

	public void OnCustomAuthenticationFailed(string debugMessage)
	{
		
	}

	public void OnCustomAuthenticationResponse(Dictionary<string, object> data)
	{
		
	}

	public void OnDisconnected(DisconnectCause cause)
	{
		
	}

	public void OnFriendListUpdate(List<FriendInfo> friendList)
	{
		
	}

	public void OnJoinedLobby()
	{
		var sqlLobbyFilter = $"{EXP_KEY} BETWEEN 300 AND 500" +
			$"AND {MAP_KEY} = 'Map3'";

		var opJoinRoomParams = new OpJoinRandomRoomParams()
		{
			SqlLobbyFilter = sqlLobbyFilter
		};

		_lbc.OpJoinRandomRoom(opJoinRoomParams);
	}

	public void OnJoinedRoom()
	{
		Debug.Log("On Join Room");
	}

	public void OnJoinRandomFailed(short returnCode, string message)
	{
		Debug.Log("On Join Random Failed");
	}

	public void OnJoinRoomFailed(short returnCode, string message)
	{
		
	}

	public void OnLeftLobby()
	{
		
	}

	public void OnLeftRoom()
	{
		
	}

	public void OnLobbyStatisticsUpdate(List<TypedLobbyInfo> lobbyStatistics)
	{
		
	}

	public void OnRegionListReceived(RegionHandler regionHandler)
	{
		
	}

	public void OnRoomListUpdate(List<RoomInfo> roomList)
	{
		
	}
}
