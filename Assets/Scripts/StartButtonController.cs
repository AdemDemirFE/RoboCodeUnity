using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButtonController : MonoBehaviour {
    public Sprite startOn;
    public Sprite start;
    public Sprite stopOn;
    public Sprite stop;
    SpriteState st = new SpriteState();
    bool lastStart;
    // Use this for initialization
    void Start () {
        //lastStart = RobotController.instance.start;
        //if(RobotController.instance.start) {
          
        //    GetComponent<Image>().sprite = stop;
        //    st.highlightedSprite = stop;
        //    st.pressedSprite = stopOn;
        //    GetComponent<Button>().spriteState = st;
        //}
        //else {
        //    GetComponent<Image>().sprite = start;
        //    st.highlightedSprite = startOn;
        //    st.pressedSprite = start;
        //    GetComponent<Button>().spriteState = st;

        //}
    }

    // Update is called once per frame
    void Update() {
        //   if(RobotController.instance.start != lastStart) {
        //       if(RobotController.instance.start) {

        //           GetComponent<Image>().sprite = stop;
        //           st.highlightedSprite = stop;
        //           st.pressedSprite = stopOn;
        //           GetComponent<Button>().spriteState = st;
        //       }
        //       else {
        //           GetComponent<Image>().sprite = start;
        //           st.highlightedSprite = start;
        //           st.pressedSprite = startOn;
        //           GetComponent<Button>().spriteState = st;

        //       }
        //       lastStart = RobotController.instance.start;
        //   }
    }
 }
 
