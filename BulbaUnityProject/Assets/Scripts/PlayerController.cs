using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject movementNode;
    private GameObject curMoveNode;
    Vector3 lockedMoveDirection;
    float moveSpeed = 1;
    bool moving = false;
    Camera cam;
    
    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            transform.rotation = GetMouseRotation();
            lockedMoveDirection = GetMousePosition() - transform.position;
            lockedMoveDirection = lockedMoveDirection.normalized;
            moving = true;

            if (curMoveNode != null)
            {
                Destroy(curMoveNode);
            }
            curMoveNode = Instantiate(movementNode, GetMousePosition(), Quaternion.Euler(0, 0, 0));
        }

        if (moving)
        {
            transform.position += lockedMoveDirection * moveSpeed * Time.deltaTime;
        }

        if (curMoveNode != null && Mathf.Abs(transform.position.x - curMoveNode.transform.position.x) < 0.05) {
            if (Mathf.Abs(transform.position.y - curMoveNode.transform.position.y) < 0.05) {
                Destroy(curMoveNode);
                moving = false;
            }
        }
    }

    public Vector3 GetMousePosition() {
        Vector3 loc = cam.ScreenToWorldPoint(Input.mousePosition);
        loc.z = 0;
        return loc;
    }

    public Quaternion GetMouseRotation() {
        Vector3 direction = GetMousePosition() - transform.position;
        direction = direction.normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        return( Quaternion.Euler(new Vector3(0, 0, angle)) );
    }


}
