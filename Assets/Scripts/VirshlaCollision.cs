using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirshlaCollision : MonoBehaviour
{
    public static VirshlaCollision e;
    void Awake() { e = this; }


    ParticleSystem particles;
    public List<ParticleCollisionEvent> collisionEvents;


    public bool isPerfect;

    public string[] strsPerfect =
    {
        "Perfect!",
        "That's my boy!",
        "Beautiful, I cried",
        "A Mustardpiece",
        "An oscar winner!"
    };

    public string[] strsWrong =
    {
        "I won't yellow anymore",
        "You call that a wave?",
        "Wave harder!",
        "No oscar for you!!"

    };

    public string[] strsBun =
    {
        "Not on my buns!",
        "Another bun ruined!?",
        "My precious buns, noo!",
        "That's not a saussage!"
    };

    public string[] strsPlate =
    {
        "Not on my precious china!",
        "Not on the plaaate!",
        "That's not a saussage!",
    };


    void Start()
    {
        hits = new bool[6];

        particles = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();

        AngryDriector.e.EndSay();
    }

    bool[] hits;

    void OnParticleCollision(GameObject other)
    {
        if (isPerfect) return;

        int numCollisionEvents = particles.GetCollisionEvents(other, collisionEvents);

        Rigidbody rb = other.GetComponent<Rigidbody>();
        int i = 0;

        while (i < numCollisionEvents)
        {
            if (collisionEvents[i].velocity.sqrMagnitude > 1)
            {
                for (int n = 0; n < 6; n++)
                {
                    if (collisionEvents[n].colliderComponent.name == n.ToString())
                    {
                        hits[n] = true;
                        Debug.Log("VIRSHLA " + n);

                        if (HasHitAll())
                        {
                            if (!hasHitAll)
                            {
                                if (Random.value < 0.5f)
                                {
                                    isPerfect = true;
                                    AngryDriector.e.Say(strsPerfect[Random.Range(0, strsPerfect.Length)]);
                                }
                                else
                                {
                                    AngryDriector.e.Say(strsWrong[Random.Range(0, strsWrong.Length)]);
                                    AngryDriector.e.ShowTryAgain();
                                }
                            }
                            hasHitAll = true;
                        }
                    }

                }


                if (collisionEvents[i].colliderComponent.name == "Zemichka")
                {
                    Debug.Log("Zemichka!!");

                    if (!hasHitZemichka)
                    {
                        AngryDriector.e.Say(strsBun[Random.Range(0, strsBun.Length)]);
                        AngryDriector.e.ShowTryAgain();
                    }

                    hasHitZemichka = true;
                }

                if (collisionEvents[i].colliderComponent.name == "Tanjir")
                {
                    Debug.Log("TANJIR!!");

                    if (!hasHitTanjir)
                    {
                        AngryDriector.e.Say(strsPlate[Random.Range(0, strsPlate.Length)]);

                        AngryDriector.e.ShowTryAgain();
                    }

                    hasHitTanjir = true;
                }
            }

            if (rb)
            {
                Vector3 pos = collisionEvents[i].intersection;
                Vector3 force = collisionEvents[i].velocity * 10;
                rb.AddForce(force);

                Debug.Log("HIT!");
            }
            i++;
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            Debug.Log(HasHitAll());

    }

    bool hasHitAll;
    bool hasHitZemichka;
    bool hasHitTanjir;

    public bool HasHitAll()
    {
        int all = 0;

        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == true) all++;
        }

        if (all >= 6) return true;

        return false;
    }

    public void Cleanup()
    {
        for (int i = 0; i < hits.Length; i++)
        {
            hits[i] = false;
        }

        hasHitAll = false;
        hasHitTanjir = false;
        hasHitZemichka = false;

        isPerfect = false;
    }
}