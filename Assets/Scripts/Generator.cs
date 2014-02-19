using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {

	// Prefabs
	public Transform skyscraper1Prefab, skyscraper2Prefab, skyscraper3Prefab, skyscraper4Prefab;
	public float generatorMin = -250f;
	public float generatorMax = 250f;

	int buildingCount = 0;

	// Use this for initialization
	void Start () {
		while (buildingCount < 1000) {
			float randomNumber = Random.Range (0f, 10f);
			
			if (randomNumber < 2.5f) {
				// Spawn a skyscraper
				// Instantiate creates new objects
				Instantiate (skyscraper1Prefab, new Vector3 (Random.Range (generatorMin , generatorMax), 0f, Random.Range (generatorMin , generatorMax)), Quaternion.identity);
			} if (randomNumber > 2.5f && randomNumber < 5.0f) {
				// Spawn a shopping mall
				Instantiate (skyscraper2Prefab, new Vector3 (Random.Range (generatorMin , generatorMax), 0f, Random.Range (generatorMin , generatorMax)), Quaternion.identity);
				
			} if (randomNumber > 5.0f && randomNumber < 7.5f) {
				Instantiate (skyscraper3Prefab, new Vector3 (Random.Range (generatorMin , generatorMax), 0f, Random.Range (generatorMin , generatorMax)), Quaternion.identity);

			} if (randomNumber > 7.5f) {
				Instantiate (skyscraper4Prefab, new Vector3 (Random.Range (generatorMin , generatorMax), 0f, Random.Range (generatorMin , generatorMax)), Quaternion.identity);
			} 
			buildingCount += 1;
			
		}
	}
	
	// Update is called once per frame
	void Update () {
		}
}
