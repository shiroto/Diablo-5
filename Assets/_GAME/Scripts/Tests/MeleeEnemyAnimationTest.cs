using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class MeleeEnemyAnimationTest
{
    [UnityTest]
    public IEnumerator MeleeEnemyAnimationTestWithEnumeratorPasses()
    {
        SceneManager.LoadScene("_GAME/Scenes/TestScene");
        
        yield return null;

        GameObject enemy = GameObject.Find("MeleeEnemy");
        
        yield return null;
        
        Assert.NotNull(enemy);

        yield return new WaitForSeconds(1);

        Animator animator = enemy.GetComponentInChildren<Animator>();
        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
        
        Assert.IsTrue(info.IsName("run forward"));
        
        yield return null;
    }
}
