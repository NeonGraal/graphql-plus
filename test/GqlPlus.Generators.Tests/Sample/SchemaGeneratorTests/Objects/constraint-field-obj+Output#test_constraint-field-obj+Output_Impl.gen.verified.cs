//HintName: test_constraint-field-obj+Output_Impl.gen.cs
// Generated from constraint-field-obj+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Output;

public class testCnstFieldObjOutp
  : testRefCnstFieldObjOutp
  , ItestCnstFieldObjOutp
{
  public testCnstFieldObjOutp CnstFieldObjOutp { get; set; }
}

public class testRefCnstFieldObjOutp<Tref>
  : ItestRefCnstFieldObjOutp<Tref>
{
  public Tref field { get; set; }
  public testRefCnstFieldObjOutp RefCnstFieldObjOutp { get; set; }
}

public class testPrntCnstFieldObjOutp
  : ItestPrntCnstFieldObjOutp
{
  public testString AsString { get; set; }
  public testPrntCnstFieldObjOutp PrntCnstFieldObjOutp { get; set; }
}

public class testAltCnstFieldObjOutp
  : testPrntCnstFieldObjOutp
  , ItestAltCnstFieldObjOutp
{
  public testNumber alt { get; set; }
  public testAltCnstFieldObjOutp AltCnstFieldObjOutp { get; set; }
}
