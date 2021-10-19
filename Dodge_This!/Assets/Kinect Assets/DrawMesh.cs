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
  
    public DrawMesh(GameObject Owner,List<Vector3> _data,Mesh _mesh)
    {
        vertices = _data.ToArray();
        mesh = new Mesh();
        Owner.gameObject.AddComponent<MeshFilter>();
        Owner.gameObject.GetComponent<MeshFilter>().mesh = _mesh;
        triangles = new int[]
        {
            0,1,2,1,3,2
        };
        UpdateMesh();
    }
    public void Init(GameObject Owner, List<Vector3> _data, Mesh _mesh)
    {
        vertices = _data.ToArray();
        mesh = new Mesh();
        Owner.gameObject.AddComponent<MeshRenderer>();
        Owner.gameObject.GetComponent<MeshFilter>().mesh = _mesh;
        triangles = new int[]
        {
            0,1,2,1,3,2
        };
        UpdateMesh();
    }
    //void Start()
    //{
    //    mesh = new Mesh();
    //    GetComponent<MeshFilter>().mesh = mesh;
    ////    CreateShape();
    //    UpdateMesh();
    //    registerhands = bodysourceholder.GetComponent<BodySourceView>();
    //}
    private void Update()
    {
        CommunicateBodymanager();
    }

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
