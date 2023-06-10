using System.Collections;
using System.Collections.Generic;
using NRKernal;
using UnityEngine;

public class RabbitManager : MonoBehaviour
{
    public GameObject whiteRabbit;

    public ReticleBehaviour reticle;

    public RabbitBehaviour rabbit;

    private GameObject _lockedPlane;

    // Update is called once per frame
    void Update()
    {
        if (rabbit == null && WasTapped() && reticle.currentPlane != null)
        {
            var obj = Instantiate(whiteRabbit);
            rabbit = obj.GetComponent<RabbitBehaviour>();
            rabbit.reticle = reticle;
            rabbit.transform.position = reticle.transform.position;
        }
    }

    private bool WasTapped()
    {
        return NRInput.GetButtonDown(ControllerButton.TRIGGER);
    }
}
