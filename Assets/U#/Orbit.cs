
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Orbit : UdonSharpBehaviour
{
	public GameObject rotationCentre;
	public float rotationSpeed;
	private float rotationRadius;
	private float rotationHeight;
	private Vector3 rotationDirection = Vector3.up;
	public Texture2D[] bookCovers;

    // Start is called before the first frame update
    void Start()
    {
        //Set random rotation on book
        transform.rotation = new Quaternion(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180));
        //Set random orbit range
        rotationRadius = Random.Range(4, 8);
        //set random height level at which to rotate
        rotationHeight = Random.Range(2, 14);

        //Calculate and set book transform
        Vector3 toObjectVector;
        toObjectVector.x = transform.position.x - rotationCentre.transform.position.x;
        toObjectVector.z = transform.position.z - rotationCentre.transform.position.z;
        toObjectVector.y = transform.position.y - rotationCentre.transform.position.y;
        toObjectVector = toObjectVector.normalized * rotationRadius;
        Vector3 newPosition = new Vector3(rotationCentre.transform.position.x + toObjectVector.x, rotationHeight, rotationCentre.transform.position.z + toObjectVector.z);
        transform.position = newPosition;
       

        //random scale of books
         int newScale = Random.Range(75, 200) / 100;
         transform.localScale = new Vector3(newScale, newScale, newScale);

         //random book cover
         int randomBookIndex = Random.Range(0, bookCovers.Length);
         Texture2D randomTexture = bookCovers[randomBookIndex];
         this.gameObject.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", randomTexture);
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(rotationCentre.transform.position, rotationDirection, rotationSpeed * Time.deltaTime);
       

        //Height is set randomly
        //Vector3 newShit = new Vector3(rotationCentre.transform.position.x + toObjectVector.x, rotationHeight, rotationCentre.transform.position.z + toObjectVector.z);
        //transform.position = newShit;
    }
}
