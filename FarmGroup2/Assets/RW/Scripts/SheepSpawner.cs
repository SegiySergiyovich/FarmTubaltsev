using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawner : MonoBehaviour
{
    [SerializeField] private GameObject sheepPrefab; //префаб овцы
    [SerializeField] private Vector3 spawnPosition; //позиция спауна
    [SerializeField] private Vector2 xspawnBounds; //границы позиции спауна (будет выбрана рандомная точка в этом диапазоне)

    [SerializeField] private int sheepCount; //задаём колличество овец
    [SerializeField] private float spawnRate; //частота появления между овцами
    [SerializeField] private float waveRate; //частота между волнами
    [SerializeField] private int sheepCountWaveIncrease; //увеличивает колличество овец с каждой волной



    private void Start()
    {
        StartCoroutine(Spawn());
    }


    private IEnumerator Spawn()
    { 
        while(true)
        {
            for (int i = 0; i < sheepCount; i++)
            {
                CreateSheep();//Spawn
                yield return new WaitForSeconds(spawnRate);
            }
            sheepCount = sheepCount * sheepCountWaveIncrease; // или sheepCount *= sheepCountWaveIncrease
            yield return new WaitForSeconds(waveRate);

            //if(j ==3 )
            //{
            //    yield return break;
            //}
        }
    }
    private void CreateSheep()
    {
        //22 - -22, 0, 55
        float xRandomPosition = Random.Range(xspawnBounds.x, xspawnBounds.y); //найти рандомную позицию по икс
        Vector3 randomSpawnPosition = new Vector3(xRandomPosition, spawnPosition.y, spawnPosition.z); //формируем новую переменную - точка где будут генерироваться овцы
        Instantiate(sheepPrefab, randomSpawnPosition, sheepPrefab.transform.rotation);
    }

}
