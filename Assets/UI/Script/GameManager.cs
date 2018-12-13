using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

    public GameObject opening;
    public GameObject chooseModel;
    public GameObject chooseModelButton;

    public GameObject helpPanel;

    //AR Function
    public GameObject ArCamera;
    public GameObject GroundPlaneStage;
    public GameObject PlaneFinder;
    public GameObject UsageModel;

    public GameObject chosenPrefab;
    

    public GameObject CapsuleModel;
    public GameObject ZombieModel;
    public GameObject ElizabethModel;
    public GameObject Colossus1Model;
    public GameObject Colossus2Model;
    public GameObject SculptureModel;

    public GameObject UICamera;

    // Assign in the inspector
    public GameObject objectToRotate;
    public Slider slider;

    public GameObject leanTouch;

    bool showSurfaceAnimation;


    // Use this for initialization
    void Start () {

        ArCamera.gameObject.SetActive(false);
        GroundPlaneStage.gameObject.SetActive(false);
        PlaneFinder.gameObject.SetActive(false);


        showSurfaceAnimation = true;
        
        
        chooseModelButton.gameObject.SetActive(false);
        chooseModel.gameObject.SetActive(false);
        helpPanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        
        
    }

    public void afterStart()
    {
        opening.gameObject.SetActive(false);

        chooseModel.gameObject.SetActive(true);
    }

    public void showChooseModel()
    {
        
        chooseModelButton.gameObject.SetActive(false);
        ArCamera.gameObject.SetActive(false);
        GroundPlaneStage.gameObject.SetActive(false);
        PlaneFinder.gameObject.SetActive(false);
        Debug.Log(GroundPlaneStage.transform.GetChild(0).name);
        Destroy(GroundPlaneStage.transform.GetChild(1).gameObject);
        //Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);

        chooseModel.gameObject.SetActive(true);
        
    }

    

    public void help()
    {

        helpPanel.gameObject.SetActive(true);
        chooseModelButton.gameObject.SetActive(false);

        
    }

    public void CloseHelp()
    {


        helpPanel.gameObject.SetActive(false);
        chooseModelButton.gameObject.SetActive(true);
        showSurfaceAnimation = false;

       

    }

    public void findSurface()
    {
        StartCoroutine(ShowSurfacesAnimation());


        chooseModel.gameObject.SetActive(false);
        var model = Instantiate(chosenPrefab, GroundPlaneStage.transform.position, GroundPlaneStage.transform.rotation);
        model.transform.parent = GroundPlaneStage.transform;

       

        var text = UsageModel.GetComponent<UnityEngine.UI.Text>().text = "Usage Model: " + chosenPrefab.name;
        
        
    }

    IEnumerator ShowSurfacesAnimation()
    {
        if (showSurfaceAnimation)
        {
            
            
            chooseModelButton.gameObject.SetActive(true);
            showSurfaceAnimation = false;

            ArCamera.gameObject.SetActive(true);
            GroundPlaneStage.gameObject.SetActive(true);
            PlaneFinder.gameObject.SetActive(true);

            


        }
        else
        {
            yield return new WaitForSeconds(0.3f);
            chooseModelButton.gameObject.SetActive(true);

            ArCamera.gameObject.SetActive(true);
            GroundPlaneStage.gameObject.SetActive(true);
            PlaneFinder.gameObject.SetActive(true);

            
        }
        
    }

    public void setModelCapsule()
    {
        chosenPrefab = CapsuleModel;
        findSurface();
    }

    public void setModelZombie()
    {
        chosenPrefab = ZombieModel;
        findSurface();
    }

    public void setModelElizabeth()
    {
        chosenPrefab = ElizabethModel;
        findSurface();
    }

    public void setModelColossus1 ()
    {
        chosenPrefab = Colossus1Model;
        findSurface();
    }

    public void setModelColossus2()
    {
        chosenPrefab = Colossus2Model;
        findSurface();
    }

    public void setModelSculpture()
    {
        chosenPrefab = SculptureModel;
        findSurface();
    }



    // Preserve the original and current orientation
    private float previousValue;

    void Awake()
    {
        // Assign a callback for when this slider changes
        slider.onValueChanged.AddListener(OnSliderChanged);

        // And current value
        previousValue = slider.value;
    }

    void OnSliderChanged(float value)
    {
        
        // How much we've changed
        float delta = value - previousValue;
        GroundPlaneStage.transform.GetChild(1).gameObject.transform.Rotate(Vector3.up * delta);

        // Set our previous value for the next change
        previousValue = value;
    }
}
