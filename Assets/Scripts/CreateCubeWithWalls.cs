using UnityEngine;

public class CreateCubeWithWalls : MonoBehaviour
{
    private const float CubeSize = 3.0f;

    void Start()
    {
        CreateWall("FrontWall", new Vector3(0, 0, CubeSize / 2), new Vector3(CubeSize, CubeSize, 0.1f));
        CreateWall("BackWall", new Vector3(0, 0, -CubeSize / 2), new Vector3(CubeSize, CubeSize, 0.1f));
        CreateWall("LeftWall", new Vector3(-CubeSize / 2, 0, 0), new Vector3(0.1f, CubeSize, CubeSize));
        CreateWall("RightWall", new Vector3(CubeSize / 2, 0, 0), new Vector3(0.1f, CubeSize, CubeSize));
        CreateWall("TopWall", new Vector3(0, CubeSize / 2, 0), new Vector3(CubeSize, 0.1f, CubeSize));
        CreateWall("BottomWall", new Vector3(0, -CubeSize / 2, 0), new Vector3(CubeSize, 0.1f, CubeSize));

        CreateRedSphere();
    }

    void CreateWall(string name, Vector3 position, Vector3 scale)
    {
        GameObject wall = new GameObject(name);

        MeshFilter meshFilter = wall.AddComponent<MeshFilter>();
        meshFilter.mesh = Resources.GetBuiltinResource<Mesh>("Cube.fbx");

        MeshRenderer meshRenderer = wall.AddComponent<MeshRenderer>();
        meshRenderer.material = new Material(Shader.Find("Standard"));

        wall.transform.position = position;
        wall.transform.localScale = scale;

        wall.transform.parent = transform;

        Collider collider = wall.AddComponent<BoxCollider>();
        collider.isTrigger = true;

        Rigidbody rigidbody = wall.AddComponent<Rigidbody>();
        rigidbody.isKinematic = true;
    }

    void CreateRedSphere()
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        sphere.transform.position = new Vector3(0, 0, 0);

        Material redMaterial = new Material(Shader.Find("Standard"));
        redMaterial.color = Color.red;
        sphere.GetComponent<Renderer>().material = redMaterial;

        sphere.transform.localScale = new Vector3(1, 1, 1);

        sphere.transform.parent = transform;

        SphereCollider sphereCollider = sphere.AddComponent<SphereCollider>();
        sphereCollider.isTrigger = true;

        Rigidbody sphereRigidbody = sphere.AddComponent<Rigidbody>();
        sphereRigidbody.isKinematic = true;
    }
}
