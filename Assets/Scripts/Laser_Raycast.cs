using UnityEngine;
using System.Collections;

public class Laser_Raycast : MonoBehaviour {

	public Transform ashPile1;
	public GameObject UFO;
	public float laserLengthMax = 250f;
	public GameObject destroyedBuilding;
	public float collapseSpeed = 20f;
	public float collapseDistance = -1f;
	public float laserDistance = 0f;


	// Use this for initialization
	void Start () {

		LineRenderer lineRenderer = gameObject.AddComponent("LineRenderer") as LineRenderer;
		lineRenderer.material = new Material (Shader.Find("Particles/Additive"));
		lineRenderer.SetWidth(0.2f,0.2f);
		lineRenderer.SetVertexCount(2);
	}
	
	// Update is called once per frame
	void Update () {
						LineRenderer lineRenderer = GetComponent<LineRenderer> ();
						Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
						RaycastHit hit = new RaycastHit ();
						
						// Casts the ray and get the first game object hit
						if (Physics.Raycast (ray, out hit, laserLengthMax)) {
						
						//Debug.Log ("This hit at " + hit.point);
						lineRenderer.enabled = true;
						lineRenderer.SetPosition (0, UFO.transform.position);
						lineRenderer.SetPosition (1, hit.point);
						

						if (hit.collider.gameObject.tag == "Building") {
								audio.Play();
								destroyedBuilding = hit.collider.gameObject;
								laserDistance = Vector3.Distance (UFO.transform.position, destroyedBuilding.transform.position);
								destroyedBuilding.transform.Translate ((Vector3.down * Time.deltaTime) * collapseSpeed);
									
								if (destroyedBuilding.transform.position.y < collapseDistance) {
					Instantiate (ashPile1, new Vector3 (destroyedBuilding.transform.position.x, 0f, destroyedBuilding.transform.position.z ), Quaternion.identity);
										Destroy (destroyedBuilding);
										GetComponent<ScoreBoard> ().Score += 1f;
										


								} else {
										
								}
						} else {
								lineRenderer.enabled = false;
						}
		
				} else {
						lineRenderer.enabled = false;
				}
	
	}
}
