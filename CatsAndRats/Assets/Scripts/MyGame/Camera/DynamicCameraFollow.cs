/**
* DynamicCameraFollow.cs
* 
* This script enables the right camera based on the mouse's position.
*/

using UnityEngine;

public class DynamicCameraFollow : MonoBehaviour
{
    [SerializeField] GameObject MouseCamera;
    [SerializeField] GameObject CatCamera;
    [SerializeField] GameObject FullCamera;

    void Update()
    {
        if (MouseCamera != null && CatCamera != null && FullCamera != null)
        {
            if (!GameObject.FindWithTag("mouse").GetComponent<MyGame.Controllers.MouseCtrl>().IsOnTop())
            {
                FullCamera.gameObject.SetActive(false);
                MouseCamera.gameObject.SetActive(true);
                CatCamera.gameObject.SetActive(true);
            }
            else
            {
                FullCamera.gameObject.SetActive(true);
                MouseCamera.gameObject.SetActive(false);
                CatCamera.gameObject.SetActive(false);
            }
        }
        
    }
}
