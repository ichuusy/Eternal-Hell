using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [SerializeField] private ParticleSystem _partEffect;
    [SerializeField] private ParticleSystem _bloodEffect;
    [SerializeField] private SkinnedMeshRenderer _renderer;
    [SerializeField] private AudioSource _clip;
    
    private Counters _counterComponent;
    void Start()
    {
        _clip = GetComponent<AudioSource>();
        _counterComponent = GameObject.FindWithTag("Player").GetComponent<Counters>();
    }

    public IEnumerator KillEnemy()
    {
        _clip.Play();
        _counterComponent.COUNT += 1;
        _partEffect.Play();
        _bloodEffect.Play();
        _renderer.enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);


    }
}
