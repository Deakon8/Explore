using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyDistant : MonoBehaviour {
	public float HP = 100;
	public float speed;
	private Animator animator;
	// Переменные использующиеся для патрулирования.
	public Transform[] points = new Transform[2];
	Rigidbody2D EnemyRb;
	SpriteRenderer SpriteEnemy;
	bool OnRight;
	// Переменные для преследования игрока.
	public Transform target;
	public float seeDistance = 5f;
	public float attackDistance = 2f;
	// Для атаки 
	public Rigidbody2D bullet; // префаб нашей пули
	private float speedBulletCur; // скорость пули текущая
	private Transform gunPoint; // точка рождения
	private float curTimeout;
	public float speedBullet = 10; // скорость пули
	public float fireRate = 1; // скорострельность
	public float delay; // Задержка перед первым выстрелом

	void Start () {
		gunPoint = this.gameObject.transform;
		target = GameObject.FindWithTag("Player").transform;
		animator = this.gameObject.GetComponent<Animator>();
	}
	void Awake () {
		SpriteEnemy = GetComponent<SpriteRenderer>();
		EnemyRb = GetComponent<Rigidbody2D>();
	}
	void Update () {
		curTimeout += Time.deltaTime;
		SpriteEnemy.flipX = OnRight;
		if (OnRight) {
			speedBulletCur = speedBullet;
		} else {
			speedBulletCur = -speedBullet;
		}
		// Преследование игрока
		if (Vector2.Distance(transform.position, target.transform.position) < seeDistance)
		{
			if (Vector2.Distance (transform.position, target.transform.position) > attackDistance && HP > 0) {
				//walk
				if (gameObject.transform.position.x < target.position.x) {
					OnRight = true;
				} else if (gameObject.transform.position.x > target.position.x) {
					OnRight = false;
				}
				if (OnRight) {
					EnemyRb.velocity = new Vector2 (speed + 1f, EnemyRb.velocity.y);
					animator.Play("Walk");
				} else {
					EnemyRb.velocity = new Vector2 (-speed - 1f, EnemyRb.velocity.y);
					animator.Play("Walk");
				}
			} else if (Vector2.Distance (transform.position, target.transform.position) > attackDistance || Vector2.Distance (transform.position, target.transform.position) < attackDistance && HP <= 0){
				animator.Play("Death");
				StartCoroutine (enemy_death ());
			} else {
				// Здесь должен быть скрипт нанесения урона.
				animator.Play ("Attack");
				StartCoroutine (enemy_attack ());
			}
		}
		else {
			// Патрулирование
			if (gameObject.transform.position.x < points [0].position.x) {
				OnRight = true;
			}
			else if (gameObject.transform.position.x > points [1].position.x) {
				OnRight = false;
			}
			if (OnRight) {
				EnemyRb.velocity = new Vector2 (speed, EnemyRb.velocity.y);
				animator.Play("Walk");
			}
			else {
				EnemyRb.velocity = new Vector2 (-speed, EnemyRb.velocity.y);
				animator.Play("Walk");
			}
		}
	}
	public IEnumerator enemy_death() {
		yield return new WaitForSeconds(0.9f);
		this.gameObject.SetActive (false);
		Destroy (this.gameObject);
	}
	public IEnumerator enemy_attack() {
		yield return new WaitForSeconds(delay);
		if (curTimeout > fireRate) {
			curTimeout = 0;
			Rigidbody2D clone = Instantiate (bullet, gunPoint.position, Quaternion.identity) as Rigidbody2D;
			clone.velocity = transform.TransformDirection (gunPoint.right * speedBulletCur);
			clone.transform.right = gunPoint.right;
		}
	}
}
