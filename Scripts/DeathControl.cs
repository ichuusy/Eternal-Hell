using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathControl : MonoBehaviour
{
    [SerializeField] private byte _maxLimit;
	public GameObject[] randomSpawner;
	private Health _health;
	private Counters _counters;
	private Ammo _ammo;

	void Start()
	{
		_health = GetComponent<Health>();
		_counters = GetComponent<Counters>();
		_ammo = GetComponent<Ammo>();
	}

    void FixedUpdate()
    {
        if (transform.position.y < -_maxLimit)
        {
            KillCharacter();
        }
		if(_health.HP <= 0)
		{
			KillCharacter();
		}
    }

    public void KillCharacter()
    {
	    SpawnRandomPosition();
		_health.HP = 100;
		_counters.ResetCount();
		_ammo.AMMO = 100;
    }

    public void SpawnRandomPosition()
    {
        transform.position = randomSpawner[Random.Range(0,randomSpawner.Length)].transform.position;
    }
}
