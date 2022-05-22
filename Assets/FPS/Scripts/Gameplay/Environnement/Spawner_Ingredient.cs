using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Ingredient : MonoBehaviour
{
    List<Transform> DestroyedIngredients = new List<Transform>();
    float timer;
    public float timeToRespawn;
    public GameObject prefabIngredient;

    void Start()
    {
        List<GameObject> ListeDingredient = new List<GameObject>();
        foreach (Transform spawnCoordinates in transform)
        {
           ListeDingredient.Add(Instantiate(prefabIngredient, spawnCoordinates.localPosition, spawnCoordinates.rotation));
            Destroy(spawnCoordinates.gameObject);
        }
        foreach (GameObject obj in ListeDingredient)
        {
            obj.transform.SetParent(transform);
        }
    }

    public IEnumerator RespawnWaiter(Transform obj)
    {
        yield return new WaitForSeconds(timeToRespawn);
        GameObject objet = Instantiate(prefabIngredient, obj.position, obj.rotation);
        Debug.Log(objet);
        objet.transform.SetParent(transform);
    }

}