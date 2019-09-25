using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class gameStarting : MonoBehaviour
{
    
    void Start()
    {
        Up();
        StartCoroutine(KillMe());
    }

    void Up()
    {
        transform.transform.DOMoveY(10, 2).SetEase(Ease.InOutQuad).OnComplete(Down);
    }

    void Down()
    {
        transform.transform.DOMoveY(8, 2).SetEase(Ease.InOutQuad).OnComplete(Up);
    }

    IEnumerator KillMe()
    {
        yield return new WaitForSeconds(20);
        transform.transform.DOScale(0, 1f);
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

     
}
