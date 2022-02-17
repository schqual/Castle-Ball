using UnityEngine;
using System.Collections;

public class Bouncer : MonoBehaviour
{

    public float force = 1f;
    public float scaleAnim = 1.5f;
    public float timeSpeed = 10f;
    public int countPoints = 100;

    private Vector3 newScale;
    private Vector3 oldScale;

    private GUIPoints guiPoints;

    void Start()
    {
        oldScale = transform.localScale;
        newScale = oldScale * scaleAnim;
        GameObject go = GameObject.Find("Main Camera");
        guiPoints = (GUIPoints)go.GetComponent(typeof(GUIPoints));
    }

    void OnCollisionEnter(Collision collision)
    {
        guiPoints.increasePoints(countPoints);
        Vector3 direction = collision.transform.position - collision.contacts[0].point;
        direction.Normalize();
        direction *= force;
        collision.rigidbody.AddForce(direction, ForceMode.VelocityChange);
        StartCoroutine(ScaleObject(timeSpeed, oldScale, newScale));
    }

    IEnumerator ScaleObject(float time, Vector3 scale1, Vector3 scale2)
    {
        var originalTime = time;

        while (time > 0.0f)
        {
            time -= Time.deltaTime;
            transform.localScale = Vector3.Lerp(scale2, scale1, time / originalTime);
            yield return null;
        }

        time = originalTime;

        while (time > 0.0f)
        {
            time -= Time.deltaTime;
            transform.localScale = Vector3.Lerp(scale1, scale2, time / originalTime);
            yield return null;
        }


    }
}

