using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenoMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector3 moveDirection;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private Vector3 rotateDirection;

    private Transform senoModel;

    void Start()
    {
        senoModel = transform.GetChild(0);
    }

    
    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        senoModel.transform.Rotate(rotateDirection * rotateSpeed * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SenoDestroyTrigger") // other.CompareTag("SenoDestroyTrigger")
        {
            Destroy(gameObject);
        }



    }

}
