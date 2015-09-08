using UnityEngine;
using System.Collections;

public class DemoPressToWin : MonoBehaviour {

   public SpriteRenderer sprite;

	void Update()
   {
      if (Input.GetAxis("Button 1") > 0)
      {
         sprite.color = new Color(0, 1, 0);
         MiniGame.Instance.ReportWin();
      }
   }
}
