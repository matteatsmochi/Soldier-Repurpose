using UnityEngine;

public class joinedSpawner : MonoBehaviour
{
    public GameObject prefab;

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GameObject newBubble = Instantiate(prefab, gameObject.transform.position, Quaternion.identity);
            newBubble.GetComponent<joinedFloat>().SetText("Dark Side");
            newBubble.transform.SetParent(gameObject.transform);

        }
    }
}
