﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CsvWrite : MonoBehaviour {


	private string condition;
	private static CsvWrite instance = null;
	public static CsvWrite Instance
	{
		get { return instance; }
	}

	//This allows the start function to be called only once.
	void Awake()
	{
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} 
		else 
			instance = this;

		DontDestroyOnLoad(this.gameObject);
	}


	void Start () {
		WriteToFile ("subject ID", "age", "gender", "handedness", "question ID", "condition", "value");
	}
		

	public void onNextButtonPressed(){
		WriteToFile (BasicDataConfigurations.ID, BasicDataConfigurations.age, BasicDataConfigurations.gender, BasicDataConfigurations.handedness, QuestionManager.questionnaireItem,  ConditionDictionary.selectedOrder[QuestionManager.currentCondition], QuestionManager.VASvalue);
	}


	void WriteToFile(string a, string b, string c, string d, string e, string f, string g){

		string stringLine =  a + "," + b + "," + c + "," + d + "," + e + "," + f + "," + g;

		System.IO.StreamWriter file = new System.IO.StreamWriter("./Logs/" + BasicDataConfigurations.ID + "_log.csv", true);
		file.WriteLine(stringLine);
		file.Close();	
	}
}