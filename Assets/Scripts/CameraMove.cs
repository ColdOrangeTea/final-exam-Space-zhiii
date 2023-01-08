using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    public Vector3[] v = {new Vector3(0, 0, -10), new Vector3(0, -12.3f, -10), new Vector3(-1.96f, 0, -10), new Vector3(-1.96f, -12.3f, -10), new Vector3(-13, 0, -10), new Vector3(-13, -12.3f, -10) };
    int j = 0;

    void Start()
    {
        // ��{�}�l
        StartCoroutine(CamMove());
    }

    private void Update()
    {
        // �����{�b��m
        Vector3 camTarget = cam.transform.position;

        // �w�C���ʦܫ��w����m
        cam.transform.position = Vector3.Lerp(camTarget, v[j], 10 * Time.deltaTime);
    }

    // ��{
    IEnumerator CamMove()
    {
        // for�j��
        for (int i = 0; i < 5; i++)
        {
            // �����
            yield return new WaitForSeconds(2);

            // �Ӷ��ǧ����w��m
            j++;
        }
    }
}
