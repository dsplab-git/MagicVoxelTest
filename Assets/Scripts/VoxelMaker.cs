using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelMaker : MonoBehaviour
{
    // 생성할 대상 등록
    public GameObject voxelFactory;
    
    // 오브젝트 풀의 크기
    public int voxelPoolSize = 20;

    // 오브젝트 풀
    public static List<GameObject> voxelPool = new List<GameObject>();

    // 크로스헤어 변수
    public Transform crosshair;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < voxelPoolSize ; i++)
        {
            // 복셀 생성
            GameObject voxel = Instantiate(voxelFactory);

            // 복셀 비활성화
            voxel.SetActive(false);
            // 복셀을 오브젝트 풀에 추가
            voxelPool.Add(voxel);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //크로스헤어 그리기
        ARAVRInput.DrawCrosshair(crosshair);

        if(ARAVRInput.GetDown(ARAVRInput.Button.One))
        {
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Ray ray = new Ray(ARAVRInput.RHandPosition, ARAVRInput.RHandDirection);
            RaycastHit hitInfo = new RaycastHit();

            if(Physics.Raycast(ray, out hitInfo))
            {
                if(voxelPool.Count > 0)  // 오브젝트 풀 안에 voxel이 있는지 확인
                {
                    GameObject voxel = voxelPool[0];          // 오브젝트 풀 최상단의 값을 가져옴
                    voxel.SetActive(true);                    // 객체를 활성화 함
                    voxel.transform.position = hitInfo.point; // RayCast를 통해 얻은 충돌지점의 위치로 객체를 이동
                    voxelPool.RemoveAt(0);                    // 오브젝트 풀에서 voxel 1개 제거
                }
            }
        }
    }
}
