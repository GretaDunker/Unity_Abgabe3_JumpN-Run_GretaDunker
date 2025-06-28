using UnityEditor.Build.Content;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public enum CollectibleType {Coin, Diamond}
    public CollectibleType type;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            int value = type == CollectibleType.Coin ? 1 : 3;
            GameManager.Instance.AddPoints(value);
            Destroy(gameObject);    //wenn dass Objekt (Coin oder Diamond) eingesammelt wird, wird es zerstört
        }
    }
}
