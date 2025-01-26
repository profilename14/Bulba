using UnityEngine;
using UnityEngine.SceneManagement;

public class ending : MonoBehaviour
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
            SceneManager.LoadScene(3, LoadSceneMode.Single);
            Destroy(gameObject);
        }
    }
}
