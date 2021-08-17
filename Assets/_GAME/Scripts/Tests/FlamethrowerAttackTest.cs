using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class FlamethrowerAttackTest
{
    [UnityTest]
    public IEnumerator FlamesBehaveCorrectly()
    {
        SceneManager.LoadScene("_GAME/Scenes/PlayerBehaviourTestScene");

        yield return null;

        GameObject player = GameObject.Find("Player");

        yield return null;
        
        Assert.NotNull(player);

        yield return null;

        FlamethrowerAttackBehaviour fab = player.GetComponent<FlamethrowerAttackBehaviour>();
        GameObject hitbox = GameObject.Find("AttackArea");
        
        fab.StartFire();
        
        Assert.IsTrue(fab.isFiring);
        Assert.IsTrue(hitbox.activeSelf);

        fab.StopFire();
        
        Assert.IsFalse(fab.isFiring);
        Assert.IsFalse(hitbox.activeSelf);
    }
}
