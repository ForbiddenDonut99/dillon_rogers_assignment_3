using UnityEngine;
using System.Collections;

public class NPCBot : MonoBehaviour {

	// Will hold transfer component of player gameObject reference
	public Transform player;
	public float NPCSpeed = 5f;
	public float NPCFollowDistance = 5f;
	public float NPCTurnSpeed = 5f;
	public float NPCBountHeight = 0.3f;
	public float NPCBounceSpeed = 50f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		// Non-normalized: transform.position += (player.position - transform.position) * Time.deltaTime;
		// Normalizing: reducing/increasing the length to 1
		// Manual: plot points, use Pythagorean Theorem and divide by magnitude

		// Bot follows player
		// If statement prevents NPC overcrowding player
		if (Vector3.Distance (transform.position, player.position) > NPCFollowDistance) {
						transform.position += Vector3.Normalize (player.position - transform.position) * Time.deltaTime * NPCSpeed;

						Vector3 NPCFacing = (player.position - transform.position).normalized;
						transform.forward = Vector3.Lerp(transform.forward, NPCFacing, Time.deltaTime * NPCTurnSpeed);
			
						// Bot looks at player

						// Interpolation is "blending"
						// Most common type is linear interpolation
						// Lerping is "linear interpolation"

						// Use sine wave to make bot bounce
						transform.position += transform.up * (Mathf.Sin(Time.time * NPCBounceSpeed) * NPCBountHeight);

						if (transform.position.y < 0f) {
						transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
				}

				}

		
	}
}
