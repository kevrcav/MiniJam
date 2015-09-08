using UnityEngine;
using System.Collections;
using UnityEditor;

public class LoadingDoors : MonoBehaviour {

   Animator anim;
   MiniGameMgr manager;

   public delegate void LoadingDoorStateChangedHandler();
   public LoadingDoorStateChangedHandler OnDoorsOpened;
   public LoadingDoorStateChangedHandler OnDoorsClosed;

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

   public void DoorsOpened()
   {
      if (OnDoorsOpened != null)
         OnDoorsOpened();
   }

   public void DoorsClosed()
   {
      if (OnDoorsClosed != null)
         OnDoorsClosed();
   }
}
