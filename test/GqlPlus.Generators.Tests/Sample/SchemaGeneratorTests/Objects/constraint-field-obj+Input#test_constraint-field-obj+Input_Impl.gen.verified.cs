//HintName: test_constraint-field-obj+Input_Impl.gen.cs
// Generated from constraint-field-obj+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Input;

public class InputtestCnstFieldObjInp
  : InputtestRefCnstFieldObjInp
  , ItestCnstFieldObjInp
{
}

public class InputtestRefCnstFieldObjInp<Tref>
  : ItestRefCnstFieldObjInp<Tref>
{
  public Tref field { get; set; }
}

public class InputtestPrntCnstFieldObjInp
  : ItestPrntCnstFieldObjInp
{
  public String AsString { get; set; }
}

public class InputtestAltCnstFieldObjInp
  : InputtestPrntCnstFieldObjInp
  , ItestAltCnstFieldObjInp
{
  public Number alt { get; set; }
}
