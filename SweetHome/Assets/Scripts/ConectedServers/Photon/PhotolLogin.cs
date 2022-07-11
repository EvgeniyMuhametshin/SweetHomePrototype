using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.IO;

public class PhotolLogin : MonoBehaviourPunCallbacks
{
	private void Awake()
	{
		PhotonNetwork.AutomaticallySyncScene = true;
	}

	private void Start()
	{
		Connect();
	}

	private void Connect()
	{
		if (!PhotonNetwork.IsConnected)
		{
			PhotonNetwork.ConnectUsingSettings();
			PhotonNetwork.GameVersion = Application.version;
		}
	}

	public void Disconect()
	{
		PhotonNetwork.Disconnect();
		string messageLog = DisconnectedMessage();
		Log(messageLog);
	}

	public void Log(string message)
	{
		File.AppendAllText("log.txt", message);
	}

	public string DisconnectedMessage()
	{
		return "Server Disconected";
	}

	public override void OnConnectedToMaster()
	{
		Debug.Log("OnConnectedToMaster");
		PhotonNetwork.JoinLobby();
	}

	public override void OnJoinedLobby()
	{
		Debug.Log($"OnJoinedLobby: {PhotonNetwork.InLobby}");
		PhotonNetwork.JoinOrCreateRoom("join name", new RoomOptions { MaxPlayers = 2, 
			IsVisible = true}, TypedLobby.Default);
	}

	public override void OnJoinedRoom()
	{
		Debug.Log($"OnJoinedRoom: {PhotonNetwork.InRoom}");
	}
}
