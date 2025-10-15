//HintName: test_constraint-field-obj+Output_Impl.gen.cs
// Generated from constraint-field-obj+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Output;

public class OutputtestCnstFieldObjOutp
  : OutputtestRefCnstFieldObjOutp
  , ItestCnstFieldObjOutp
{
}

public class OutputtestRefCnstFieldObjOutp<Tref>
  : ItestRefCnstFieldObjOutp<Tref>
{
  public Tref field { get; set; }
}

public class OutputtestPrntCnstFieldObjOutp
  : ItestPrntCnstFieldObjOutp
{
  public String AsString { get; set; }
}

public class OutputtestAltCnstFieldObjOutp
  : OutputtestPrntCnstFieldObjOutp
  , ItestAltCnstFieldObjOutp
{
  public Number alt { get; set; }
}
