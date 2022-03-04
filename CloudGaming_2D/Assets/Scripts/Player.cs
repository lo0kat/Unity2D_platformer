using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Player : MonoBehaviour
{
    public Vector3 spawnPosition = new Vector3();
 
    //Components
    public PlayerMovement playerMovement = null;
    public CameraFollow cameraFollowPosition = null;
 
    public GameObject deathScreen = null;
 
    // Start is called before the first frame update
    void Start()
    {
        this.spawnPosition = this.playerMovement.transform.position;
        
        //UI death screen
        this.deathScreen.SetActive(false);
    }
 
    public void Die(){
         Debug.LogWarning("Player "+this.gameObject.name+" is now dead");
          this.deathScreen.SetActive(true);
 
          //player Controller - stop receiving Input
          this.playerMovement.enabled = false;
 
          //Camera - stop following player
 
          this.cameraFollowPosition.enabled = false;
    } 
 
    public void Respawn(){
         this.deathScreen.SetActive(false);
 
         // On reset la position
         this.playerMovement.transform.position = this.spawnPosition;
 
         //Rigid body
        this.playerMovement.rb.velocity = Vector3.zero;
 
          //player Controller - stop receiving Inpu
          this.playerMovement.enabled = true;
 
          //Camera - stop following player
 
          this.cameraFollowPosition.enabled = true;
 
    }
}