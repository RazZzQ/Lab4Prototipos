using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestConsole : MonoBehaviour
{
    public RegenerationSystem regen;
    public HealtComponent healt;

    private void OnEnable()
    {
        regen.OnRegenStart += PrintDataStart;
        regen.OnRegenEnd += PrintDataEnd;
    }
    private void OnDisable()
    {
        regen.OnRegenStart -= PrintDataStart;
        regen.OnRegenEnd -= PrintDataEnd;
    }
    public void PrintDataStart()
    {
        print("Vida: " + healt.currentHealth);
    }
    public void PrintDataEnd()
    {
        print("Vida: " + healt.currentHealth);
    }
}
