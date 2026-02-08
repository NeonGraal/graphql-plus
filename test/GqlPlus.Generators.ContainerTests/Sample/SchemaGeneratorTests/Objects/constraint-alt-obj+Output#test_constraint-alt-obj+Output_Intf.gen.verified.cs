//HintName: test_constraint-alt-obj+Output_Intf.gen.cs
// Generated from constraint-alt-obj+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Output;

public interface ItestCnstAltObjOutp
{
  public ItestRefCnstAltObjOutp<ItestAltCnstAltObjOutp> AsRefCnstAltObjOutp { get; set; }
}

public interface ItestCnstAltObjOutpObject
{
}

public interface ItestRefCnstAltObjOutp<Tref>
{
  public Tref Asref { get; set; }
}

public interface ItestRefCnstAltObjOutpObject<Tref>
{
}

public interface ItestPrntCnstAltObjOutp
{
  public ItestString AsString { get; set; }
}

public interface ItestPrntCnstAltObjOutpObject
{
}

public interface ItestAltCnstAltObjOutp
  : ItestPrntCnstAltObjOutp
{
}

public interface ItestAltCnstAltObjOutpObject
  : ItestPrntCnstAltObjOutpObject
{
  public ItestNumber Alt { get; set; }
}
