using UnityEngine;
using System.Collections;

public class BenjiNSCursor : MonoBehaviour {

	public float speed = 1.0f;
	public float xBounds = 5.0f;
	public float yBounds = 3.0f;

	public GameObject spawnedBlockPrefab;
	protected GameObject spawnedBlock = null; 
	public string buttonName = "Button 1";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float xChange = Input.GetAxis("Horizontal");
		float yChange = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(xChange, yChange, 0);
		Vector3 position = transform.position;
		position += movement * Time.deltaTime * speed;

		position.x = Mathf.Clamp(position.x, -xBounds, xBounds);
		position.y = Mathf.Clamp(position.y, -yBounds, yBounds);
		transform.position = position;

		if(Input.GetButtonDown(buttonName)){
			spawnedBlock = Instantiate(spawnedBlockPrefab, transform.position, Quaternion.identity) as GameObject;
			spawnedBlock.transform.SetParent(transform.parent);
			spawnedBlock.transform.localScale = new Vector3(1,0.001f,1);
		}
		else if(Input.GetButtonUp(buttonName)){
			spawnedBlock = null;
		}
		else if(Input.GetButton(buttonName)){
			if(spawnedBlock == null){
				Debug.Log("Why did this happen to em?");
			}
			else{
				const float scaleAdjust = 7.0f;
				Vector3 diffVec = transform.position - spawnedBlock.transform.position;
				spawnedBlock.transform.localScale = new Vector3(1,diffVec.magnitude * scaleAdjust,1);
				spawnedBlock.transform.rotation = Quaternion.LookRotation(Vector3.forward, diffVec);
			}
		}
	}

	void OnDrawGizmos(){
		Gizmos.color = Color.white;
		
		Gizmos.DrawWireCube(Vector3.zero, new Vector3(xBounds, yBounds, 10.0f));
	}
}
