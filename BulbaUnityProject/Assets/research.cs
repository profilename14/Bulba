using UnityEngine;

public class research : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D playerCollider)
    {
        if (playerCollider.gameObject.tag == "Player")
        {
            StatsSingleton.Instance.Research += 1;
            Destroy(gameObject);
        }
    }
}
