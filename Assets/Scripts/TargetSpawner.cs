using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{

    public GameObject panelPrefab;              //���� ������(������Ʈ)

    public float generateTime = 3f;

    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(panelPrefab);               //���� ������Ʈ�� Scene�� ������ �����Ѵ�.
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;                                        //timer �������� deltaTime�� ���� ���� �ð� ����

        if (timer <= 0)                                                 //timer�� 0���� �۰ų� ���� ��
        {
            timer = generateTime;                                       //timer�� ����� �ð��� �־� �ʱ�ȭ

            float xPosition = Random.Range(-10f, 10f);                  //-10~10 ������ ������ �Ǽ����� xPosition�� ����
            Vector3 newPos = new Vector3(xPosition, 0, 0);              //������ ���Ӱ� ���� Position ��
            Instantiate(panelPrefab, newPos, Quaternion.identity);      //���� �������� newPos ��ġ�� ������
        }
    }
}
