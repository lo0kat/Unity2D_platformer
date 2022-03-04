using UnityEngine;

public class Platform : MonoBehaviour
{
   public Transform startTransform = null;
   public Transform endTransform = null;
   public float moveSpeed = 1.0f;
   public float percentage = 0.0f;
   private bool moveDirection = false;
   public Rigidbody2D RigidBody2D = null;

   void Update(){
       if (this.moveDirection ==true){
           this.percentage = Mathf.Clamp01(this.percentage+this.moveSpeed*Time.deltaTime);
           if (this.percentage == 1.0f){
               this.moveDirection = !this.moveDirection;
           }
       }
       else{
              this.percentage = Mathf.Clamp01(this.percentage-this.moveSpeed*Time.deltaTime);
                if (this.percentage == 0.0f){
               this.moveDirection = !this.moveDirection;
           }
       }
   }

   void FixedUpdate(){
       if (this.RigidBody2D !=null){
           Vector2 newPosition = Vector2.Lerp(this.startTransform.position,this.endTransform.position,this.percentage);
           this.RigidBody2D.MovePosition(newPosition);
       }
   }
   void OnDrawGizmos(){
       Gizmos.DrawLine(this.startTransform.position,this.endTransform.position); 
   }

}
