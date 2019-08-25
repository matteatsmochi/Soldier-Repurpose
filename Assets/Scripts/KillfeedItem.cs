using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class KillfeedItem : MonoBehaviour
{
    public TextMeshProUGUI killerText;
    public TextMeshProUGUI killedText;
    RectTransform me;

    public void Setup(string killer, string killed)
    {
        me = GetComponent<RectTransform>();
        killerText.text = killer;
        killedText.text = killed;
        StartCoroutine(Remove());
    }

    IEnumerator Remove()
    {
        yield return new WaitForSeconds(3);
        me.DOScaleY(0, 0.33f);
        yield return new WaitForSeconds(0.33f);
        Destroy(gameObject);

    }
}
