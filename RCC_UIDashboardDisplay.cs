using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

/// <summary>
/// Handles RCC Canvas dashboard elements.
/// </summary>
[AddComponentMenu("BoneCracker Games/Realistic Car Controller/UI/RCC UI Dashboard Displayer")]
[RequireComponent (typeof(RCC_DashboardInputs))]
public class RCC_UIDashboardDisplay : MonoBehaviour {

	// Getting an Instance of Main Shared RCC Settings.
	#region RCC Settings Instance

	private RCC_Settings RCCSettingsInstance;
	private RCC_Settings RCCSettings {
		get {
			if (RCCSettingsInstance == null) {
				RCCSettingsInstance = RCC_Settings.Instance;
				return RCCSettingsInstance;
			}
			return RCCSettingsInstance;
		}
	}

	#endregion

	private RCC_DashboardInputs inputs;

	public DisplayType displayType;
	public enum DisplayType{Full, Customization, Off}


	public GameObject controllerButtons;
	public GameObject gauges;
	
	public Text KMHLabel;




	void Awake(){

		inputs = GetComponent<RCC_DashboardInputs>();

		if (!inputs) {

			enabled = false;
			return;

		}

	}
	
	void Start () {
		
		CheckController ();
		
	}

	void OnEnable(){

		RCC_SceneManager.OnControllerChanged += CheckController;

	}

	private void CheckController(){

		if (RCCSettings.selectedControllerType == RCC_Settings.ControllerType.Keyboard || RCCSettings.selectedControllerType == RCC_Settings.ControllerType.XBox360One || RCCSettings.selectedControllerType == RCC_Settings.ControllerType.PS4 || RCCSettings.selectedControllerType == RCC_Settings.ControllerType.LogitechSteeringWheel) {

			
		}

	}

	void Update(){

		switch (displayType) {

		case DisplayType.Full:



			if(controllerButtons && !controllerButtons.activeInHierarchy)
				controllerButtons.SetActive(true);

			if(gauges && !gauges.activeInHierarchy)
				gauges.SetActive(true);

			break;

		case DisplayType.Customization:


			if(controllerButtons && controllerButtons.activeInHierarchy)
				controllerButtons.SetActive(false);

			if(gauges && gauges.activeInHierarchy)
				gauges.SetActive(false);

			break;




		case DisplayType.Off:


			if(controllerButtons &&controllerButtons.activeInHierarchy)
				controllerButtons.SetActive(false);

			if(gauges &&gauges.activeInHierarchy)
				gauges.SetActive(false);

			break;

		}

	}
	
	void LateUpdate () {

		if (RCC_SceneManager.Instance.activePlayerVehicle) {
		
			if (KMHLabel) {
			
				if (RCCSettings.units == RCC_Settings.Units.KMH)
					KMHLabel.text = inputs.KMH.ToString ("0") + "\nKMH";
				else
					KMHLabel.text = (inputs.KMH * 0.62f).ToString ("0") + "\nMPH";
			
			}


 
		
			

		}

	}

	public void SetDisplayType(DisplayType _displayType){

		displayType = _displayType;

	}

	void OnDisable(){

		RCC_SceneManager.OnControllerChanged -= CheckController;

	}

}
