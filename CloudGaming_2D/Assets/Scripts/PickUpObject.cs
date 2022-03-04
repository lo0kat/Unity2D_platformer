using UnityEngine;

public class PickUpObject : MonoBehaviour
{    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            Inventory.instance.AddDiamonds(1);
            Destroy(gameObject);
        }
    }
}
