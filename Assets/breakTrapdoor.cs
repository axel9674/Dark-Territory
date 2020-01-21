using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakTrapdoor : MonoBehaviour
{

    public Transform collisionCollider;
    public LayerMask trapsLayer;

    public float collisionSize = .5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Collider2D[] trapsColliders = Physics2D.OverlapCircleAll(collisionCollider.position, collisionSize, trapsLayer);

        foreach (Collider2D trap in trapsColliders)
        {
            trap.GetComponent<Trapdoor>().Break();
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (collisionCollider == null)
            return;

        Gizmos.DrawWireSphere(collisionCollider.position, collisionSize);
    }
}
