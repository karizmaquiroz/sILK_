//Attach this script to a GameObject with a Renderer component attached
//If the GameObject is visible to the camera, the message is output to the console

using UnityEngine;

public class IsVisible : MonoBehaviour
{
    Renderer m_Renderer;
    // Use this for initialization
    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    public bool IsObjectVisible() {
        if (m_Renderer.isVisible) {
            return true;
        }
        return false; ; }
}