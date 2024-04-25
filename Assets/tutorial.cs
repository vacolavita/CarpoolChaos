using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tutorial : MonoBehaviour
{

    public int progress = 0;
    public TextMeshProUGUI textMeshProUGUI;
    public TextMeshProUGUI buttonText;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void progression(int i){
        if (progress == 15 && i == 1) {
            Loader.Load(Loader.Scene.LevelSelect);
        }
        progress = Mathf.Clamp(progress+i, 0, 15);
    }

    // Update is called once per frame
    void Update()
    {
        if (progress == 0) {
            textMeshProUGUI.text = "Welcome to Carpool Chaos! Team up with a friend to become the best ride-share drivers you can be!";
        }
        if (progress == 1)
        {
            textMeshProUGUI.text = "Use WASD or the Left Stick to drive your vehicle.";
        }
        if (progress == 2)
        {
            textMeshProUGUI.text = "Passengers will spawn in the yellow circles. Drive up to them to pick them up!";
        }
        if (progress == 3)
        {
            textMeshProUGUI.text = "Passengers come in three colors: Green, red, and blue!";
        }
        if (progress == 4)
        {
            textMeshProUGUI.text = "There are three circles of the same colors on each stage. Get the passengers to the corresponding destination to score!";
        }
        if (progress == 5)
        {
            textMeshProUGUI.text = "Press the Spacebar or Gamepad East to launch passengers from your vehicle! Passengers can be launched over short walls. Coordinate with your teammate to find more efficient routes.";
        }
        if (progress == 6)
        {
            textMeshProUGUI.text = "If you have multiple colors of passengers in your vehicle, use the N and M keys or L and R buttons to scroll through colors. The selected color will be the color you launch.";
        }
        if (progress == 7)
        {
            textMeshProUGUI.text = "You can also press the V key or Gamepad South to drop the selected color of passenger.";
        }
        if (progress == 8)
        {
            textMeshProUGUI.text = "As you drive, your fuel will slowly drain. If it runs out, you will move much slower, and can't launch passengers! Drive to the Gas Station to refill!";
        }
        if (progress == 9)
        {
            textMeshProUGUI.text = "You may find an Item Bag on the ground. Pick it up to get an Item!";
        }
        if (progress == 10)
        {
            textMeshProUGUI.text = "Press the B key or Gamepad North to use your Item! There are four Items in total: Boost Pads, Jump Pads, Gas Cans, and Tents.";
        }
        if (progress == 11)
        {
            textMeshProUGUI.text = "Boost Pad: Deploy it for a boost of speed! It sticks around for a while before disappearing.";
        }
        if (progress == 12)
        {
            textMeshProUGUI.text = "Jump Pad: Deploy it to get air time, letting you jump over short walls! It also sticks around for a while.";
        }
        if (progress == 13)
        {
            textMeshProUGUI.text = "Gas Can: Deploy it to launch a Gas Can in front of you, which can be picked up to restore some fuel!";
        }
        if (progress == 14)
        {
            textMeshProUGUI.text = "Tent: Deploy it to create a new destination to score passengers. The color is random, so be careful! It will disappear after a few seconds.";
        }
        if (progress == 15)
        {
            textMeshProUGUI.text = "Now work together, and get those people where they need to be!";
            buttonText.text = "Return";
        }
        else {
            buttonText.text = "Next";
        }
    }
}
