using UnityEngine;

public class Box : MonoBehaviour
{
    private Vector3 _dir;
    private float _speed = 0.1f;

    private void Start()
    {
        _dir = transform.forward;
        transform.rotation = Quaternion.Euler(45f, 0f, 45f);
    }

    private void Update()
    {
        transform.Rotate(0f, 1f, 0f);
        transform.Translate(_dir * _speed, Space.World);
    }

    private void OnCollisionEnter(Collision other)
    {
        var contr = other.gameObject.GetComponent<Controller>();
        if (contr)
        {
            contr.player.Damaged();
        }
        else
        {
            _dir = -_dir;
        }
    }
}