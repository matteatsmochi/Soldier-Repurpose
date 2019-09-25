using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SensorToolkit.Example;

public class newHealth : MonoBehaviour
{
    public float MaxHP;
    public GameObject Corpse;

    public playerZoneInfo pzi;

    Rigidbody rb;
    bool _wait;

    public SoldierBrain b;

    public float HP { get; private set; }

    public void Impact(float amount, Vector3 impactForce, Vector3 impactPoint, int index)
    {
        if (!b.getGameOver())
        {
            HP -= amount;
            if (HP <= 0f)
            {
                var corpse = Instantiate(Corpse, transform.position, transform.rotation) as GameObject;
                corpse.transform.SetParent(transform.parent);

                var myTeam = GetComponent<TeamMember>();
                if (myTeam)
                {
                    var corpseTeam = corpse.GetComponent<TeamMember>();
                    corpseTeam.matIndex = GetComponent<SoldierBrain>().teamMat;
                    //if (myTeam != null && corpseTeam != null) corpseTeam.StartTeam = myTeam.Team;

                    var corpseRBs = corpse.GetComponentsInChildren<Rigidbody>();
                    for (int i = 0; i < corpseRBs.Length; i++)
                    {
                        corpseRBs[i].AddForceAtPosition(impactForce, impactPoint);
                    }
                }

                    b.ImDead(index);

                Destroy(gameObject);
            }
            else if (rb != null)
            {
                rb.AddForceAtPosition(impactForce, impactPoint);
            }
        }
    }

    public void ZoneDamage(float amount)
    {
        if (amount > HP)
            Impact(amount, (pzi.PositionB - transform.position) * 10, transform.position, 101);
        else
            Impact(amount, Vector3.zero, Vector3.zero, 101);
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        pzi = GameObject.Find("Player Manager").GetComponent<playerZoneInfo>();
        b = GetComponent<SoldierBrain>();
    }
    
    void Start()
    {
        HP = MaxHP;
    }

    void Update ( )
    {
            // Getting zone current safe zone values
            var zonePos = pzi.PositionB;
            var zoneRadius = pzi.RadiusB;
            // Checking distance between player and circle
            var dstToZone = Vector3.Distance (new Vector3 (transform.position.x, zonePos.y, transform.position.z), zonePos);
            // Checking if we inner of circle or not by radius and if not, start applying damage to health
            if (dstToZone > zoneRadius && !_wait) StartCoroutine (DoDamageCoroutine( ));
    }

    // Method for waiting time between applying damage
    private IEnumerator DoDamageCoroutine()
    {
        _wait = true;
        ZoneDamage(pzi.CurStepB + 1);
        yield return new WaitForSeconds (1); // Waiting between damages.
        _wait = false;
    }

}

