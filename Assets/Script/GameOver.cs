using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Assets.Models;
using Unity3dAzure.AppServices;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    private GameObject panel;
    private InputField _playerName;

    private MobileServiceClient _client;
    private MobileServiceTable<Player> _table;

    // Use this for initialization
    void Start () {
        panel = transform.FindChild ("GameOverPanel").gameObject;
        _playerName = panel.transform.FindChild("Image").transform.FindChild("Player").GetComponent<InputField>();

        _client = new MobileServiceClient("http://unityplatformer.azurewebsites.net/"); // <- add your app url here.
        _table = _client.GetTable<Player>("Player");

    }

    // Update is called once per frame
    void Update () {
        
    }

    public void turnOn(){
        panel.SetActive (true);
        Time.timeScale = 0f;
    }

    public static void gameOver(){
        GameObject.Find ("GameOver").GetComponent<GameOver> ().turnOn ();
    }

    public void Restart()
    {
        if (_playerName.text != "")
        {
            InsertPlayer();
            // Loads the scene by its name or index in Build Settings. 
            SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void Quit(){
        if (_playerName.text != "")
        {
            InsertPlayer();
            // Quits the player application.
            Application.Quit();
        }
    }

    private void InsertPlayer()
    {
        // Inserting the player data to the app service
        _table.Insert(new Player { Name = _playerName.text, Coins = CoinCounter.GetCoinNumber() });
    }
}
