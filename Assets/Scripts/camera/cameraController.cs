using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.LuisPedroFonseca.ProCamera2D;

public class cameraController : MonoBehaviour
{
    public GameObject focus;
    bool followingFocus = false;
    int currentPlayerIndex;

    public GameObject CameramanSW;
    public GameObject CameramanC;
    public GameObject CameramanMain;

    public GameObject plane;

    public Players players;

    

    public ProCamera2D cam;
    public HUDConroller hud;

    float clear = 0;
    bool approved = false;
    
    void Awake()
    {
        cam = ProCamera2D.Instance;
    }

    void Start()
    {
        cam.AddCameraTarget(CameramanSW.transform);
        StartCoroutine(OpeningTargets());
    }

    void Update()
    {
        if (clear <= 15)
        {
            clear += Time.deltaTime;
        }
        else
        {
            approved = true;
        }

        if (followingFocus && focus)
        {
            CameramanMain.transform.position = focus.transform.position;
        }
        else if (followingFocus && !focus)
        {
            approved = true;
            ChangeFocus();
        }


    }

    public void LookAtObject(GameObject obj)
    {
        cam.RemoveAllCameraTargets();
        cam.AddCameraTarget(obj.transform);
    }

    void LookAtPlane()
    {
        transform.position = new Vector3(transform.position.x, 65, transform.position.z);
        LookAtObject(plane);
    }

    void LookAwayFromPlane()
    {
        transform.position = new Vector3(transform.position.x, 25, transform.position.z);
        LookAtObject(plane);
    }
    
    IEnumerator OpeningTargets()
    {
        yield return new WaitForSeconds(5);
        LookAtObject(CameramanC);
        yield return new WaitForSeconds(10);
        cam.HorizontalFollowSmoothness = 0.1f;
        cam.VerticalFollowSmoothness = 0.1f;
        LookAtPlane();
        yield return new WaitForSeconds(10);
        LookAwayFromPlane();
        int openingPlayer = Mathf.Clamp(1, 0, players.players.Count - 1);
        followingFocus = true;
        ForceChangeFocus(players.players[openingPlayer].soldier, players.players[openingPlayer].username, players.players[openingPlayer].userID, players.players[openingPlayer].index);
        ChangeFocus();
        LookAtObject(CameramanMain);
    }

    public void ChangeFocus()
    {
        if (approved)
        {
            int newIndex = players.HighestScore();
            focus = players.players[newIndex].soldier;
            Debug.Log(players.players[newIndex].username+ ": " + players.players[newIndex].score);
            hud.NewPlayerHUD(players.players[newIndex].username, players.players[newIndex].userID, players.players[newIndex].kills, players.players[newIndex].index);
            currentPlayerIndex = players.players[newIndex].index;
        }
        StartCoroutine(ChangeFocusWait());
    }

    IEnumerator ChangeFocusWait()
    {
        yield return new WaitForSeconds(15);
        ChangeFocus();
    }

    public void ForceChangeFocus(GameObject player, string username, string userID, int index)
    {
        clear = -10f;
        focus = player;
        Debug.Log(username + ": " + players.players[index].score);
        hud.NewPlayerHUD(username, userID, players.players[index].kills, index);
        currentPlayerIndex = index;
        approved = false;
    }

    public void PlayerDiedCheckCurrent(int deadIndex, int killerIndex)
    {
        if (deadIndex == currentPlayerIndex)
        {
            if (killerIndex < 101) //they are not the zone
            {
                //if player that died is being spectated, look at who killed them
                ForceChangeFocus(players.players[killerIndex].soldier, players.players[killerIndex].username, players.players[killerIndex].userID, players.players[killerIndex].index);
            }
            else
            {
                //zone killed focus, change
                ChangeFocus();
            }
        }
    }
}
