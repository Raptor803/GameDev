using UnityEngine;

public class DestroyableObject : Actionable
{
    public override void Action()
    {
        Destroy(gameObject);
    }

}
