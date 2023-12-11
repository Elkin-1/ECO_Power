using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Pegar : MonoBehaviour
{   
    
    private CharacterController personaje;

    Vector3 groundPosition;
    Vector3 lastGroundPosition;

    string groundName;
    string lastGroundName;



    // Start is called before the first frame update
    void Start()
    {
        personaje = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(personaje.isGrounded)
        {
            RaycastHit hit;

            if(Physics.SphereCast(transform.position, personaje.height / 4.2f, -transform.up, out hit))
            {
                GameObject groundedIn = hit.collider.gameObject;
                groundName = groundedIn.name;
                groundPosition = groundedIn.transform.position;

                if(groundPosition != lastGroundPosition && groundName == lastGroundName)
                {
                    this.transform.position += groundPosition - lastGroundPosition;
                }

                lastGroundName = groundName;
                lastGroundPosition = groundPosition;

            }
        }
        else if(!personaje.isGrounded)
        {
            lastGroundName = null;
            lastGroundPosition = Vector3.zero;
        }
    }

    private void OnDrawGizmos()
    {
        personaje = GetComponent<CharacterController>();
        Gizmos.DrawWireSphere(transform.position, personaje.height / 4.2f);
    }


}
