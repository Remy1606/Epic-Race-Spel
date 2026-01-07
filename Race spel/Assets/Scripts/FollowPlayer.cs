// using UnityEngine;

// public class FollowPlayer : MonoBehaviour

// {
//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     public GameObject player;
//     private Vector3 offset = new Vector3(0, 5, -7);
//     void LateUpdate()
//     {
//         transform.position = player.transform.position + offset;
//     }
// }
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform getLocation;
    public float orbitRadius = 5f;
    public float lowerLimit = 1.99f;
    void LateUpdate()
    {
        if (transform.position.y < lowerLimit)
        {
            transform.position = new Vector3(transform.position.x, lowerLimit, transform.position.z);
        }

        transform.LookAt(getLocation);
        transform.position = getLocation.position - transform.forward * orbitRadius;
    }
}
