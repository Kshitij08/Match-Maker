using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePortals : MonoBehaviour
{

    public GameObject portalL;
    public GameObject portalR;

    public int leftMul = 1;
    public int rightMul = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        portalL.transform.position = new Vector2(portalL.transform.position.x +  leftMul * Time.deltaTime, portalL.transform.position.y);
        portalR.transform.position = new Vector2(portalR.transform.position.x - rightMul * Time.deltaTime, portalR.transform.position.y);

        if(portalL.transform.position.x >= 2)
        {
            leftMul = -1;
        }
        if (portalL.transform.position.x <= -2)
        {
            leftMul = 1;
        }

        if (portalR.transform.position.x >= 2)
        {
            rightMul = 1;
        }
        if (portalR.transform.position.x <= -2)
        {
            rightMul = -1;
        }
    }
}
