using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDMgr : MonoBehaviour {

   public static HUDMgr Instance;

   public Text lives;
   public Text score;
   public Text message;

   public float bridgeTime;

   void Awake()
   {
      Instance = this;
   }

   public void StartBridgeSequence(string gameMessage)
   {
      lives.text = MiniGameMgr.Instance.lives.ToString();
      lives.gameObject.SetActive(true);
      score.text = MiniGameMgr.Instance.score.ToString();
      score.gameObject.SetActive(true);
      message.text = gameMessage;
      message.gameObject.SetActive(true);
   }

   public void EndBridgeSequence(string gameMessage)
   {
      lives.gameObject.SetActive(false);
      score.gameObject.SetActive(false);
      message.text = gameMessage;
      message.gameObject.SetActive(true);
   }
}
