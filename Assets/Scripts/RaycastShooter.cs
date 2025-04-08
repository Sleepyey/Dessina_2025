using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RaycastShooter : MonoBehaviour
{
    public ParticleSystem flashEffect;          //�߻� ����Ʈ ���� ����

    //źâ ���� ���� ����
    public int magazineCapzcity = 30;           //źâ�� ũ��
    private int currntAmmo;                      //���� �Ѿ� ����

    public TextMeshProUGUI ammoUI;              //�Ѿ� ������ ��Ÿ�� TextMeshPriUGUI ����

    public Image reloadingUI;                   //������ UI
    public float reloadTime = 2f;               //������ �ð�
    private float timer = 0;                    //�ð� Ȯ�ο� Ÿ�̸�
    private bool isReloading = false;           //������ Ȯ�ο� bool ����

    public AudioSource audioSource;             //����� �ҽ�
    public AudioClip audioClip;                 //����� Ŭ��

    void Start()
    {
        currntAmmo = magazineCapzcity;                  //���� �Ѿ��� ������ źâ�� ũ�⸸ŭ���� ����
        //ammoUI.text = currntAmmo + "/" + magazineCapzcity;
        ammoUI.text = $"{currntAmmo}/{magazineCapzcity}";   //���� �Ѿ� ������ UI�� ǥ��

        reloadingUI.gameObject.SetActive(false);            //������ UI ��Ȱ��ȭ
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currntAmmo > 0 && isReloading == false)                                    //���콺 ��Ŭ��(0�� ��ư)�� ���� ��
        {
            audioSource.PlayOneShot(audioClip);                 //�߻� ���� ���
            currntAmmo--;
            flashEffect.Play();                 //����Ʈ ���
            ammoUI.text = $"{currntAmmo}/{magazineCapzcity}";   //���� �Ѿ� ������ UI�� ǥ�� (�Ѿ� �Һ� �� ǥ��!)
            ShootRay();
        }

        if (Input.GetKeyDown(KeyCode.R) && currntAmmo != magazineCapzcity)                    //RŰ�� ������ (���� �Ѿ� ������ �ִ� �Ѿ� ������ ���� ���� ��)
        {
            isReloading = true;                             //������ ������ ����
            reloadingUI.gameObject.SetActive(true);         //������ UI Ȱ��ȭ
        }

        if (isReloading == true)
        {
            Reloading();
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

    void Reloading()
    {
        timer += Time.deltaTime;

        reloadingUI.fillAmount = timer / reloadTime;                    //������ UI�� fill ���� ���� ������� ������Ʈ

        if (timer >= reloadTime)                                        //������ �ð��� ������ ���
        {
            timer = 0;
            isReloading = false;                                        //�������� �Ϸ� ������ ǥ��
            currntAmmo = magazineCapzcity;                              //�Ѿ��� ä���ش�.
            ammoUI.text = $"{currntAmmo}/{magazineCapzcity}";           //���� �Ѿ� ������ ǥ��
            reloadingUI.gameObject.SetActive(false);                    //������ UI ������Ʈ�� ��Ȱ��ȭ
        }
    }
}
