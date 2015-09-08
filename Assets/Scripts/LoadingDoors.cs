using UnityEngine;
using System.Collections;
using UnityEditor;

public class LoadingDoors : MonoBehaviour {

   Animator anim;
   MiniGameMgr manager;


	// Use this for initialization
	void Start () {
      anim = GetComponent<Animator>();
      anim.SetTrigger("open");
      manager = FindObjectOfType<MiniGameMgr>();
	}
	
	public void OpenDoors () 
   {
       anim.SetTrigger("open");
	}
   public void CloseDoors()
   {
       anim.SetTrigger("close");
   }
}
