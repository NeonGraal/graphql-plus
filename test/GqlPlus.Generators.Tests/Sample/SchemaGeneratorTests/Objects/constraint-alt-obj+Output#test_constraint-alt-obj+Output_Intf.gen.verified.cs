//HintName: test_constraint-alt-obj+Output_Intf.gen.cs
// Generated from constraint-alt-obj+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Output;

public interface ItestCnstAltObjOutp
{
  public testRefCnstAltObjOutp<testAltCnstAltObjOutp> AsRefCnstAltObjOutp { get; set; }
  public testCnstAltObjOutp CnstAltObjOutp { get; set; }
}

public interface ItestCnstAltObjOutpField
{
}

public interface ItestRefCnstAltObjOutp<Tref>
{
  public Tref Asref { get; set; }
  public testRefCnstAltObjOutp RefCnstAltObjOutp { get; set; }
}

public interface ItestRefCnstAltObjOutpField<Tref>
{
}

public interface ItestPrntCnstAltObjOutp
{
  public testString AsString { get; set; }
  public testPrntCnstAltObjOutp PrntCnstAltObjOutp { get; set; }
}

public interface ItestPrntCnstAltObjOutpField
{
}

public interface ItestAltCnstAltObjOutp
  : ItestPrntCnstAltObjOutp
{
  public testAltCnstAltObjOutp AltCnstAltObjOutp { get; set; }
}

public interface ItestAltCnstAltObjOutpField
  : ItestPrntCnstAltObjOutpField
{
  public testNumber alt { get; set; }
}
