﻿using UnityEngine;
using System.Collections;

public class BrightnessRegulator : MonoBehaviour {

	Material myMaterial;

	private float minEmission = 0.3f;

	private float magEmission = 2.0f;

	private int degree = 0;

	private int speed = 10;

	Color defaultColor = Color.white;



	// Use this for initialization
	void Start () {

		if (tag == "SmallStarTag") {
			this.defaultColor = Color.white;
		} else if (tag == "LargeStarTag") {
			this.defaultColor = Color.yellow;
		} else if (tag == "SmallCloudTag" || tag == "LargeCloudTag") {
			this.defaultColor = Color.blue;
		}

		this.myMaterial = GetComponent<Renderer> ().material;

		myMaterial.SetColor ("_EmissionColor", this.defaultColor * minEmission);
	
	}
	
	// Update is called once per frame
	void Update () {

		if (this.degree >= 0) {
			Color emissionColor = this.defaultColor * (this.minEmission + Mathf.Sin (this.degree * Mathf.Deg2Rad) * this.magEmission);

			myMaterial.SetColor ("_EmissionColor", emissionColor);
			this.degree -= this.speed;
		}
	
	}

	void OnCollisionEnter(Collision other){
		this.degree = 180;
		if (tag == "SmallStarTag") {
			GameObject.Find ("Ball").GetComponent<PointScript> ().score += 10;
		} else if (tag == "LargeStarTag") {
			GameObject.Find ("Ball").GetComponent<PointScript> ().score += 20;
		} else if (tag == "SmallCloudTag") {
			GameObject.Find ("Ball").GetComponent<PointScript> ().score += 30;
		} else if (tag == "LargeCloudTag") {
			GameObject.Find ("Ball").GetComponent<PointScript> ().score += 100;
		}
			
	}

}
