using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PhysicMovement : MonoBehaviour
{
    public float moveSpeed = 20f;              //�̵��ӵ�
    public float junpForce = 5f;

    public Rigidbody rb;                                //Rigidbody ������Ʈ�� �޾ƿ� ����

    private bool isGrounded = false;                                 //�ٴڿ� ��Ҵ��� Ȯ���� ����
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");  //�¿� �̵�
        float moveY = Input.GetAxis("Vertical");    //�յ� �̵�

        Vector3 moveDirection = new Vector3(moveX, 0, moveY).normalized;        //�̵� ���� ����

        //Rigidbody�� ���� �־� �̵�
        rb.MovePosition(transform.position + moveDirection * moveSpeed * Time.deltaTime);

        //���� ó��
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * junpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionStay(Collision collision)           //��ü�� �浹�� �� ��
    {
        isGrounded = true;          //�ٴڿ� ��Ҵٰ� üũ
    }

    private void OnCollisionExit(Collision collision)           //��ü�� ���� ������ ��
    {
        isGrounded = false;
    }
}
