using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private GameObject _fireballPrefab;
    [SerializeField] private GameObject _fireballSpawner;
    [SerializeField] private float _fireballTime;
    [SerializeField] private float _walkSpeed;
    private GameObject _target;
    private Animator _anim;
    private bool _targetInsideField;
    private float _lastFireballUsedTime;
    void Start()
    {
        _anim = GetComponent<Animator>();
        _target = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
        {
            Destroy(this.gameObject);
        }
        var lookPos = _target.transform.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 4);
        if (_targetInsideField)
        {
            transform.position = Vector3.Lerp(transform.position, _target.transform.position, Time.deltaTime * (Random.Range((_walkSpeed-0.5f),(_walkSpeed+0.5f))));
            _anim.SetBool("Walk", true);
            if (Time.time - _lastFireballUsedTime > _fireballTime)
            {
                _lastFireballUsedTime = Time.time;
                _anim.SetTrigger("Attack");
                GameObject fireball = Instantiate(_fireballPrefab, _fireballSpawner.transform.position,Quaternion.identity);
                fireball.transform.rotation = Quaternion.Euler(_target.transform.localEulerAngles);
            }
        }
        else if (!_targetInsideField)
        {
            _anim.SetBool("Walk", false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _targetInsideField = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _targetInsideField = false;
        }
    }
}
