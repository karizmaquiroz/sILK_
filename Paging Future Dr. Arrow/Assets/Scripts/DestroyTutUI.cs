using UnityEngine;

public class DestroyTutUI : MonoBehaviour
{
    public void DestroyParent()
    {
        if (transform.parent != null)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
