using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject movementNode;
    private GameObject curMoveNode;
    Vector3 lockedMoveDirection;
    public float moveSpeed = 1;
    bool moving = false;
    Camera cam;
    [SerializeField] private LayerMask ObstructionLayerMask;
    public bool canMove = true;
    
    void Start()
    {
        cam = Camera.main;
        WorldClicked.OnClick += HandleClick;
    }

    private void OnDestroy()
    {
        WorldClicked.OnClick -= HandleClick;
    }

    void Update()
    {
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

    private void HandleClick()
    {
        bool hasEnoughEnergy = (StatsSingleton.Instance.energyGen >= StatsSingleton.Instance.energyUse);
        if (!checkPathForObstruction(GetMousePosition()) && canMove && hasEnoughEnergy)
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

    bool checkPathForObstruction(Vector3 targetPosition)
    {
        Vector3 fwd = targetPosition - transform.position;
        float rayDistance = fwd.magnitude;
        fwd = fwd.normalized;

        Debug.DrawRay(transform.position, fwd * rayDistance, Color.green);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, fwd, rayDistance, ObstructionLayerMask);

        if (hit) {
            Debug.Log("There is something in front of the object!" + hit.transform.gameObject.tag);
            return true;
        }

        return false;
    }

}
