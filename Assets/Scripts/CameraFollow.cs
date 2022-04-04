using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private GameObject player;

    void LateUpdate()
    {
        if (!player.activeInHierarchy)
        {
            return;
        }
        
        var pos = player.transform.position;
        pos.y += 10;
        pos.z -= 10;
        transform.position = pos;
    }
}