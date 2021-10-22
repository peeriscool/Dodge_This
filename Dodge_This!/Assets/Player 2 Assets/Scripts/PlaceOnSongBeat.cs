using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceOnSongBeat : MonoBehaviour
{
    public LevelManager levelManager;
    public ObjectSpawning objectSpawning;
    public AudioSource audioSource;
    public int songIndex = 0;
    public int standardBeatMultiplier = 4;
    public string songName;
    public float offset;
    public float time = 0;
    public float bpm;
    public float averageBPM;
    public float secondsBetweenBeat;
    public bool playSong = false;
    public bool doubleTime = false;
    public bool halfTime = false;
    public bool stopSong = false;
    public bool songComplete = false;
    public bool startSpawning = false;
    // Songs
    public AudioClip kingSandy;
    public AudioClip letItBe;
    public AudioClip masquerade;

    private void Start()
    {
        doubleTime = false;
        halfTime = false;
        stopSong = false;
        songComplete = false;
        startSpawning = false;
    }

    void Update()
    {
        if (songIndex == 0)
        {
            audioSource.clip = letItBe;
            LetItBeReggaeSong();
        }
        else if (songIndex == 1)
        {
            audioSource.clip = kingSandy;
            KingSandybuttsTombSong();
        }
        else if (songIndex == 2)
        {
            audioSource.clip = masquerade;
            Masquerade();
        }
        if (levelManager.levelActive)
        {
            if (playSong == false)
            {
                audioSource.Play();
                StartCoroutine(WaitForOffset());
                startSpawning = true;
                playSong = true;
            }
            secondsBetweenBeat = (60/bpm * standardBeatMultiplier);
            //print("seconds between beat " + secondsBetweenBeat);
        }
        if (stopSong == true)
        {
            audioSource.Stop();
        }
        // Spawning while
        if (startSpawning)
        {
            time += Time.deltaTime;
        }
    }
    IEnumerator SpawnShapeOnBeat()
    {   
        if (!halfTime)
        {

            objectSpawning.SpawnObject(); // 1 Beat

        }
        yield return new WaitForSeconds(secondsBetweenBeat / 2); // 0.5 beat
        if (doubleTime)
        {

            objectSpawning.SpawnObject();

        }
        yield return new WaitForSeconds(secondsBetweenBeat / 2); // 2 Beat

        objectSpawning.SpawnObject();

        if (stopSong == false)
        {
            StartCoroutine(SpawnShapeOnBeat());
        }
    }
    IEnumerator WaitForOffset()
    {
        yield return new WaitForSeconds(offset);
        StartCoroutine(SpawnShapeOnBeat());
    }
    void KingSandybuttsTombSong()
    {
        if (startSpawning == false)
        {
            bpm = 138;
            averageBPM = 169;
            offset = 1.387f;
            songName = "Grant Kirkhope - King Sadybutt's Tomb";
            print("Update info once");
        }
        // BPM Change
        BPMChange(4.865f, 8.221f, 143.1f);
        BPMChange(8.221f, 11.464f, 148.1f);
        BPMChange(11.464f, 14.663f, 150.1f);
        BPMChange(14.663f, 17.759f, 155.1f);
        BPMChange(17.759f, 20.777f, 159.1f);
        BPMChange(20.777f, 23.721f, 163.1f);
        BPMChange(23.721f, 26.595f, 167.1f);
        BPMChange(26.595f, 29.402f, 171.1f);
        BPMChange(29.402f, 32.130f, 176.1f);
        BPMChange(32.130f, 34.811f, 179.1f);
        BPMChange(34.811f, 37.462f, 181.1f);
        BPMChange(37.462f, 40.084f, 183.1f);
        BPMChange(40.084f, 42.678f, 185.1f);
        BPMChange(42.678f, 45.244f, 187.1f);
        BPMChange(45.244f, 47.770f, 190.1f);
        BPMChange(47.770f, 50.270f, 192.1f);
        BPMChange(50.270f, 52.744f, 194.1f);
        BPMChange(52.744f, 55.192f, 196.1f);
        BPMChange(55.192f, 57.616f, 198.1f);
        BPMChange(57.616f,58.9f,200);
        if (time > 56)
        {
            if (!stopSong)
            {
                songComplete = true;
            }
        }
    }
    void LetItBeReggaeSong()
    {
        if (startSpawning == false)
        {
            bpm = 79;
            averageBPM = 158;
            offset = 7.25f;
            songName = "Unknown - Let it be reggae";
            print("Update info once");
        }
        // Song end
        if (time > 192.5f)
        {
            if (!stopSong)
            {
                songComplete = true;
            }
        }
    }
    void Masquerade()
    {
        if (startSpawning == false)
        {
            bpm = 128;
            averageBPM = 128;
            offset = 1.88f;
            songName = "M2U - Masquerade";
            print("Update info once");
        }
        // Song end
        if (time > 138)
        {
            if (!stopSong)
            {
                songComplete = true;
            }
        }
    }
    void BPMChange(float minTime, float maxTime, float newBpm)
    {
        if (time >= (minTime - 0.05f) && time <= (maxTime - 0.05f)) 
        {
            bpm = newBpm;
        }
    }
}