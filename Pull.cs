using UnityEngine;
using System.Collections;

public class Pull : MonoBehaviour
{
    private Vector3 direction;
	public float force = .5f;
	public GameObject teleportTo;
	public float waitBeforePull = 1f;
    public Color changeColorColor1 = Color.red;
    public Color changeColorColor2 = Color.blue; 

    void Start()
    {
		direction = new Vector3(Mathf.Cos(transform.eulerAngles.y), 0, Mathf.Sin(transform.eulerAngles.y));
		Transform water = transform.FindChild("WaterPartSystem");
		for (int i = 0; i < 2; ++i) water.GetChild(i).gameObject.particleSystem.Stop ();
		Transform teleport = transform.FindChild("TeleportPartSystem");
		teleport.gameObject.particleSystem.Stop();
		teleport.transform.GetChild(0).gameObject.light.enabled = false;

    }

	private void changeColor()
	{
		Transform changesColor = transform.FindChild("Flag");
        if (changesColor.gameObject.renderer.material.color == changeColorColor1)
            changesColor.gameObject.renderer.material.color = changeColorColor2;
        else changesColor.gameObject.renderer.material.color = changeColorColor1;
	}

	private void enableWater()
	{
		Transform water = transform.FindChild("WaterPartSystem");
		for (int i = 0; i < 2; ++i) water.GetChild(i).gameObject.particleSystem.Play ();
	}

	private void enableTeleport()
	{
		Transform teleport = transform.FindChild("TeleportPartSystem");
		teleport.gameObject.particleSystem.Play ();
		teleport.transform.GetChild(0).gameObject.light.enabled = true;
	}

	private void disableWater()
	{
		Transform water = transform.FindChild("WaterPartSystem");
		for (int i = 0; i < 2; ++i) water.GetChild(i).gameObject.particleSystem.Stop ();
	}
	
	private void disableTeleport()
	{
		Transform teleport = transform.FindChild("TeleportPartSystem");
		teleport.gameObject.particleSystem.Stop ();
		teleport.transform.GetChild(0).gameObject.light.enabled = false;
	}


    void OnTriggerEnter(Collider objCollide)
    {
        StartCoroutine(stopBall(objCollide));
    }

    void OnTriggerExit()
    {
        StopCoroutine("stopBall");

    }
    IEnumerator stopBall(Collider objCollide)
    {
		enableTeleport ();
		changeColor ();
		enableWater ();
        objCollide.transform.position = teleportTo.transform.position;
		objCollide.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        yield return new WaitForSeconds(waitBeforePull);
		objCollide.rigidbody.constraints = RigidbodyConstraints.None;
		objCollide.rigidbody.AddForce(direction * force, ForceMode.Impulse);
		disableWater ();
		disableTeleport ();
	}
}
