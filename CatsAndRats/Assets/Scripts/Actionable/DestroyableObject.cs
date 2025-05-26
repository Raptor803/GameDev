using UnityEngine;

public class DestroyableObject : Actionable
{
    public override void Action()
    {
        gameObject.SetActive(false);
    }

}
