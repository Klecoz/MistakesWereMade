using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float smooth = 2.0f;
    public float DoorOpenAngle = 90.0f;
    public float DoorCloseAngle = 0.0f;
    public bool isOpenClose = false;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpenClose == true)
            {
                var target = Quaternion.Euler(0, DoorOpenAngle, 0);
                // Dampen towards the target rotation
                transform.localRotation = Quaternion.Slerp(transform.localRotation, target,
                    Time.deltaTime * smooth);

                if (gameObject.transform.localRotation.y == 90.0f)
                {
                    isOpenClose = false;
                }
            }

            if (isOpenClose == false)
            {
                var target1 = Quaternion.Euler(0, DoorCloseAngle, 0);
                // Dampen towards the target rotation
                transform.localRotation = Quaternion.Slerp(transform.localRotation, target1,
                    Time.deltaTime * smooth);

                if (gameObject.transform.localRotation.y == 0.0f)
                {
                    isOpenClose = true;
                }

            }

            if (Input.GetKeyDown(KeyCode.H))
            {
                isOpenClose =!isOpenClose;
            }
    }
}
