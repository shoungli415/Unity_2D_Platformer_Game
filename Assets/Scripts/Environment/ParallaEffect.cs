using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaEffect : MonoBehaviour
{
    public Camera cam;
    public Transform followTarget; // �÷��̾� Transform

    Vector2 startingPosition; // ���� Transform�� Position;


    // -1.2, -0.6, -0.24�� ���ϰ� �÷��̾��� �������� z���� ����
    float startingZ;
    
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        startingZ = transform.position.z - followTarget.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        // ī�޶�� ���� ���� ���� ��ġ�� ���� Vector2
        Vector2 camMoveSinceStart = (Vector2)cam.transform.position - startingPosition;

        // ���� �ٴ� ĳ����(�÷��̾�)�� �� ������Ʈ�� z�� �Ÿ� ��
        float zDistanceFromTarget = transform.position.z - followTarget.transform.position.z;

        //���� ������
        // int a = (����) ? (��) : (����) 
        // BG1�� ���
        // Cam.transform.Position.z = -10;
        // zDistanceFromTarget = -1.2;
        // ClippingPlane = cam.nearClipPlane;
        float clippingPlane = ((cam.transform.position.z) + zDistanceFromTarget) > 0 ?
            cam.farClipPlane : cam.nearClipPlane;

        float parallaFactore = Mathf.Abs(zDistanceFromTarget) / clippingPlane;

        Vector2 newPosition = startingPosition + camMoveSinceStart / parallaFactore;

        transform.position = new Vector3(newPosition.x, newPosition.y, startingZ);
    }
}
