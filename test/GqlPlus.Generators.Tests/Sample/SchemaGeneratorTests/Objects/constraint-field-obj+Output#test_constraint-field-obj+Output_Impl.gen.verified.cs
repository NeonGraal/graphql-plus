//HintName: test_constraint-field-obj+Output_Impl.gen.cs
// Generated from constraint-field-obj+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Output;

public class testCnstFieldObjOutp
  : testRefCnstFieldObjOutp
  , ItestCnstFieldObjOutp
{
}

public class testRefCnstFieldObjOutp<Tref>
  : ItestRefCnstFieldObjOutp<Tref>
{
  public Tref field { get; set; }
}

public class testPrntCnstFieldObjOutp
  : ItestPrntCnstFieldObjOutp
{
  public String AsString { get; set; }
}

public class testAltCnstFieldObjOutp
  : testPrntCnstFieldObjOutp
  , ItestAltCnstFieldObjOutp
{
  public Number alt { get; set; }
}
