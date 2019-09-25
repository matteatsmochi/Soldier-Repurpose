using UnityEngine;
using TMPro;

public class AlivePlayerCount : MonoBehaviour
{
    public TextMeshProUGUI alivePlayers;

    public void SetPlayerCount(string players)
    {
        alivePlayers.text = players;
    }
}
