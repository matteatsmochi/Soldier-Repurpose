using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.LuisPedroFonseca.ProCamera2D;

public class cameraController : MonoBehaviour
{
    public GameObject focus;
    
    public GameObject CameramanSW;
    public GameObject CameramanC;
    public GameObject CameramanMain;

    public GameObject plane;

    public Players players;

    

    public ProCamera2D cam;

    float clear = 0;
    bool approved = false;
    
    void Awake()
    {
        cam = ProCamera2D.Instance;
    }

    void Start()
    {
        //cam.AddCameraTarget(CameramanSW.transform);
        StartCoroutine(OpeningTargets());
    }

    void Update()
    {
        if (clear <= 5)
        {
            clear += Time.deltaTime;
        }
        else
        {
            approved = true;
        }

        if (focus)
        {
            CameramanMain.transform.position = focus.transform.position;
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
        focus = players.HighestScore();
        LookAtObject(CameramanMain);
    }

    void ChangeFocus()
    {
        if (approved)
        {
            focus = players.HighestScore();
        }
        StartCoroutine(ChangeFocusWait());
    }

    IEnumerator ChangeFocusWait()
    {
        yield return new WaitForSeconds(5);
        ChangeFocus();
    }

    public void ForceChangeFocus(GameObject player)
    {
        StopCoroutine(ChangeFocusWait());
        clear = -5f;
        focus = player;
        StartCoroutine(ChangeFocusWait());
    }
}
