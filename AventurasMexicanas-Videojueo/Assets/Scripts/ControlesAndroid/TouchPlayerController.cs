using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPlayerController : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        //Move Front/Back
        if (MobileJoystick_UI.instance.moveDirection.y != 0)
        {
            print("Avanzo");
            transform.Translate(Vector3.forward * Time.deltaTime * 2.45f * MobileJoystick_UI.instance.moveDirection.y);
        }

        //Move Left/Right
        if (MobileJoystick_UI.instance.moveDirection.x != 0)
        {
            print("Muevo a la izquierda/derecha");
            transform.Translate(Vector3.right * Time.deltaTime * 2.45f * MobileJoystick_UI.instance.moveDirection.x);
        }
    }
}
