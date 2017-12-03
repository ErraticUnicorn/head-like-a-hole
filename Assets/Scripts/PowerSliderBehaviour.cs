using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerSliderBehaviour : MonoBehaviour {

	public Slider slider;
	public float sliderSpeed = .05f;
	private bool isPressed;

	// Use this for initialization
	void Start () {
		isPressed = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isPressed == true) {
			slider.value += sliderSpeed;
		}
	}

	public void Activate() {
		isPressed = true;
	}

	public void Release() {
		isPressed = false;
	}

	public double GetPower() {
		return slider.value;
	}

	public void Reset() {
		slider.value = 0;
	}
}
