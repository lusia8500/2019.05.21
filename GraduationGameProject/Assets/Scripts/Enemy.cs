using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    NavMeshAgent pathfinder;
    Transform target;

    public float health = 100;

    public int value = 50;

    public GameObject deathEffect;

	// Use this for initialization
	void Start () {
        pathfinder = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("END").transform;
	}

    public void TakeDamage(float amount)
    {
        Debug.Log("TakeDamage");
        health -= amount;
        if(health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Die");
        PlayerStats.Money += value;
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
        pathfinder.SetDestination(target.position);

        if(Vector3.Distance(target.position,transform.position) < 1.0f)
        {
            EndPath();
        }
	}

    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}
