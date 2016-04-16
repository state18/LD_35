using UnityEngine;
using System.Collections;

public abstract class AnimalForm : MonoBehaviour {

    public virtual void Entry() { }
    public abstract void Update();
    public virtual void Exit() { }
}
