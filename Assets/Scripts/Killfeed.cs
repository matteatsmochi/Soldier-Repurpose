using UnityEngine;

public class Killfeed : MonoBehaviour
{
    public GameObject killfeedPrefab;
    
    public void SpawnKillfeedItem(string killer, string killed)
    {
        GameObject k = Instantiate(killfeedPrefab, this.transform);
        k.GetComponent<KillfeedItem>().Setup(killer, killed);
    }
}
