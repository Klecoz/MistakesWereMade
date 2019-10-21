using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionMakerManager : MonoBehaviour
{
    private Collider wall;
    
    // Start is called before the first frame update
    void Start()
    {
        wall = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PushPlayerIntoDoor()
    {
        wall.enabled = true;
    }
}
