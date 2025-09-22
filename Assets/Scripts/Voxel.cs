using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voxel : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5;
    public float destroyTime = 5.0f;
    float currentTime = 0;
    void OnEnable()
    {
        currentTime = 0;
        Vector3 direction = Random.insideUnitSphere;  // 크기가 1이고 방향만 존재함
        
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity  = direction * speed;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = currentTime + Time.deltaTime;
        if(currentTime > destroyTime) // 시간 초과
        {
            gameObject.SetActive(false);    // 자기 자신을 비활성화 함
            VoxelMaker.voxelPool.Add(gameObject);  // VoxelMaker의 오브젝트풀에 자기 자신을 추가

            //Destroy(gameObject);
        }
    }
}
