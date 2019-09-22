using System.Collections;
using UnityEngine;

public class bulletDestroy : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DestroyAfter3());
    }

    IEnumerator DestroyAfter3()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
