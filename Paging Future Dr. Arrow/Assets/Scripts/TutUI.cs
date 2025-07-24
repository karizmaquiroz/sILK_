using UnityEngine;

public class TutUI : MonoBehaviour
{

    public void DestroyParent()
    {
        if (transform.parent != null)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
