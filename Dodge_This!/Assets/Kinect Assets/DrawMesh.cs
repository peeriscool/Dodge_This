using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshFilter))]
public class DrawMesh : MonoBehaviour
{
    //orignal source: https://www.youtube.com/watch?v=eJEpeUH1EMg
    Mesh mesh;
    Vector3[] vertices;
    int[] triangles;
    //   public BodySourceView registerhands;
    // public GameObject bodysourceholder;
    int[] Trianglebase_Cube = new int[] //cube made from verticies need 8 vertices to draw
          {
            0,2,1, 0,3,2, //front
            2,4,1, 2,6,4, //right
            7,0,5, 7,3,0, //left
            7,4,6, 7,5,4, //back
            3,6,2, 3,7,6, //top
            0,4,5, 0,1,4, //bottom     
          };
    public void Init(GameObject Owner, List<Vector3> _data, Mesh _mesh)
    {
        vertices = _data.ToArray();
        mesh = _mesh;
        Owner.gameObject.AddComponent<MeshRenderer>();
        Owner.gameObject.GetComponent<MeshFilter>().mesh = _mesh;
        triangles = new int[]
        {
            0,1,2, 1,3,2
        };
        UpdateMesh();
    }

    public void drawcube(GameObject Owner, Vector3[] data, Mesh _mesh)
    {

        if (data.Length == 8)
        {
            triangles = Trianglebase_Cube;
            Owner.gameObject.AddComponent<MeshRenderer>();
            mesh = _mesh;
            Owner.gameObject.GetComponent<MeshFilter>().mesh = _mesh;
            Owner.gameObject.AddComponent<MeshCollider>();
           // Owner.gameObject.GetComponent<MeshCollider>().convex = true;
          Owner.gameObject.AddComponent<Rigidbody>();
            Owner.gameObject.GetComponent<Rigidbody>().useGravity = false;
            
            Owner.gameObject.AddComponent<Shape>().rb = Owner.gameObject.GetComponent<Rigidbody>();
            Owner.gameObject.GetComponent<Shape>().shapeSpeed = -2f;
            Owner.gameObject.tag = "Shape";
            Owner.gameObject.layer = 11;
            

            vertices = data;
            UpdateMesh();
        }
    }
    //void Start()
    //{
    //    mesh = new Mesh();
    //    GetComponent<MeshFilter>().mesh = mesh;
    ////    CreateShape();
    //    UpdateMesh();
    //    registerhands = bodysourceholder.GetComponent<BodySourceView>();
    //}
    //private void Update()
    //{
    //    CommunicateBodymanager();
    //}

    void CommunicateBodymanager()
    {
        //if (registerhands == null)
        //{
        //    return;
        //};
            //Transform[] data = registerhands.getTransformdata();
            //for (int i = 0; i < data.Length; i++)
            //{
            //    vertices[i] = data[i].position;
            //}
        UpdateMesh();
        
    }
    // Update is called once per frame
    void CreateShape()
    {
        vertices = new Vector3[]
            {
                new Vector3(0,0,0),
                new Vector3(0, 0, 1),
                new Vector3(1, 0, 0),
                new Vector3(1, 0, 1)
            };
        triangles = new int[]
        {
            0,1,2,1,3,2
        };
    }

    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
}
