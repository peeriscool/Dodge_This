using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshFilter))]
public class GrowingMesh : MonoBehaviour
{
    //based on: https://www.youtube.com/watch?v=eJEpeUH1EMg
    Mesh mesh;
    Vector3[] vertices;
    public List<Vector3> inputvalues;
    int[] triangles;
    List<int> listedtriangles = new List<int>();

    int[] Trianglebase_Cube = new int[] //cube made from verticies
        {
            0,2,1, 0,3,2, //front
            2,4,1, 2,6,4, //right
            7,0,5, 7,3,0, //left
            7,4,6, 7,5,4, //back
            3,6,2, 3,7,6, //top
            0,4,5, 0,1,4, //bottom     
        };
   int[]  trianglebase_plane = new int[] //plane from vertices
        {
            0,1,2, 1,3,2
        };
private void Start()
    {
        
        triangles = Trianglebase_Cube;
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        Init(this.gameObject, inputvalues, mesh, true);
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {   
            addativeshape();
             UpdateMesh();
        }
    }
   
    public void Init(GameObject Owner, List<Vector3> _data, Mesh _mesh, bool notriangles) //overload
    {
        vertices = _data.ToArray();
        Owner.gameObject.GetComponent<MeshFilter>().mesh = _mesh;
        UpdateMesh();
    }
    void addativeshape()
    {
        //3,2,4, 1,2,2 offset front to top
        //7,2,4, 7,2,4 offset front back
        //resposision origion of mesh with new input
       List< Vector3> cachelist = new List<Vector3>();
        int[] cachetriangles = new int[triangles.Length *2];

        for (int i = 0; i < inputvalues.Count(); i++)
        {
            Vector3 item = new Vector3();
            item.Set(inputvalues[i].x, inputvalues[i].y, inputvalues[i].z+1);
            cachelist.Add(item);
        }

        foreach (Vector3 a in cachelist)
        {
            inputvalues.Add(a);
        }

        for (int i = 0; i < triangles.Length; i++)
        {
            cachetriangles[i] = triangles[i];
        }
        for (int i = triangles.Length/2; i< cachetriangles.Length; i ++) //add new values
        {
           int indexer = i;
            if (i >= triangles.Length)
            {
                indexer = i / 2;
            }
            cachetriangles[i]= triangles[indexer] + triangles[indexer];
        }
        triangles = cachetriangles;
        Init(this.gameObject,inputvalues,mesh, true);
    }
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

//void Start()
//{
//    mesh = new Mesh();
//    GetComponent<MeshFilter>().mesh = mesh;
////    CreateShape();
//    UpdateMesh();
//    registerhands = bodysourceholder.GetComponent<BodySourceView>();
//}


/* 
  public void Init(GameObject Owner, List<Vector3> _data, Mesh _mesh)
{
    vertices = _data.ToArray();
    mesh = _mesh;
 //   Owner.gameObject.AddComponent<MeshRenderer>();
    Owner.gameObject.GetComponent<MeshFilter>().mesh = _mesh;
    triangles = new int[]
    {
        0,2,1, 0,3,2, //front
        2,4,1, 2,6,4, //right
        7,0,5, 7,3,0, //left
        7,4,6, 7,5,4, //back
        3,6,2, 3,7,6, //top
        0,4,5, 0,1,4, //bottom


    };
    UpdateMesh();
}


    //u need 1 vector for every 3 ints
        
        //for (int i = 0; i < triangles.Count(); i++)
        //{
            //int d;
            //if (i >= offset.Count())
            //{
            //    d = offset[0] + triangles[i];
            //}
            //else
            //{
            //  d = offset[i] + triangles[i];
            //}
            //listedtriangles.Add(d);

            //int d = (int) Random.RandomRange(0,100);
            //listedtriangles.Add(d);
        //}       


    

        //listedtriangles.AddRange(triangles.ToList());
        ////dubbeling the orignal size of the triangle array
        //listedtriangles.AddRange(triangles.ToList());
        // int trianglesneeded = triangles.Count() * 2 ;

        //for (int i = 0; i < triangles.Count(); i++) //would dubble the triangles but we need 3x
        //{

        //}


            //foreach (Vector3 item in inputvalues)
        //{
            
        //    //item.Set(item.x + Random.RandomRange(
        //    //    item.x,+Random.RandomRange(item.x, item.x + 10)), 
        //    //    item.y + Random.RandomRange(item.y, item.y+10), 
        //    //    item.z + Random.RandomRange(item.z, item.z + 10));
        //    cachelist.Add(item);
        //}
 */
 }