using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KinematicEquations : MonoBehaviour {

	// Original article by Sebastian Lague: https://youtu.be/phMZQNu0ZFM

	//##################################################
	//	STATIC REFERENCES
	//##################################################
	private static KinematicEquations _instance;


	//##################################################
	//	GETTERS AND SETTERS
	//##################################################
	public static KinematicEquations Instance {
		get { return _instance; }
	}


	//##################################################
	//	UNITY FUNCTIONS
	//##################################################
	// Use this for initialization
	void Start () {
		_instance = this;
	}


	//##################################################
	//	ALVARO FUNCTIONS
	//##################################################
	/// <summary>
	/// Returns the displacement given the initial velocity, the final velocity and the time.
	/// </summary>
	/// <returns>The displacement.</returns>
	/// <param name="i_initialVelocity">Initial velocity.</param>
	/// <param name="i_finalVelocity">Final velocity.</param>
	/// <param name="i_predictedTime">Predicted time.</param>
	public float ReturnDisplacementUVT (float i_initialVelocity, float i_finalVelocity, float i_predictedTime) {
		float displacement = ((i_initialVelocity + i_finalVelocity) * 0.5f) * i_predictedTime;
		return displacement;
	}

	/// <summary>
	/// Returns the displacement given the initial velocity, the time and the acceleration.
	/// </summary>
	/// <returns>The displacement.</returns>
	/// <param name="i_initialVelocity">Initial velocity.</param>
	/// <param name="i_predictedTime">Predicted time.</param>
	/// <param name="i_acceleration">Acceleration.</param>
	public float ReturnDisplacementUTA (float i_initialVelocity, float i_predictedTime, float i_acceleration) {
		float displacement = (i_initialVelocity * i_predictedTime) + ((i_acceleration * i_predictedTime * i_predictedTime) * 0.5f);
		return displacement;
	}

	/// <summary>
	/// Returns the displacement given the final velocity, the time and the acceleration.
	/// </summary>
	/// <returns>The displacement.</returns>
	/// <param name="i_finalVelocity">Final velocity.</param>
	/// <param name="i_predictedTime">Predicted time.</param>
	/// <param name="i_acceleration">Acceleration.</param>
	public float ReturnDisplacementVTA (float i_finalVelocity, float i_predictedTime, float i_acceleration) {
		float displacement = (i_finalVelocity * i_predictedTime) - ((i_acceleration * i_predictedTime * i_predictedTime) * 0.5f);
		return displacement;
	}

	/// <summary>
	/// Returns the final velocity given the initial velocity, the acceleration and the time.
	/// </summary>
	/// <returns>The final velocity.</returns>
	/// <param name="i_initialVelocity">Initial velocity.</param>
	/// <param name="i_acceleration">Acceleration.</param>
	/// <param name="i_predictedTime">Predicted time.</param>
	public float ReturnFinalVelocityUAT (float i_initialVelocity, float i_acceleration, float i_predictedTime) {
		float finalVelocity = i_initialVelocity + (i_acceleration * i_predictedTime);
		return finalVelocity;
	}

	/// <summary>
	/// Returns the final velocity given initial velocity, the acceleration and the displacement.
	/// </summary>
	/// <returns>The final velocity.</returns>
	/// <param name="i_initialVelocity">Initial velocity.</param>
	/// <param name="i_acceleration">Acceleration.</param>
	/// <param name="i_displacement">Displacement.</param>
	public float ReturnFinalVelocityUAS (float i_initialVelocity, float i_acceleration, float i_displacement) {
		float finalVelocity = Mathf.Sqrt ((i_initialVelocity * i_initialVelocity) + (2 * i_acceleration * i_displacement));
		return finalVelocity;
	}

	/// <summary>
	/// Return an array with the two values from the quadratic equation. First value is for the positive sign and second is for the negative.
	/// </summary>
	/// <returns>Two float values.</returns>
	/// <param name="i_a">Parameter A</param>
	/// <param name="i_b">Parameter B</param>
	/// <param name="i_c">Parameter C</param>
	public ArrayList QuadraticEquation (float i_a, float i_b, float i_c) {
		ArrayList array = new ArrayList (2);

		float resultPos = (-i_b + Mathf.Sqrt ((i_b * i_b) - (4 * i_a * i_c))) / (2 * i_a);
		float resultNeg = (-i_b - Mathf.Sqrt ((i_b * i_b) - (4 * i_a * i_c))) / (2 * i_a);

		array.Add (resultPos);
		array.Add (resultNeg);

		print ("QuadraticEquation > positive: " + resultPos);
		print ("QuadraticEquation > negative: " + resultNeg);

		return array;
	}

}