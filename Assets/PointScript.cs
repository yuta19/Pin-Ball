using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointScript : MonoBehaviour {

	public GameObject pointText;

	public int score = 0;

	// Use this for initialization
	void Start () {
		this.pointText = GameObject.Find("PointText");
	
	}
	
	// Update is called once per frame
	void Update () {

		this.pointText.GetComponent<Text> ().text = score.ToString();
	
	}
}
