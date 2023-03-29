using System.Collections;
using UnityEngine;

public interface Interaction
{
    public void OnTriggerEnter(Collider other);
    public IEnumerator EffectAction();
}
