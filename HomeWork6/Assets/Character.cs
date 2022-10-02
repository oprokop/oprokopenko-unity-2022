using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float movementSpeed = 2.0f;
    public float sprintSpeed = 5.0f;
    public float rotationSpeed = 0.2f;
    public float animationBlendSpeed = 0.2f;
    public float jumpSpeed = 7.0f;
    public int attackAnimationCount;

    CharacterController controller;
    Animator animator;
    Camera characterCamera;

    [SerializeField] float rotationAngle = 0.0f;
    [SerializeField] float targetAnimationSpeed = 0.0f;
    [SerializeField] bool isSprint = false;

    [SerializeField] float speedY = 0.0f;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] bool isJumping = false;

    [SerializeField] bool isSpawn = true;
    [SerializeField] float spawnTime = 2.0f;
    [SerializeField] bool isDead = false;
    [SerializeField] bool isAttack = false;
    [SerializeField] float attackTime = 0.5f;


    public CharacterController Controller { get { return controller = controller ?? GetComponent<CharacterController>(); } }
    public Camera CharacterCamera { get { return characterCamera = characterCamera ?? FindObjectOfType<Camera>(); } }
    public Animator CharacterAnimator { get { return animator = animator ?? GetComponent<Animator>(); } }

    void Update()
    {
        if (spawnTime > 0)
        {
            spawnTime -= Time.deltaTime;
        }
        else { isSpawn = false; }
        
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.D))
        {
            CharacterAnimator.SetTrigger("Dead");
            isDead = true;
        }
        
        if (!Controller.isGrounded && isJumping)
        {
            speedY += gravity * Time.deltaTime;
        }
        else if(speedY < 0.0f)
        {
            speedY = 0.0f;
        }
        CharacterAnimator.SetFloat("SpeedY", speedY / jumpSpeed);
        if(isJumping && speedY < 0.0f)
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position, Vector3.down, out hit, 1f, LayerMask.GetMask("Default")))
            {
                isJumping = false;
                CharacterAnimator.SetTrigger("Land");
            }
        }

        if (isSpawn == false && isDead == false)
        {
            if (Input.GetMouseButtonDown(0) && isAttack == false)
            {
                CharacterAnimator.SetTrigger("Attack");
                int currentAttackNumber = Random.Range(0, attackAnimationCount);
                CharacterAnimator.SetInteger("AttackId", currentAttackNumber);
                isAttack = true;
            }
            if (attackTime > 0 && isAttack == true)
            {
                attackTime -= Time.deltaTime;
            }
            else 
            { 
                isAttack = false;
                attackTime = 0.5f;
            }

            if (Input.GetButtonDown("Jump") && !isJumping)
            {
                isJumping = true;
                CharacterAnimator.SetTrigger("Jump");
                speedY += jumpSpeed;
            }

            isSprint = Input.GetKey(KeyCode.LeftShift);
            Vector3 movement = new Vector3(horizontal, 0.0f, vertical);
            Vector3 rotatedMovement = Quaternion.Euler(0.0f, CharacterCamera.transform.rotation.eulerAngles.y, 0.0f) * movement.normalized;
            Vector3 verticalMovement = Vector3.up * speedY;

            float currentSpeed = isSprint ? sprintSpeed : movementSpeed;
            Controller.Move(verticalMovement * currentSpeed * Time.deltaTime);

            if (rotatedMovement.sqrMagnitude > 0.0f)
            {
                rotationAngle = Mathf.Atan2(rotatedMovement.x, rotatedMovement.z) * Mathf.Rad2Deg;
                targetAnimationSpeed = isSprint ? 1.0f : 0.5f;
            }
            else
            {
                targetAnimationSpeed = 0.0f;
            }
            CharacterAnimator.SetFloat("Speed", Mathf.Lerp(CharacterAnimator.GetFloat("Speed"), targetAnimationSpeed, animationBlendSpeed));
            Quaternion currentRotation = Controller.transform.rotation;
            Quaternion targetRotation = Quaternion.Euler(0.0f, rotationAngle, 0.0f);
            Controller.transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, rotationSpeed);
        }
    }
    public void MeleeAttackStart(int num)
    {
        Debug.Log("MeleeAttackStart");
    }
    public void MeleeAttackEnd(int num)
    {
        Debug.Log("MeleeAttackEnd");
    }
}
