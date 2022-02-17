using UnityEngine;
using System.Collections;

public class Katapult : MonoBehaviour {

    public Vector3 targetPoint = Vector3.zero;
    public Vector3 heighPoint = Vector3.zero;
    public GameObject body;
    public float time = 1f;

    //void Start()
    //{
    //    StartCoroutine(MoveObject());
    //}

    public IEnumerator MoveObject(){
        body.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        float i = .0f;
        float rate = 1.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            body.transform.position = Vector3.Lerp(body.transform.position, heighPoint, i);
            yield return null;
        }
        i = .0f;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            body.transform.position = Vector3.Lerp(heighPoint, targetPoint, i);
            yield return null;
        }
        body.rigidbody.constraints = RigidbodyConstraints.None;
        GameObject.Find("КАТАПУЛЬТА").GetComponent<Animator>().SetBool("Shoot", false);
    }
}

