using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using DG.Tweening;
using TMPro;

public class HUDConroller : MonoBehaviour
{
    RectTransform rect;

    public RawImage rawImage;
    public Image botImage;
    public Sprite botSprite;
    public TextMeshProUGUI hudUser;
    public TextMeshProUGUI hudKills;
    public healthBar health;

    string v5oauth = "4gtxvf2ngeivqbvfrauvbv133ckot0";

    int currentPlayerIndex;
    
    void Start()
    {
        rect = gameObject.GetComponent<RectTransform>();
        HUDOff();
    }

    public void NewPlayerHUD(string username, string userID, int kills, int index)
    {
        if (currentPlayerIndex != index)
        {
            HUDOff();
            StartCoroutine(NewPlayerTime(username, userID, kills));
            currentPlayerIndex = index;
        }

    }

    
    void HUDOn()
    {
        rect.DOMoveX(640, 1f);
    }

    void HUDOff()
    {
        rect.DOMoveX(0, 0.4f);
    }

    IEnumerator NewPlayerTime(string username, string userID, int kills)
    {
        yield return new WaitForSeconds(1);
        SetPlayer(username, userID, kills);
        HUDOn();
    }



    void SetPlayer(string username, string userID, int kills)
    {
        hudUser.text = username;
        hudKills.text = "Kills: " + kills;

        if (float.Parse(userID) == 0)
        {
            botImage.gameObject.SetActive(true);
            rawImage.gameObject.SetActive(false);
            botImage.sprite = botSprite;
        }
        else
        {
            rawImage.gameObject.SetActive(true);
            botImage.gameObject.SetActive(false);
            StartCoroutine(GetRequest("https://api.twitch.tv/kraken/users/" + userID + "?api_version=5&oauth_token=" + v5oauth));
        }
        
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                ParseHTML(webRequest.downloadHandler.text);
            }
        }
    }

    void ParseHTML(string html)
    {
        string h = html;
        int FirstCharacter = h.IndexOf("http");
        if (FirstCharacter != -1)
        {
            h = h.Substring(FirstCharacter, h.Length - FirstCharacter);
            int SecondCharacter = h.IndexOf("\"");
            if (SecondCharacter != -1)
            {
                h = h.Substring(0, SecondCharacter);
            }
        }
        StartCoroutine(LoadFromURL(h));
    }

    IEnumerator LoadFromURL(string url)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();

        if(www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        }
        else {
            Texture myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            rawImage.texture = myTexture;
        }
    }

    public void NewKill(int killerIndex, int kills)
    {
        if (killerIndex == currentPlayerIndex)
        {
            hudKills.text = "Kills: " + kills;
        }
    }
}
