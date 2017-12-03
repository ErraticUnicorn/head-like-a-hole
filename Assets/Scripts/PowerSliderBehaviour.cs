using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerSliderBehaviour : MonoBehaviour {

	public Slider slider;
	public float sliderSpeed = .05f;
	private bool pressed;

	// Use this for initialization
	void Start () {
		pressed = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (pressed == true) {
			slider.value += sliderSpeed;
		}
	}

	public void Activate() {
		pressed = true;
	}

	public void Release() {
		pressed = false;
	}

	public double GetPower() {
		return slider.value;
	}

	public void Reset() {
		slider.value = 0;
	}
}
