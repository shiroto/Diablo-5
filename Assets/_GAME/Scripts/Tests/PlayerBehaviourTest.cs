using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class PlayerBehaviourTest
{
    [UnityTest]
    public IEnumerator PlayerBehaviourTestWithEnumeratorPasses()
    {
        SceneManager.LoadScene("_GAME/Scenes/PlayerBehaviourTestScene");
        
        yield return null;

        GameObject player = GameObject.Find("Player");
        PlayerBehaviour playerBehaviour = player.GetComponent<PlayerBehaviour>();
        
        yield return null;
        
        Assert.NotNull(player);

        BaseEntity baseEntity = player.gameObject.GetComponent<BaseEntity>();

        float playerHealth = baseEntity.Health;
        baseEntity.TakeDamage(10, DamageTypes.Kinetic);
        Assert.AreEqual(baseEntity.Health, playerHealth - 15);
        
        // Expect not to crash
        playerBehaviour.SetDestinationToMousePosition(new Vector3(1, 1, 1));
        
        // Expect not to crash
        playerBehaviour.LightningAttack(new Vector3(1, 1, 1));
        
        yield return null;
    }
}
