using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoinCounter : MonoBehaviour {

    private int coinNumber;
    private Text coinText;

    // Use this for initialization
    void Start () {
        coinNumber = 0;
        coinText = transform.FindChild ("CoinNumber").GetComponent<Text>();
    }
    
    // Update is called once per frame
    void Update () {
    
    }

    //Increases Coins by one and updates the text
    public void Add(){
        coinNumber++;
        coinText.text = "x " + coinNumber;
    }

    // Static function, that calls the Add function
    public static void AddCoin(){
        GameObject.Find ("CoinPanel").GetComponent<CoinCounter>().Add();
    }

    public static int GetCoinNumber()
    {
        return GameObject.Find("CoinPanel").GetComponent<CoinCounter>().coinNumber;
    } 
}
