using System.Collections;
using UnityEngine;
using CoolBattleRoyaleZone;

public class zoneEmitterHealth : MonoBehaviour
{
    public float MaxHP;

    Rigidbody rb;
    bool _wait;

    public float HP { get; private set; }

    public void Impact(float amount, Vector3 impactForce, Vector3 impactPoint, int index)
    {
        HP -= amount;
        if (HP <= 0f)
        {
            Destroy(gameObject);
        }
        else if (rb != null)
        {
            rb.AddForceAtPosition(impactForce, impactPoint);
        }
    }

    public void ZoneDamage(float amount)
    {
        Impact(amount, (Zone.Instance.ZoneCircles[Zone.Instance.CurStep].PositionAndRadius.Position - transform.position) * 13, transform.position, -1);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        HP = MaxHP;
    }

    void Update ( )
    {
        // Getting zone current safe zone values
        var zonePos = Zone.Instance.CurrentSafeZone.Position;
        var zoneRadius = Zone.Instance.CurrentSafeZone.Radius;
        // Checking distance between player and circle
        var dstToZone = Vector3.Distance (new Vector3 (transform.position.x, zonePos.y, transform.position.z), zonePos);
        // Checking if we inner of circle or not by radius and if not, start applying damage to health
        if (dstToZone > zoneRadius && !_wait) StartCoroutine (DoDamageCoroutine( ));
    }

    // Method for waiting time between applying damage
    private IEnumerator DoDamageCoroutine()
    {
        _wait = true;
        ZoneDamage(Zone.Instance.CurStep + 1);
        yield return new WaitForSeconds (1); // Waiting between damages.
        _wait = false;
    }

}

