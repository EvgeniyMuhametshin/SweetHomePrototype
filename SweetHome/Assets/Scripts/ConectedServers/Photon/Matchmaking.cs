using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Realtime;

public class Matchmaking : IMatchmakingCallbacks
{
	public void OnCreatedRoom()
	{
		throw new System.NotImplementedException();
	}

	public void OnCreateRoomFailed(short returnCode, string message)
	{
		throw new System.NotImplementedException();
	}

	public void OnFriendListUpdate(List<FriendInfo> friendList)
	{
		throw new System.NotImplementedException();
	}

	public void OnJoinedRoom()
	{
		throw new System.NotImplementedException();
	}

	public void OnJoinRandomFailed(short returnCode, string message)
	{
		throw new System.NotImplementedException();
	}

	public void OnJoinRoomFailed(short returnCode, string message)
	{
		throw new System.NotImplementedException();
	}

	public void OnLeftRoom()
	{
		throw new System.NotImplementedException();
	}
}
