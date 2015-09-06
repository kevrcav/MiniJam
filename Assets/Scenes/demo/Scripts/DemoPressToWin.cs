using UnityEngine;
using System.Collections;

public class DemoPressToWin : MonoBehaviour {

   bool won;
   public SpriteRenderer sprite;

	void Update()
   {
      if (!won && Input.GetAxis("Button 1") > 0)
      {
         MiniGame.Instance.ReportWin();
         sprite.color = new Color(0, 1, 0);
      }
   }
}
