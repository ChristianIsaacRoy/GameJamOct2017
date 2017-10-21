using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCommands : MonoBehaviour {

    public Text mainText;
    public Text candyCountText;
    public Text capacityIncreaseText;
    public Text defenseIncreaseText;
    public Text speedIncreaseText;

    public Button capacityButton;
    public Button defenseButton;
    public Button speedButton;
    public Button nextLevel;

    private int playerCapacity;
    private int playerDefense;
    private int playerSpeed;
    private int playerCandy;

    private int capacityCost;
    private int defenseCost;
    private int speedCost;
    private int capacityIncrease;
    private int defenseIncrease;
    private int speedIncrease;

	// Use this for initialization
	void Start () {



        playerCapacity = 10;
        playerDefense = 10;
        playerSpeed = 10;

        playerCandy = 20;

        capacityCost = 5;
        defenseCost = 5;
        speedCost = 5;
        capacityIncrease = 2;
        defenseIncrease = 2;
        speedIncrease = 2;

        candyCountText.supportRichText = true;
        capacityIncreaseText.supportRichText = true;
        defenseIncreaseText.supportRichText = true;
        speedIncreaseText.supportRichText = true;

        candyCountText.text = "Candy: <b><color=green>" + playerCandy.ToString() + "</color></b>";
        capacityIncreaseText.text = "Cost: <color=red>" + capacityCost.ToString() + "</color>\n<color=blue>" + playerCapacity.ToString() + "</color><color=black> -> </color><color=green>" + (playerCapacity + 2).ToString() + "</color>";
        defenseIncreaseText.text = "Cost: <color=red>" + defenseCost.ToString() + "</color>\n<color=blue>" + playerDefense.ToString() + "</color><color=black> -> </color><color=green>" + (playerDefense + 2).ToString() + "</color>";
        speedIncreaseText.text = "Cost: <color=red>" + speedCost.ToString() + "</color>\n<color=blue>" + playerSpeed.ToString() + "</color><color=black> -> </color><color=green>" + (playerSpeed + 2).ToString() + "</color>";

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void IncreaseStat(string stat)
    {
        switch (stat) {

            case ("capacity"):
                //Player.increaseStats("Capacity");
                if (playerCandy >= capacityCost)
                {
                    playerCapacity += capacityIncrease;
                    playerCandy -= capacityCost;
                    candyCountText.text = "Candy: <b><color=green>" + playerCandy.ToString() + "</color></b>";
                    capacityIncreaseText.text = "Cost: <color=red>" + capacityCost.ToString() + "</color>\n<color=blue>" + playerCapacity.ToString() + "</color><color=black> -> </color><color=green>" + (playerCapacity + 2).ToString() + "</color>";
                    mainText.text = "Mmmm, it's always better to carry more candy!";
                } else
                {
                    mainText.text = "You can't do that kid! Go get some more candy first!";
                }
                break;

            case ("defense"):
                //Player.increaseStats("Defense");
                if (playerCandy >= capacityCost)
                {
                    playerDefense += defenseIncrease;
                    playerCandy -= defenseCost;
                    candyCountText.text = "Candy: <b><color=green>" + playerCandy.ToString() + "</color></b>";
                    defenseIncreaseText.text = "Cost: <color=red>" + defenseCost.ToString() + "</color>\n<color=blue>" + playerDefense.ToString() + "</color><color=black> -> </color><color=green>" + (playerDefense + 2).ToString() + "</color>";
                    mainText.text = "Defend that candy to the death!!!";
                } else
                {
                    mainText.text = "You can't do that kid! Go get some more candy first!";
                }
        break;

            case ("speed"):
                //Player.increaseStats("Speed");
                if (playerCandy >= capacityCost)
                {
                    playerSpeed += speedIncrease;
                    playerCandy -= speedCost;
                    candyCountText.text = "Candy: <b><color=green>" + playerCandy.ToString() + "</color></b>";
                    speedIncreaseText.text = "Cost: <color=red>" + speedCost.ToString() + "</color>\n<color=blue>" + playerSpeed.ToString() + "</color><color=black> -> </color><color=green>" + (playerSpeed + 2).ToString() + "</color>";
                    mainText.text = "Gotta Go Fast!!!!!";
                }
                else
                {
                    mainText.text = "You can't do that kid! Go get some more candy first!";
                }
                break;
        }

    }

    public void LoadNextLevel()
    {
        //GameManager.NextLevel();
    }

}
