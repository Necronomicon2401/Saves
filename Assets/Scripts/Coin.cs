using UnityEngine;

public class Coin : MonoBehaviour
{
    public bool isActive = true;
    
    public void SetActive()
    {
        if (!isActive)
        {
            transform.Translate(Vector3.down * 3);
        }
    }

    private void Update()
    {
        transform.Rotate(0f, 2f, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        var contr = other.gameObject.GetComponent<Controller>();
        if (contr)
        {
            contr.player.AddCoin();
            isActive = false;
            transform.Translate(Vector3.down * 3);
        }
    }
}