using UnityEngine;
using System.Collections;

public class FripperController : MonoBehaviour {

	private  HingeJoint myHingeJoint;

	private float defaultAngle = 20;

	private float flickAngle = -20;


	// Use this for initialization
	void Start () {
		this.myHingeJoint = GetComponent<HingeJoint>();

		SetAngle (this.defaultAngle);
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.flickAngle);
		}

		if (Input.GetKeyDown (KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.flickAngle);
		}
	
		if (Input.GetKeyUp (KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.defaultAngle);
		}
		if (Input.GetKeyUp (KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.defaultAngle);
		}

//		タッチ処理
		if (Input.touches.Length > 0) {
			for(int i=0; i < Input.touches.Length;i++){
				if (Input.touches [i].phase == TouchPhase.Began) {
					if (Screen.width / 2 > Input.touches [i].position.x) {
						if (tag == "LeftFripperTag") {
							SetAngle (this.flickAngle);
						}

						Debug.Log ("画面左をタッチした");
					} else {
						if (tag == "RightFripperTag") {
							SetAngle (this.flickAngle);
						}
						Debug.Log ("画面右をタッチした");
					}
				}
				if (Input.touches [i].phase == TouchPhase.Ended) {
					if (Screen.width / 2 > Input.touches [i].position.x) {
						if (tag == "LeftFripperTag") {
							SetAngle (this.defaultAngle);
						}
						Debug.Log ("画面左を離した");
					} else {
						if (tag == "RightFripperTag") {
							SetAngle (this.defaultAngle);
						}
						Debug.Log ("画面右を離した");
					}
				}
			}
		}


			
	}

	public void SetAngle(float angle){
		JointSpring jointSpr = this.myHingeJoint.spring;
		jointSpr.targetPosition = angle;
		this.myHingeJoint.spring = jointSpr;

	}

}
