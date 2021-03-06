﻿using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// Make the game run even when in background
		Application.runInBackground = true;
		//Debug.Log (Application.runInBackground);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private const string typeName = "UniqueGameName";
	private const string gameName = "RoomName";
	
	private void StartServer()
	{
		Network.InitializeServer(4, 25000, !Network.HavePublicAddress());
		MasterServer.RegisterHost(typeName, gameName);

		// Increase default send rate
		Network.sendRate = 60;
	}

	void OnServerInitialized()
	{
		Debug.Log("Server Initializied");
		SpawnPlayer();
	}

	void OnGUI()
	{
		if (!Network.isClient && !Network.isServer)
		{
			if (GUI.Button(new Rect(100, 100, 250, 100), "Start Server"))
				StartServer();
			
			if (GUI.Button(new Rect(100, 250, 250, 100), "Refresh Hosts"))
				RefreshHostList();
			
			if (hostList != null)
			{
				for (int i = 0; i < hostList.Length; i++)
				{
					if (GUI.Button(new Rect(400, 100 + (110 * i), 300, 100), hostList[i].gameName))
						JoinServer(hostList[i]);
				}
			}
		}
	}

	private HostData[] hostList;
	
	private void RefreshHostList()
	{
		MasterServer.RequestHostList(typeName);
	}
	
	void OnMasterServerEvent(MasterServerEvent msEvent)
	{
		if (msEvent == MasterServerEvent.HostListReceived)
			hostList = MasterServer.PollHostList();
	}

	private void JoinServer(HostData hostData)
	{
		Network.Connect(hostData);
	}
	
	void OnConnectedToServer()
	{
		Debug.Log("Server Joined");
		SpawnPlayer();
	}

	public GameObject playerPrefab;

	private void SpawnPlayer()
	{
		Network.Instantiate(playerPrefab, new Vector3(-130.8237f, -0.8719177f, -33.76096f), Quaternion.identity, 0);
	}
}
