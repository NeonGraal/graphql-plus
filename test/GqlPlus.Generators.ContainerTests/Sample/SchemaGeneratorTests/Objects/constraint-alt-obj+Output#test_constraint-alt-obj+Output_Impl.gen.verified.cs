//HintName: test_constraint-alt-obj+Output_Impl.gen.cs
// Generated from constraint-alt-obj+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Output;

public class testCnstAltObjOutp
  : ItestCnstAltObjOutp
{
  public testRefCnstAltObjOutp<testAltCnstAltObjOutp> AsRefCnstAltObjOutp { get; set; }
  public testCnstAltObjOutp CnstAltObjOutp { get; set; }
}

public class testRefCnstAltObjOutp<Tref>
  : ItestRefCnstAltObjOutp<Tref>
{
  public Tref Asref { get; set; }
  public testRefCnstAltObjOutp RefCnstAltObjOutp { get; set; }
}

public class testPrntCnstAltObjOutp
  : ItestPrntCnstAltObjOutp
{
  public testString AsString { get; set; }
  public testPrntCnstAltObjOutp PrntCnstAltObjOutp { get; set; }
}

public class testAltCnstAltObjOutp
  : testPrntCnstAltObjOutp
  , ItestAltCnstAltObjOutp
{
  public testNumber alt { get; set; }
  public testAltCnstAltObjOutp AltCnstAltObjOutp { get; set; }
}
