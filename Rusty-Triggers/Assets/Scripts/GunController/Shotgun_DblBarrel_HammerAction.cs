using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun_DblBarrel_HammerAction : MonoBehaviour {
    Animator anim;
    Transform shell_l;
    Transform shell_r;
    bool l_shell_ejected;
    bool r_shell_ejected;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        shell_l = this.transform.FindChild("Shell_L");
        shell_r = this.transform.FindChild("Shell_R");
        l_shell_ejected = false;
        r_shell_ejected = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            anim.SetBool("barrel_open", !anim.GetBool("barrel_open"));
            l_shell_ejected = true;
            r_shell_ejected = true;
        }
        if ((anim.GetCurrentAnimatorClipInfo(0))[0].clip.name == "break_barrel_idle")
        {
            if (l_shell_ejected)
            {
                // Hide left shell
            }
            if (r_shell_ejected)
            {
                // Hide right shell
            }
        }
	}
}
