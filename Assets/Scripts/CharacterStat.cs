using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CharacterStat : MonoBehaviour {

    public string charName;
    private int hp;
    public int hpMax;
    public int att;
    public int def;
    public float range = 1.5f;
    private Transform target;
    private float waiting;

	// Use this for initialization
	void Start () {
	   hp = hpMax;
	}
	
	// Update is called once per frame
	void Update () {
	   if (hp <= 0) {
            if (transform.tag == "Player") {
                SceneManager.LoadScene("GameOver");
            }
            else {
                Destroy(gameObject);
            }
       }
       if (waiting <= 0) {
           if (target != null) {
                if (Physics.Raycast(transform.position, target.position - transform.position, range)) {
                    Hit(target);
                    waiting = 1f;
                }
           }
        }
        else {
            waiting -= Time.deltaTime;
        }
	}

    public void Heal (int healing) {
        hp += healing;
        if (hp > hpMax) {
            hp = hpMax;
        }
    }

    public void Hurt (int hit) {
        hit -= def;
        if (hit > 0) {
            hp -= hit;
            print(charName + " loses" + hit.ToString());
        }
    }

    void Hit (Transform target) {
        target.GetComponent<CharacterStat>().Hurt(att);
    }

    void OnCollisionEnter(Collision other) {
        if ((other.collider.tag == "Player" && transform.tag == "Ennemy") || (other.collider.tag == "Ennemy" && transform.tag == "Player")) {
            target = other.transform;
        }
    }
}
