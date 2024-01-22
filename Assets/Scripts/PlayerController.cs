using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeadZone"))
        {
            transform.GetChild(0).parent = null;
            GameManager.instance.Death();
        }
    }

    void Update()
    {
        if (JSONInput.data == null) { return; }
        if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0) { return; }
        Vector3 move = Vector3.forward * Input.GetAxis("Vertical") + Vector3.right * Input.GetAxis("Horizontal");
        rb.velocity = move * JSONInput.data.player_data.speed;
    }
}
