using System.Collections;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class joinedFloat : MonoBehaviour
{
    public TextMeshProUGUI bubbleText;
    RectTransform pos;
    float X;

    void Start()
    {
        X = 0;
        pos = gameObject.GetComponent<RectTransform>();
        pos.DOMoveY(200, 2.5f).SetEase(Ease.InOutQuad);
        StartCoroutine(FadeOut());
        SideToSide();
    }

    public void SetText(string txt)
    {
        bubbleText.text = txt + " joined";
    }

    void SideToSide()
    {
        float change = Random.Range(-100, 100);
        pos.DOAnchorPosX(X + change, 1.5f).SetEase(Ease.InOutQuad).OnComplete(SideToSide);

        X += change;
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(2.5f);
        pos.DOScale(0, 0.25f);
        yield return new WaitForSeconds(0.25f);
        Destroy(gameObject);
    }
}
