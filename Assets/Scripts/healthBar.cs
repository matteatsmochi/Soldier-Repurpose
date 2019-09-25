using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class healthBar : MonoBehaviour
{
    
    public Image back, left, center, right;
    public Sprite r1, r2, r3, y1, y2, y3, g1, g2, g3, b1, b2, b3;
    public TMPro.TextMeshProUGUI usernameText;
    public string username;
    public GameObject character;
    Vector3 removed;
    newHealth health;
    float currentStamnia;
    float fullStamnia;
    float previousStamina;
    float firstFrame;

    void Awake()
    {
        GameObject p = gameObject.transform.parent.gameObject;
        character = p;
        GameObject canvas = GameObject.Find("HealthBarCanvas");
        gameObject.transform.SetParent(canvas.transform, false);
        
    }
    
    void Start()
    {
        //assign components
        health = character.GetComponent<newHealth>();
        firstFrame = 0;
    }

    void Update()
    {
        if (firstFrame == 1)
        {
            back.gameObject.SetActive(true);
            right.gameObject.SetActive(true);
            left.gameObject.SetActive(true);
            center.gameObject.SetActive(true);
            usernameText.gameObject.SetActive(true);
            back.DOFade(0.25f, 0.5f);
            right.DOFade(1, 0.5f);
            left.DOFade(1, 0.5f);
            center.DOFade(1, 0.5f);
            usernameText.text = username;
            firstFrame = 2;
        }
        else if (firstFrame == 0)
        {
            back.DOFade(0, 0);
            right.DOFade(0, 0);
            left.DOFade(0, 0);
            center.DOFade(0, 0);
            firstFrame = 1;
        }
        
        if (character)
        {
            Vector2 screenposition = Camera.main.WorldToScreenPoint(character.transform.position);
            transform.position = new Vector2(screenposition.x - 5, screenposition.y + 40);
            removed = character.transform.position;
        } else
        {
            Vector2 screenposition = Camera.main.WorldToScreenPoint(removed);
            transform.position = new Vector2(screenposition.x - 5, screenposition.y + 40);
        }
        
            currentStamnia = health.HP;
            fullStamnia = health.MaxHP;

        
        if (currentStamnia != previousStamina)
        {
            float prct = Mathf.Clamp(currentStamnia, 0, fullStamnia) /fullStamnia;

            if (prct == 1)
            {
                left.sprite = b1;
                center.sprite = b2;
                right.sprite = b3;
            } else if (prct > 0.5f)
            {
                left.sprite = g1;
                center.sprite = g2;
                right.sprite = g3;
            } else if (prct > 0.2f)
            {
                left.sprite = y1;
                center.sprite = y2;
                right.sprite = y3;
            } else
            {
                left.sprite = r1;
                center.sprite = r2;
                right.sprite = r3;
            }

            Sequence seq = DOTween.Sequence();
            seq.Append(center.rectTransform.DOSizeDelta(new Vector2(prct * 183.5f, center.rectTransform.sizeDelta.y), 1));
            seq.Join(right.rectTransform.DOAnchorPos(new Vector3((prct * 92) + 5.5f, 0, 0), 1));
            seq.SetEase(Ease.OutQuad);

            if (prct == 0){Destroy(gameObject, 1f);}
        }

        previousStamina = currentStamnia;
    }

    public float getHealth()
    {
        return health.HP;
    }

}
