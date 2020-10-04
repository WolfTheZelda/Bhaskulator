using UnityEngine;

public class ScreenScale : MonoBehaviour
{    
	void Update ()
	{
        transform.localScale = new Vector3 ((1.70f * Screen.width / Screen.height), transform.localScale.y, transform.localScale.z);
	}
}