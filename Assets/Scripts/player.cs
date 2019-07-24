using UnityEngine;
using UnityEngine.SceneManagement;
public class player : MonoBehaviour {

    public float jumpforce = 10f;

    public Rigidbody2D rb;

    public SpriteRenderer sr;

    public string currentColor;

    public Color colorCyan;
    public Color colorYellow;
    public Color colorPink;
    public Color colorMagenta;

    public GameObject restartButton;
    void Start()
    {
        Time.timeScale = 1f;
        SetRandomColor();
    }

	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Jump")||Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpforce;
        }
        if (transform.position.y < -7f || transform.position.y > 28f)
        {
            Time.timeScale = 0f;
            restartButton.SetActive(true);
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "ColorChanger")
        {
            SetRandomColor();
            Destroy(col.gameObject);
            return;
        }

        if (col.tag != currentColor) 
        {
            Time.timeScale = 0f;
            restartButton.SetActive(true);
        }
    
    }

    void SetRandomColor() 
    {
        int index = Random.Range(0, 4);

        switch (index)
        {
            case 0:
                currentColor = "Cyan";
                sr.color = colorCyan;
                break;
            case 1:
                currentColor = "Yellow";
                sr.color = colorYellow;
                break;
            case 2:
                currentColor = "Pink";
                sr.color = colorPink;
                break;
            case 3:
                currentColor = "Magenta";
                sr.color = colorMagenta;
                break;


        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
