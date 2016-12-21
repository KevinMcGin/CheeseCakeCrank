using Assets.Scripts.CopStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class PoliceState
{
    public Policeman police;
    public MoveState chaseState;
    private Policeman p;

    public PoliceState(Policeman p, MoveState state)
    {
        police = p;
        chaseState = state;
    }

    public PoliceState(Policeman p)
    {
        this.p = p;
    }

    public abstract void DoState();
    public virtual void FirstArriving() { }
    public virtual void StartStatement() { }
    public virtual void Leave() { }
    public virtual void Die() { }
}
