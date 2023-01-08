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
        // 協程開始
        StartCoroutine(CamMove());
    }

    private void Update()
    {
        // 紀錄現在位置
        Vector3 camTarget = cam.transform.position;

        // 緩慢移動至指定的位置
        cam.transform.position = Vector3.Lerp(camTarget, v[j], 10 * Time.deltaTime);
    }

    // 協程
    IEnumerator CamMove()
    {
        // for迴圈
        for (int i = 0; i < 5; i++)
        {
            // 停兩秒
            yield return new WaitForSeconds(2);

            // 照順序更改指定位置
            j++;
        }
    }
}
