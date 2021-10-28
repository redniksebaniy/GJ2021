using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    AudioSource step;

    public float speed = 12f;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = -0.9f;
    public LayerMask groundMask;

    Vector3 velocity;

    void Start()
    {
        step = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (controller.isGrounded && velocity.y < 0) velocity.y = -2f;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (controller.isGrounded && !step.isPlaying && (x != 0 || z != 0))
        {
            step.pitch = Random.Range(0.7f, 1.3f);
            step.volume = Random.Range(0.7f, 1f);
            step.Play();
        }

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        
    }

    public void setSpeed(float newspeed) { speed = newspeed; }
}
