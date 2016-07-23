using UnityEngine;
using System.Collections;
//List Collection을 사용하기 위해 Generic도 사용합니다.
using System.Collections.Generic;

public class meshTest : MonoBehaviour {

    //ArrayList도 괜찮지만 편의상 List 객체로 선언해둡시다.
    //버텍스들의 위치를 저장할 객체입니다.
    public List<Vector3> _Vertex = new List<Vector3>();
    //다른 인접 버텍스의 Index값입니다.
    public List<int> _Tri = new List<int>();
    private Mesh mesh;
    public float width;
    public float height;

    //Cell간의 Gap이다. texture가 5x5이기 때문에  1/5 = 0.2;
    
    public List<Vector2> _cell = new List<Vector2>();
    public List<Vector2> _UV = new List<Vector2>();


    // Use this for initialization
    void Start () {
        // 시작하면 MeshFilter component를 가져옵니다.
        mesh = GetComponent<MeshFilter>().mesh;

        //Position 값
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;

        _Vertex.Add(new Vector3(x, y, z));             //0
        _Vertex.Add(new Vector3(x+ width, y, z));      //1
        _Vertex.Add(new Vector3(x + width, y- height, z));   //2
        _Vertex.Add(new Vector3(x , y - height, z));         //3
        _Vertex.Add(new Vector3(x+0.5f, y, z));        //4
        //버텍스 인덱스입니다.
        ////1번 폴리곤.
        //_Tri.Add(0);  // L up                  0--------1
        //_Tri.Add(1);  // R UP                  |        |
        //_Tri.Add(3);  // L B                   |        |
        ////2번 폴리곤.                          3--------2
        //_Tri.Add(1);
        //_Tri.Add(2);  // R B
        //_Tri.Add(3);




        //0---4---1  의 선분이 생겼을때..
        //1번 폴리곤은 더이상  0 --1이 아니라 0 --4 로 분할  2번 폴리곤도 4---1로 분할


        //1번 폴리곤.
        _Tri.Add(0);  // L up                  0---4-----1
        _Tri.Add(4);  // R UP                  |         |
        _Tri.Add(3);  // L B                   |         |
        //2번 폴리곤.                          3---------2
        _Tri.Add(3);
        _Tri.Add(4);  // R B
        _Tri.Add(2);

        //3번 폴리곤   
        _Tri.Add(4);
        _Tri.Add(1);
        _Tri.Add(2);

        // 정점 좌표
        _cell.Add(new Vector2(0, 0));
        _cell.Add(new Vector2(0.5f, 0));
        _cell.Add(new Vector2(1, 0));
        _cell.Add(new Vector2(0, 1));
        _cell.Add(new Vector2(1, 1));



        float _cellGap_x =  1/this.transform.GetComponent<MeshRenderer>().material.mainTexture.width;
        float _cellGap_y = 1 / this.transform.GetComponent<MeshRenderer>().material.mainTexture.height;
        Debug.Log(transform.GetComponent<MeshRenderer>().material.mainTexture.width);
        Debug.Log("x" + _cellGap_x);
        //텍스쳐의 좌표를 UV에 넣습니다.
        //만약 List 인덱스 0번이라면 (0,0), (0.2,0), (0, 0.2), (0.2, 0.2)의 값을 가지겠죠?
        _UV.Add(new Vector2(_cellGap_x * _cell[0].x             , _cellGap_y * _cell[0].y + _cellGap_y));
        _UV.Add(new Vector2(_cellGap_x * _cell[1].x + _cellGap_x, _cellGap_y * _cell[1].y + _cellGap_y));
        _UV.Add(new Vector2(_cellGap_x * _cell[2].x + _cellGap_x, _cellGap_y * _cell[2].y));
        _UV.Add(new Vector2(_cellGap_x * _cell[3].x             , _cellGap_y * _cell[3].y));
        _UV.Add(new Vector2(_cellGap_x * _cell[4].x             , _cellGap_y * _cell[4].y));
        //메쉬를 청소해줍니다.
        mesh.Clear();
        //버텍스 데이터를 배열로 밀어 넣습니다.
        mesh.vertices = _Vertex.ToArray();
        //인접한 버텍스 데이터를 배열로 밀어 넣습니다.
        mesh.triangles = _Tri.ToArray();
        //메쉬를 생성합니다.
        mesh.uv = _UV.ToArray();
        mesh.Optimize();
        mesh.RecalculateNormals();
    }
	
	// Update is called once per frame
	void Update () {
        MeshCreate();


        if (Input.GetKeyDown(KeyCode.Space))

        {
            MeshCreate();
            Debug.Log("스페이스바");
        }


    }

    // 바뀐 버택스 값을 다시 넣어준다. 
    private void MeshCreate()
    {

        //메쉬를 청소해줍니다.
        mesh.Clear();
        //버텍스 데이터를 배열로 밀어 넣습니다.
        mesh.vertices = _Vertex.ToArray();
        mesh.triangles = _Tri.ToArray();
        //메쉬를 생성합니다.
        mesh.Optimize();
        mesh.RecalculateNormals();

    }

}
