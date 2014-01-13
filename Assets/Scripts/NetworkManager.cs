using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour
{
    public GameObject player;
    private string gameName = "Saschas Spiel";
	
    
    void Start()
    {
        Application.runInBackground = true;
        RefreshHostList();
    }
    
    private void RefreshHostList()
    {
        MasterServer.ClearHostList();
        MasterServer.RequestHostList("de.gamemaker.net-test.ctf");
    }
    
	void OnGUI()
    {
        switch(Network.peerType)
        {
            case NetworkPeerType.Disconnected:
                gameName = GUILayout.TextField(gameName);
                if(GUILayout.Button("Host Game"))
                {
                    Network.InitializeServer(32, 25000, !Network.HavePublicAddress());
                    MasterServer.RegisterHost("de.gamemaker.net-test.ctf", gameName, "MOTD");
                }
                
                if(GUILayout.Button("Refresh"))
                {
                    RefreshHostList();
                }
                
                var hostData = MasterServer.PollHostList();
                foreach(var host in hostData)
                {
                    if(GUILayout.Button(host.gameName))
                    {
                        Network.Connect(host);
                    }
                }
                break;
                
            case NetworkPeerType.Server:
                if(GUILayout.Button("Close Server"))
                {
                    Network.Disconnect();
                    MasterServer.UnregisterHost();
                }
                break;
                
            case NetworkPeerType.Client:
                if(GUILayout.Button("Disconnect"))
                {
                    Network.Disconnect();
                    Application.LoadLevel(Application.loadedLevel);
                }
                break;
                
            case NetworkPeerType.Connecting:
                GUILayout.Label("Connecting...");
                break;
        }
	}
    
	void OnApplicationQuit()
    {
        if(Network.peerType == NetworkPeerType.Server)
        {
            Network.Disconnect();
            MasterServer.UnregisterHost();
        }
	}
    
    void OnConnectedToServer()
    {
        SpawnPlayer();
    }
    
    void OnServerInitialized()
    {
        SpawnPlayer();
    }
    
    private void SpawnPlayer()
    {
        Network.Instantiate(player, transform.position, Quaternion.identity, 0);
    }
    
    void OnPlayerDisconnected(NetworkPlayer player)
    {
        Network.RemoveRPCs(player);
        Network.DestroyPlayerObjects(player);
    }
    
    void OnDisconnectedFromServer(NetworkDisconnection info)
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}















