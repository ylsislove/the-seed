using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitBehaviour : MonoBehaviour
{
    public GameObject playerCtrl;

    public ReticleBehaviour reticle;

    public float speed;

    private Animator _animator;

    private void OnTriggerEnter(Collider other)
    {
        var carrot = other.GetComponent<CarrotBehaviour>();
        if (carrot != null)
        {
            Destroy(other.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        var trackingPosition = reticle.transform.position;

        _animator = gameObject.GetComponent<Animator>();

        if (Vector3.Distance(trackingPosition, transform.position) < 0.2)
        {
            _animator.SetBool("Run", false);
            return;
        }
        
        _animator.SetBool("Run", true);

        var lookRotation = Quaternion.LookRotation(trackingPosition - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
        transform.position = Vector3.MoveTowards(transform.position, trackingPosition, speed * Time.deltaTime);
    }
}
