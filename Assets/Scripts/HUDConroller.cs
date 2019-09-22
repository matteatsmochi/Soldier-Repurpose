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

    public RawImage thisImage;
    public TextMeshProUGUI hudUser;

    string v5oauth = "4gtxvf2ngeivqbvfrauvbv133ckot0";

    int currentPlayerIndex;
    
    void Start()
    {
        rect = gameObject.GetComponent<RectTransform>();
        HUDOff();
    }

    public void NewPlayerHUG(string username, string userID, int index)
    {
        HUDOff();
        StartCoroutine(NewPlayerTime(username, userID));
        currentPlayerIndex = index;
    }

    
    void HUDOn()
    {
        rect.DOMoveX(640, 2f);
    }

    void HUDOff()
    {
        rect.DOMoveX(0, 1f);
    }

    IEnumerator NewPlayerTime(string username, string userID)
    {
        yield return new WaitForSeconds(1);
        SetPlayer(username, userID);
        HUDOn();
    }



    void SetPlayer(string username, string userID)
    {
        hudUser.text = username;
        StartCoroutine(GetRequest("https://api.twitch.tv/kraken/users/" + userID + "?api_version=5&oauth_token=" + v5oauth));
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
                Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
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
        Debug.Log("Loading...");
        Debug.Log(url);
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();

        if(www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        }
        else {
            Debug.Log("Loaded!");
            Texture myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            thisImage.texture = myTexture;
        }
    }
}
