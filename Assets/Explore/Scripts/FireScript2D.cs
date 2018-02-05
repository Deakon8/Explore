using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript2D : MonoBehaviour {

	public float speed = 10; // скорость пули
	public Rigidbody2D bullet; // префаб нашей пули
	public Transform gunPoint; // точка рождения
	public float fireRate = 1; // скорострельность

	public Transform zRotate; // объект для вращения по оси Z

	// ограничение вращения
	public float minAngle = -40;
	public float maxAngle = 40;

	private float curTimeout;
	public static bool throww = false;

	void Start()
	{
	}

	void SetRotation()
	{
		Vector3 mousePosMain = Input.mousePosition;
		mousePosMain.z = Camera.main.transform.position.z; 
		Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePosMain);
		lookPos = lookPos - transform.position;
		float angle  = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
		angle = Mathf.Clamp(angle, minAngle, maxAngle);
		zRotate.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

	void Update()
	{
		if(Input.GetKeyDown (KeyCode.Q))
		{
			if (player.mp > 15) {
				StartCoroutine (throww_func ());
				Fire ();
				player.mp = player.mp - 15;
				if (player.mp <= 0) {player.mp = 0;}
			}
		}
		else
		{
			curTimeout = 100;
		}

		if(zRotate) SetRotation();
	}

	void Fire()
	{
		curTimeout += Time.deltaTime;
		if(curTimeout > fireRate)
		{
			curTimeout = 0;
			Rigidbody2D clone = Instantiate(bullet, gunPoint.position, Quaternion.identity) as Rigidbody2D;
			clone.velocity = transform.TransformDirection(gunPoint.right * speed);
			clone.transform.right = gunPoint.right;
		}
	}
	public IEnumerator throww_func() {
		if (throww == false) {
			throww = true;
			yield return new WaitForSeconds(0.5f);
			throww = false;
		}
	}
}
