using UnityEngine;
using System.Collections;

public class LoadingMgr : MonoBehaviour {

   public static LoadingMgr Instance;

   public delegate void GameLoadedHandler(MiniGame game);
   public GameLoadedHandler OnSceneLoaded;

   public delegate void GameUnloadedHandler(string game);
   public GameUnloadedHandler OnSceneUnloaded;
   

   void Awake()
   {
      Instance = this;
   }

   public void LoadScene(string scene)
   {
      StartCoroutine(LoadSceneCoroutine(scene));
   }

   IEnumerator LoadSceneCoroutine(string scene)
   {
      yield return Application.LoadLevelAdditiveAsync(scene);
      GameObject game = GameObject.Find(scene);
      MiniGame miniGame = null;
      if (game != null)
      {
         miniGame = game.GetComponent<MiniGame>();
         game.SetActive(false);
      }
      if (miniGame != null && OnSceneLoaded != null)
         OnSceneLoaded(miniGame);
   }

   public void UnloadScene(MiniGame miniGame)
   {
      string miniGameName = miniGame.name;
      Destroy(miniGame.gameObject);
      if (OnSceneUnloaded != null)
         OnSceneUnloaded(miniGameName);
   }
}
