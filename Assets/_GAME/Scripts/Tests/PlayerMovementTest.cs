using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class PlayerMovementTest
{
    [UnityTest]
    public IEnumerator PlayerCanDash()
    {
        SceneManager.LoadScene("_GAME/Scenes/PlayerBehaviourTestScene");

        yield return null;

        GameObject player = GameObject.Find("Player");

        yield return null;
        
        Assert.NotNull(player);

        yield return null;

        DashActionBehaviour dab = player.GetComponent<DashActionBehaviour>();
        
        dab.startDash();
        
        Assert.IsTrue(dab.isDashing);
    }

    [UnityTest]
    public IEnumerator PlayerCanJump()
    {
        SceneManager.LoadScene("_GAME/Scenes/PlayerBehaviourTestScene");

        yield return null;

        GameObject player = GameObject.Find("Player");

        yield return null;
        
        Assert.NotNull(player);

        JumpActionBehaviour jab = player.GetComponent<JumpActionBehaviour>();
        Rigidbody rb = player.GetComponent<Rigidbody>();
        
        
        
        jab.jump();
        
        Assert.IsTrue(jab.isJumping);
    }
}
