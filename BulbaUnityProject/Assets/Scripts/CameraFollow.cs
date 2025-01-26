using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Update is called once per frame
    void LateUpdate()
    {
        var position = Camera.main.transform.position;
        position.x = transform.position.x;
        position.y = transform.position.y;
        Camera.main.transform.position = position;
    }
}
