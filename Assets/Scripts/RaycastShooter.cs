using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShooter : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))                                    //���콺 ��Ŭ��(0�� ��ư)�� ���� ��
        {
            ShootRay();
        }
    }

    //���̸� �߻��ϴ� �Լ�

    void ShootRay()
    {
        Ray ray = new Ray(transform.position, transform.forward);        //�߻��� Ray�� ������, ���� ����(���� ī�޶󿡼� ���콺 Ŀ�� �������� �߻�)
        RaycastHit hit;                                                     //Ray�� ���� ����� ������ ������ �����

        if (Physics.Raycast(ray, out hit))                                  //Raycast�� ��ȯ���� bool��, Ray�� �¾Ҵٸ� true ��ȯ
        {
            Destroy(hit.collider.gameObject);                               //���� ��� ������Ʈ�� ����
        }
    }
}
