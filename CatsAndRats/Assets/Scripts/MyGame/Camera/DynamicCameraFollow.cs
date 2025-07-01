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
                FullCamera.GetComponent<AudioListener>().enabled = false;
                CatCamera.GetComponent<AudioListener>().enabled = true;
                FullCamera.gameObject.SetActive(false);
                MouseCamera.gameObject.SetActive(true);
                CatCamera.gameObject.SetActive(true);
            }
            else
            {
                FullCamera.GetComponent<AudioListener>().enabled = true;
                CatCamera.GetComponent<AudioListener>().enabled = false;
                FullCamera.gameObject.SetActive(true);
                MouseCamera.gameObject.SetActive(false);
                CatCamera.gameObject.SetActive(false);
            }
        }
        
    }
}
