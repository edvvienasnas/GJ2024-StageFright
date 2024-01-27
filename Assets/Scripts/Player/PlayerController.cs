using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject weapon;
    [SerializeField] private int movementSpeed = 1;
    private Vector3 cameraOffset;
    private Camera playerCamera;
    private Animation weaponSwingAnim;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();

        playerCamera = FindFirstObjectByType<Camera>();
        weaponSwingAnim = weapon.GetComponent<Animation>();

        cameraOffset.y = playerCamera.transform.position.y;
        cameraOffset.z = playerCamera.transform.position.z;

        weapon.SetActive(false);
    }

    private void Update()
    {
        // Player movement
        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            anim.SetBool("isWalking", true);

            var moveDirection = new Vector3(
                Input.GetAxisRaw("Horizontal"),
                0,
                Input.GetAxisRaw("Vertical"));

            transform.Translate(moveDirection * movementSpeed * Time.deltaTime, Space.World);
            transform.rotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            // transform.position += new Vector3(
            //     Input.GetAxisRaw("Horizontal") * movementSpeed * Time.deltaTime,
            //     0,
            //     Input.GetAxisRaw("Vertical") * movementSpeed * Time.deltaTime);
        }
        else if(Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            anim.SetBool("isWalking", false);
        }

        // Player attacking
        if(Input.GetButtonDown("Fire1"))
        {
            weapon.SetActive(true);
            weaponSwingAnim.Play();
            if(!weaponSwingAnim.isPlaying)
            {
                weapon.SetActive(false);
            }
        }
        if(weapon.activeSelf && !weaponSwingAnim.isPlaying)
        {
            weapon.SetActive(false);
        }
    }

    private void LateUpdate()
    {
        // Camera follow
        playerCamera.transform.position = new Vector3(
            transform.position.x,
            transform.position.y + cameraOffset.y,
            transform.position.z + cameraOffset.z
        );
    }
}
