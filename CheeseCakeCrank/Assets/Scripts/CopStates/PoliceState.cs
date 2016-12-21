using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class PoliceState
{
    protected Policeman police;
    public PoliceState(Policeman p)
    {
        police = p;
    }

    public abstract void DoState();
    public virtual void FirstArriving() { }
    public virtual void StartStatement() { }
    public virtual void Leave() { }
}
