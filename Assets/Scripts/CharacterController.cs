using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Animator playerAnimator;
    private AnimatorStateInfo animatorState;
    private AnimatorStateInfo animatorStateWave;
    public CapsuleCollider playerCollider;
    public Transform objectToGrab;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();        
    }

    // Update is called once per frame
    void Update()
    {
        playerAnimator.SetFloat("speed", Input.GetAxis("Vertical"));
        playerAnimator.SetFloat("direction", Input.GetAxis("Horizontal"));

        playerCollider.height = playerAnimator.GetFloat("colliderHeight");
        Physics.gravity = Vector3.up * playerAnimator.GetFloat("gravity");

        if (Input.GetKeyDown(KeyCode.V))
        {
            playerAnimator.SetTrigger("attack");
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            playerAnimator.SetTrigger("grab");
        }
    }


}
