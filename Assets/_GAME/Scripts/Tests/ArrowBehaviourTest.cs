using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class ArrowBehaviourTest
{
    [UnityTest]
    public IEnumerator ArrowWillBeDestroyed()
    {
        SceneManager.LoadScene("_GAME/Scenes/ArrowBehaviourTestSceneArrowGetsDestroyed");
        yield return null;
        GameObject arrow = GameObject.Find("Arrow");
        yield return null;
        Assert.NotNull(arrow);
        yield return null;
        ArrowBehaviour arrowBehaviourComponent = arrow.GetComponent<ArrowBehaviour>();
        arrowBehaviourComponent.StartCoroutine(arrowBehaviourComponent.DestroyAfterSeconds(2));
        yield return new WaitForSeconds(3);
        GameObject arrow2 = GameObject.Find("Arrow");
        Assert.Null(arrow2);
    }

    [UnityTest]
    public IEnumerator ArrowHitsEnemyAndGetsDestroyed()
    {
        SceneManager.LoadScene("_GAME/Scenes/ArrowBehaviourTestSceneArrowHitsEnemy");
        yield return null;
        GameObject arrow = GameObject.Find("Arrow");
        GameObject enemy = GameObject.Find("MeleeEnemy");
        yield return null;
        Assert.NotNull(arrow);
        Assert.NotNull(enemy);
        ArrowBehaviour arrowBehaviourComponent = arrow.GetComponent<ArrowBehaviour>();
        arrowBehaviourComponent.StartCoroutine(arrowBehaviourComponent.DestroyAfterSeconds(2));
        EnemyBehaviour enemyBehaviourComponent = enemy.GetComponent<EnemyBehaviour>();
        float health = enemyBehaviourComponent.Health;
        yield return new WaitForSeconds(2);
        float health1 = enemyBehaviourComponent.Health;
        Debug.Log($"{health} -> {health1} = {health1 < health}");
        Assert.IsTrue(health1 < health);
    }
}
