using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoHome : MonoBehaviour
{
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = this.gameObject.GetComponent<Button>();
        button.onClick.AddListener(ToHome);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ToHome(){
        SceneManager.LoadScene(0);
    }
}
