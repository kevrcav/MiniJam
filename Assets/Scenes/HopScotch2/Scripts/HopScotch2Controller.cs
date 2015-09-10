using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class HopScotch2Controller : MonoBehaviour
{
	public GameObject rock;
	public HopScotch2Glass[] glasses;
	public int index = -1;
	float lerpSpeed = 20f;
	bool lerping = false;
	public float vertical;
	public bool reverse = false;
	public bool twisting = false;
	public float drunk;
	public Twirl effect;
	public TiltShift shift;


	// Use this for initialization
	void Start () 
	{
		MiniGame.Instance.winOnTimeOut = false;
		MiniGame.Instance.gameTime = 10;
		//MiniGame.Instance.failLines = new string[] {"FAIL SOBER"};
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!twisting)
		{
			if (reverse)
			{
				StartCoroutine("TwistR");
			}
			else
			{
				StartCoroutine("Twist");
			}
		}

		if (index == glasses.Length - 1)
		{
			Debug.Log("Win");
			MiniGame.Instance.ReportWin();
		}
		vertical = Input.GetAxis("Vertical");
		if (!lerping)
		{
			if (Input.GetAxis("Vertical") > 0)
			{
				if (glasses[index + 1].lastDir != HopScotch2Glass.Direction.up)
				{
					MiniGame.Instance.ReportLose();
				}
				else
				{
					drunk += 30;
					shift.blurArea += 4;
					index++;
					StartCoroutine("MoveToGlass");
				}
			}
			else if (Input.GetAxis("Horizontal") > 0)
			{
				if (glasses[index + 1].lastDir != HopScotch2Glass.Direction.right)
				{
					MiniGame.Instance.ReportLose();
				}
				else
				{
					drunk += 30;
					shift.blurArea += 4;
					index++;
					StartCoroutine("MoveToGlass");
				}
			}
			else if (Input.GetAxis("Vertical") < 0 || Input.GetAxis("Horizontal") < 0)
			{
				MiniGame.Instance.ReportLose();
			}
		}
	}


	IEnumerator MoveToGlass()
	{
		lerping = true;
		while (rock.transform.position != glasses[index].gameObject.transform.position)
		{
			rock.transform.position = Vector3.Lerp(rock.transform.position, glasses[index].gameObject.transform.position, Time.deltaTime * lerpSpeed);
			yield return null;
		}
		lerping = false;
		yield break;
	}

	IEnumerator TwistR()
	{
		twisting = true;
		while (!FuzzyEqual(effect.angle, -drunk, 2f))
		{
			effect.angle = Mathf.Lerp(effect.angle, -drunk, Time.deltaTime * ((index +2)) * 2);
			yield return null;
		}
		reverse = false;
		twisting = false;
		yield break;
	}

	IEnumerator Twist()
	{
		twisting = true;
		while (!FuzzyEqual(effect.angle, drunk, 2f))
		{
			effect.angle = Mathf.Lerp(effect.angle, drunk, Time.deltaTime * ((index + 2) * 2));
			yield return null;
		}
		reverse = true;
		twisting = false;
		yield break;
	}

	bool FuzzyEqual(float first, float second, float err)
	{
		return first <= second + err && first >= second - err;
	}
}
