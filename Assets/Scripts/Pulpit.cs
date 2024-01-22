using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;

public class Pulpit : MonoBehaviour
{
    public float time = 5f;
    public Vector3 localScale = new Vector3(9f, 0.5f, 9f);
    public Transform parent;
    public Transform player;
    public TMP_Text scoreText;

    TMP_Text timerText;
    Animator animator;
    float initialTime;
    bool isScoreCounted = false;
    bool isShrinking = false;
    bool isSpawned = false;

    void Start()
    {
        timerText = transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>();
        initialTime = time;
        animator = GetComponent<Animator>();
      
    }


    void Update()
    {
        if (JSONInput.data == null) { return; }
        time -= Time.deltaTime;
        timerText.text = time.ToString("F2");
        if (initialTime - time >= JSONInput.data.pulpit_data.pulpit_spawn_time && !isSpawned)
        {
            SpawnPulpit();
        }
        if (time <= 0 && !isShrinking)
        {
            isShrinking = true;
            animator.SetTrigger("isShrinking");
        }
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Shrinking"))
        {
            Destroy(gameObject);
        }
        if (!isScoreCounted)
        {
            if (
                player.transform.position.x >= transform.position.x - transform.localScale.x / 2 &&
                player.transform.position.x <= transform.position.x + transform.localScale.x / 2 &&
                player.transform.position.z >= transform.position.z - transform.localScale.z / 2 &&
                player.transform.position.z <= transform.position.z + transform.localScale.z / 2
               )
            {
                isScoreCounted = true;
                scoreText.text = (int.Parse(scoreText.text) + 1).ToString();
            }
        }
    }

    void SpawnPulpit()
    {
        isSpawned = true;
        GameObject spawnedObject = Instantiate(gameObject, parent);
        spawnedObject.name = "Pulpit Clone";
        spawnedObject.transform.localScale = localScale / 2;
        spawnedObject.transform.position = transform.position;
        switch (Random.Range(0, 4))
        {
            case 0: spawnedObject.transform.position += Vector3.forward * localScale.z; break;
            case 1: spawnedObject.transform.position += Vector3.back * localScale.z; break;
            case 2: spawnedObject.transform.position += Vector3.right * localScale.x; break;
            case 3: spawnedObject.transform.position += Vector3.left * localScale.x; break;
        }
        Pulpit pulpit = spawnedObject.GetComponent<Pulpit>();
        pulpit.time = Random.Range(JSONInput.data.pulpit_data.min_pulpit_destroy_time, JSONInput.data.pulpit_data.max_pulpit_destroy_time);
    }
}
