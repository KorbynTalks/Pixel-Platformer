using UnityEngine;

public class Performace_ingame_unactivateobjsontouch : MonoBehaviour
{
    public Collider2D collisionTarget;
    public Collider2D collisionActivator;
    public GameObject gameObjectToUnactivate;
    

    private void Update()
    {
        if(collisionTarget.IsTouching(collisionActivator))
        {
            gameObjectToUnactivate.gameObject.SetActive(false);
        }
    }
}
