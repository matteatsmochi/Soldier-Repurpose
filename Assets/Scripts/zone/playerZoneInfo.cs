using UnityEngine;
using CoolBattleRoyaleZone;

public class playerZoneInfo : MonoBehaviour
{
    public int CurStepB = 0;
    public Vector3 PositionB = new Vector3(0,0,0);
    public float RadiusB = 500f;

    public zoneOn zo;
    bool zoneExists = false;

    void Update()
    {
        if (zoneExists)
        {
            CurStepB = Zone.Instance.CurStep;
            PositionB = Zone.Instance.CurrentSafeZone.Position;
            RadiusB = Zone.Instance.CurrentSafeZone.Radius;
        }
        else
        {
            if (zo.on)
            {
                zoneExists = true;
            }
        }
        
    }
}