using UnityEngine;
public class RocketScript : MonoBehaviour
{ 
    void Start()
    {
        
    }

    void Update()
    {
        
        if(transform.position.x>SpaceshipShooting.DeadZone)
        {
            Debug.Log("Rocket deleted");
            Destroy(gameObject);
        }
    }
}
