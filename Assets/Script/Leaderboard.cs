using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Assets.Models;
using RestSharp;
using Unity3dAzure.AppServices;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour {

    private GameObject _panel;

    private MobileServiceClient _client;
    private MobileServiceTable<Player> _table;

    private Text _content;
    private string _leaderboard;

    // Use this for initialization
    void Start () {
        _panel = transform.FindChild("LeaderboardPanel").gameObject;

        _client = new MobileServiceClient("http://unityplatformer.azurewebsites.net/"); // <- add your app url here.
        _table = _client.GetTable<Player>("Player");

        _content = _panel.transform.FindChild("Image").transform.FindChild("Scroll View").transform.FindChild("Viewport").transform.FindChild("Content").GetComponent<Text>();

        Read();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    private void TurnOn()
    {
        _content.text = _leaderboard;
        _panel.SetActive(true);
        Time.timeScale = 0f;
    }

    private void Read()
    {
        _table.Read<Player>(OnReadCompleted);
    }

    private void OnReadCompleted(IRestResponse<List<Player>> response)
    {
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var players = response.Data;
            players.Sort((first, second) => second.Coins - first.Coins);
            _leaderboard = "";
            var i = 1;
            foreach (var player in players)
            {
                _leaderboard += i++ + ". " + player.Name + "\t" + player.Coins + "\n";
            }
        }

        else
        {
            Debug.Log("Read Error Status:" + response.StatusCode + " Uri: " + response.ResponseUri);
        }

    }

    public static void Show()
    {
        GameObject.Find("Leaderboard").GetComponent<Leaderboard>().TurnOn();
    }

    public void Close()
    {
        _panel.SetActive(false);
    }
}
