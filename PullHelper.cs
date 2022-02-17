using UnityEngine;
using System.Collections;

public class PullHelper : MonoBehaviour {

    public Vector3 targetPoint = Vector3.zero;
    public float moveTime = 1f;

    void OnCollisionEnter(Collision body)
    {
        body.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        StartCoroutine(MoveObject(body, body.transform.position, targetPoint, moveTime));
    }

    IEnumerator MoveObject(Collision body, Vector3 startPos, Vector3 endPos, float time){
        float i = .0f;
        float rate = 1.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            body.transform.position = Vector3.Lerp(startPos, endPos, i);
            yield return null;
        }

        body.rigidbody.constraints = RigidbodyConstraints.None;
    }
}

