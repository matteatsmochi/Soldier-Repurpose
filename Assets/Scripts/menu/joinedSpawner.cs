using UnityEngine;

public class joinedSpawner : MonoBehaviour
{
    public GameObject prefab;

    public void PlayerJoined(string player)
    {
        GameObject newBubble = Instantiate(prefab, gameObject.transform.position, Quaternion.identity);
        newBubble.GetComponent<joinedFloat>().SetText(player);
        newBubble.transform.SetParent(gameObject.transform);
    }
}
