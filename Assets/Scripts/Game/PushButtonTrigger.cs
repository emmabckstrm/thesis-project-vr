﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButtonTrigger : MonoBehaviour {

	protected bool isPushed = false;
	protected GameObject level;
	public GameObject prefab;
	public ButtonHandler buttonHandlerScript;
	public GameObject button;
	public bool actionOnTrigger = false;
	public ButtonHandler.TriggerActions triggerAction;
	private bool triggered = false;
	protected Transform buttonPress;
	protected Renderer renderer;
	protected Material mat;
	public Color emissionColor = new Color(0.3360726f, 0.8161765f, 0.6175128f);

	// Use this for initialization
	void Start () {
		buttonHandlerScript = transform.parent.parent.GetComponent<ButtonHandler>();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Button") {
			if (triggered) return;
			triggered = true;
			buttonHandlerScript.PushButton();
			if (actionOnTrigger) {
				buttonHandlerScript.HandleAction(triggerAction);
			}
			mat = button.GetComponent<Renderer>().material;
			mat.SetColor("_EmissionColor", emissionColor);
		}
	}
	void OnTriggerExit(Collider other) {

		if (other.tag == "Button") {
			if (!triggered) return;
			triggered = false;
			buttonHandlerScript.UnpushButton();
			if (actionOnTrigger) {
				buttonHandlerScript.UnhandleAction(triggerAction);
			}
			mat = button.GetComponent<Renderer>().material;
			mat.SetColor("_EmissionColor", Color.black);
		}
	}
}
