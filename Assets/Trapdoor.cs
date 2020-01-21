using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Trapdoor : MonoBehaviour
{

    GameObject gameObject;

    // Start is called before the first frame update
    void Start()
    {
        gameObject = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Break()
    {
        Debug.Log("Broken");
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        this.enabled = false;

        AstarPath.active.Scan();
    }
}
