using UnityEngine;
using DG.Tweening;

public class cameraMenu : MonoBehaviour
{
    void Start()
    {
        transform.transform.DOMoveY(5, 10).SetEase(Ease.InOutQuad);
    }
}
