using UnityEngine;
using System.Collections;

public class Flipper : MonoBehaviour
{

    public KeyCode Key = KeyCode.LeftArrow;

    private float angle;
    public GameObject wheel;

    void Start()
    {
        angle = GetComponent<HingeJoint>().spring.targetPosition;
        rigidbody.centerOfMass = Vector3.zero;
    }

	void FixedUpdate ()
	{
	    var spring = GetComponent<HingeJoint>().spring;
        if (Input.GetKey(Key))
	    {
	        spring.targetPosition = -angle;
            StartCoroutine(RotateObject(wheel, wheel.transform.rotation.eulerAngles, new Vector3(.0f, 1.0f, .0f), 1f));
	    } else
	    {
	        spring.targetPosition = angle;
	    }
	    GetComponent<HingeJoint>().spring = spring;
	}
    IEnumerator RotateObject(GameObject body, Vector3 startRot, Vector3 endRot, float time)
    {
        float i = .0f;
        float rate = 1.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            body.transform.rotation = Quaternion.Euler(Vector3.Lerp(startRot, endRot, i));
            yield return new WaitForEndOfFrame();
        }
    }
}
