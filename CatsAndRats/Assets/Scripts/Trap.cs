using System;
using UnityEngine;
[AddComponentMenu("Interactable/Trap")]
/*
*   una trappola per topi che fa le seguenti cose:
*   - interagisce col gatto = il gatto la disattiva
*   - interagisce col topo = il topo si fa male e perde una vita
*   - se il topo entra quando il gatto l'ha disattivata non si fa male
*/

public class Trap : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    bool active;
    void Start()
    {
        active = true;
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("cat"))
        {
            Debug.Log("cat entered the trigger!");
            active = false; // il gatto distrugge la trappola se ci passa
        }
        if (other.CompareTag("mouse")){

            Debug.Log("mouse entered the trigger!");
            if(active) damageMouse(); // se passa il topo si fa male
        }
    }
    void OnTriggerExit(Collider other)
    {
        
    }

    private void damageMouse()
    {
        throw new NotImplementedException();
    }
}
