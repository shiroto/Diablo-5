using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class LighningAttackTest
{
    [UnityTest]
    public IEnumerator LighningAttackTestWithEnumeratorPasses()
    {
        SceneManager.LoadScene("_GAME/Scenes/LightningAttackTestScene");
        yield return null;
        GameObject enemy = GameObject.Find("MeleeEnemy");
        GameObject lightning = GameObject.Find("LightningAttack");
        yield return null;
        Assert.NotNull(enemy);
        Assert.NotNull(lightning);
        yield return null;
        MeeleEnemyBehaviour meeleEnemyBehaviourComponent = enemy.GetComponent<MeeleEnemyBehaviour>();
        float healthBeforeAttack = meeleEnemyBehaviourComponent.Health;
        LightningAttack lightningAttackComponent = lightning.GetComponent<LightningAttack>();
        lightningAttackComponent.StartCoroutine(lightningAttackComponent.Attack());
        yield return new WaitForSeconds(1);
        Assert.IsFalse(healthBeforeAttack == meeleEnemyBehaviourComponent.Health);
    }
}
