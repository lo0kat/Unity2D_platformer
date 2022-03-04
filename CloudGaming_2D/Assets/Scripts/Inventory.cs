using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
  public int diamondsCount;
  public Text diamondsCountText;
  public static Inventory instance;

  private void Awake(){
      if(instance!=null){
          Debug.LogWarning("Il y a plus d'une instance d'Inventory dans la scène");
          return;
      }
     instance = this; 
  }

  public void AddDiamonds(int count){
      diamondsCount += count;
      diamondsCountText.text = diamondsCount.ToString();
  }
}
