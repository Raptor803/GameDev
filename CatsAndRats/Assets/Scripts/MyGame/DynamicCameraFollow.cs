using UnityEngine;

public class DynamicCameraFollow : MonoBehaviour
{
    [SerializeField] GameObject MouseCamera;
    [SerializeField] GameObject CatCamera;
    [SerializeField] GameObject FullCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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
