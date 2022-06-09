using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private DropsPropsSC dropsProps;
    private GameManager gameManager;
    private Vector3 spawnPos;
    private Vector3 offset;

    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
    }

    private void Start()
    {
        spawnPos = transform.position;
    }

    public void SpawnProps(int propCount, float timePerProp)
    {
        StartCoroutine(TimerBeetweenProps(propCount, timePerProp));
    }

    private IEnumerator TimerBeetweenProps(int propCount, float timePerProp)
    {
        for (int i = 0; i < propCount; i++)
        {
            int randPropI = Random.Range(0, dropsProps.props.Count - 1);
            offset = new Vector3(Random.Range(-1.2f, 1.2f), 0f, 0f);
            Instantiate(dropsProps.props[randPropI], spawnPos+offset, Quaternion.identity);
            Debug.Log($"Bottle в позиции {dropsProps.props[randPropI].transform.position} появись");
            yield return new WaitForSeconds(timePerProp);
        }
        GlobalEventManager.SendWaveEnded(gameManager.currentWave);
        Debug.Log("Коурутина завершилась");
    }
 
}
