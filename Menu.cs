using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    public Vector3 endPos;
    public Vector3 endRot;
    public float time;

    private GameObject mainCamera;
    private Katapult katapult;

    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
		GameObject go = GameObject.Find("КАТАПУЛЬТА");
        katapult = (Katapult)go.GetComponent(typeof(Katapult));
    }
    void OnMouseDown()
    {
        if (gameObject.name == "Start Game")
        {
            StartCoroutine(MoveObject(mainCamera, mainCamera.transform.position, endPos, mainCamera.transform.rotation.eulerAngles, endRot, time));
        }
    }
    IEnumerator MoveObject(GameObject body, Vector3 startPos, Vector3 endPos, Vector3 startRot, Vector3 endRot, float time)
    {
        float i = .0f;
        float rate = 1.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            body.transform.position = Vector3.Lerp(startPos, endPos, i);
            body.transform.rotation = Quaternion.Euler(Vector3.Lerp(startRot, endRot, i));
            yield return new WaitForEndOfFrame();
        }
		GameObject.Find("КАТАПУЛЬТА").GetComponent<Animator>().SetBool("Shoot", true);
        katapult.StartCoroutine(katapult.MoveObject());
    }
}

