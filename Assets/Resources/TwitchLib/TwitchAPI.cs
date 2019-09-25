using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.IO;
using UnityEngine;
using TwitchLib.Unity;
using TwitchLib.Client;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Events;
using TwitchLib.Client.Extensions;
using TwitchLib.Client.Models;
using TwitchLib.PubSub;

public class TwitchAPI : MonoBehaviour
{
    static TwitchAPI Instance;

    Client client;
    TwitchPubSub pubsub;

    public string Channel;

    public menuManager menu;

    void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }

        Application.runInBackground = true;

        client = new Client();
        pubsub = new TwitchPubSub();

    }


    public void AssignChannel(string c)
    {
        Channel = c.ToLower();
    }


    #region "Twitch"

    public void ConnectToTwitchChat()
    {
        if (Channel != "" || Channel != null)
        {
            ConnectionCredentials credentials = new ConnectionCredentials("chatroyalebot", "4gtxvf2ngeivqbvfrauvbv133ckot0");
            client.Initialize(credentials, Channel);

            client.OnConnected += onConnected;
            client.OnMessageReceived += globalChatMessageRecieved;
            client.OnDisconnected += onDisconnected;

            if (!client.IsConnected)
            {
                client.Connect();
            }

            Debug.Log("<< Connecting >>");

            pubsub.Connect();
        }
    }

    void DisconnectFromTwitchChat()
    {
        client.LeaveChannel(client.JoinedChannels[0]);
        if (client.IsConnected)
        {
            client.Disconnect();
        }
        Debug.Log("<< Disconnecting . . . >>");
    }

    void onConnected(object sender, TwitchLib.Client.Events.OnConnectedArgs e)
    {

        Debug.Log("<< Connected >>");
    }

    public void onDisconnected(object sender, TwitchLib.Client.Events.OnDisconnectedArgs e)

    {
        Debug.Log("<< Disconnected from chat server >>");
    }
    

        void globalChatMessageRecieved(object sender, TwitchLib.Client.Events.OnMessageReceivedArgs e)
    {
        Debug.Log(e.ChatMessage.Username + ": " + e.ChatMessage.Message);
        string MESSAGE = e.ChatMessage.Message;

        if (MESSAGE.StartsWith("!join"))
        {
            
            menu.AddPlayer(e.ChatMessage.DisplayName, e.ChatMessage.UserId);
        }

    }

    void onWhisperReceived(object sender, OnWhisperReceivedArgs e)
    {
        if (e.WhisperMessage.Username == "my_friend")
            client.SendWhisper(e.WhisperMessage.Username, "Hey! Whispers are so cool!!");
    }

    void onNewSubscriber(object sender, OnNewSubscriberArgs e)
    {
        //if (e.Subscriber.SubscriptionPlan == SubscriptionPlan.Prime)
        //    client.SendMessage(e.Channel, $"Welcome {e.Subscriber.DisplayName} So kind of you to use your Twitch Prime on this channel!");
        //else
        //    client.SendMessage(e.Channel, $"Welcome {e.Subscriber.DisplayName} to the substers!");
    }

    #region "PubSub"
    void Pubsub_OnPubSubServiceConnected(object sender, System.EventArgs e)
    {
        //pubsub.ListenToWhispers("Channel_Id");
    }

    void Pubsub_OnListenResponse(object sender, TwitchLib.PubSub.Events.OnListenResponseArgs e)
    {
        
    }

    void Pubsub_OnBitsReceived(object sender, TwitchLib.PubSub.Events.OnBitsReceivedArgs e)
    {
        Debug.Log($"Just received {e.BitsUsed} bits from {e.Username}. That brings their total to {e.TotalBitsUsed} bits!");
    }
    #endregion
    
    public void SendMsg(string msg)
    {
        client.SendMessage(client.JoinedChannels[0], msg);
    }

    #endregion

    
    
}
