using UnityEngine;

public class Discord_Changer : MonoBehaviour
{
    public string newDetails = "Playing";
    public string newState = "Currently in: Level 1";
    [Space]
    public string newLargeImage = "logo";
    public string newLargeText = "Pixel Platformer";

    void Start()
    {
        Discord_Controller discord = GameObject.Find("Manager.DiscordPresence").GetComponent<Discord_Controller>();

        discord.details = newDetails;
        discord.state = newState;

        discord.largeImage = newLargeImage;
        discord.largeText = newLargeText;
    }
}