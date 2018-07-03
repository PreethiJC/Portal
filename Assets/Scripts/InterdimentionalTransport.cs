using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Rendering;
public class InterdimentionalTransport : MonoBehaviour {

	public Material[] materials;

	public Transform device;

	private bool wasInFront, inOtherWorld;
	
	// Use this for initialization
	void Start () 
	{
		SetMaterials(false);
	}

	void SetMaterials(bool fullRenderer)
	{
		var stencilTest = fullRenderer ? CompareFunction.NotEqual : CompareFunction.Equal;
		
		foreach (var mat in materials)
		{
			mat.SetInt("_StencilTest", (int)stencilTest);
		}
	}

	bool GetIsInFront()
	{
		Vector3 pos = transform.InverseTransformPoint(device.position);
		return pos.z >= 0 ? true : false;
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.transform != device)
			 return;
		wasInFront = GetIsInFront();
	}

	private void OnTriggerStay(Collider other)
	{
		print("wasInFront = " + wasInFront);
		print("inOtherWorld = " + inOtherWorld);
		
		if (other.transform != device)
			return;
		
		bool isInFront = GetIsInFront();
		print("isInFront = " + isInFront);
		
		if ((isInFront && !wasInFront) || (!isInFront && wasInFront))
		{
			inOtherWorld = !inOtherWorld;
			print("inOtherWorld = " + inOtherWorld);
			SetMaterials(inOtherWorld);
		}

		wasInFront = isInFront;
	}

	private void OnDestroy()
	{
		SetMaterials(true);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
