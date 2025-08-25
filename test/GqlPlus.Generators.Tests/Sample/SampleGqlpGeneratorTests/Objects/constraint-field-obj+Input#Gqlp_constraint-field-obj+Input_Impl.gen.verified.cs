//HintName: Gqlp_constraint-field-obj+Input_Impl.gen.cs
// Generated from constraint-field-obj+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_field_obj_Input;

public class InputCnstFieldObjInp
  : InputRefCnstFieldObjInp
  , ICnstFieldObjInp
{
}

public class InputRefCnstFieldObjInp<Tref>
  : IRefCnstFieldObjInp<Tref>
{
  public Tref field { get; set; }
}

public class InputPrntCnstFieldObjInp
  : IPrntCnstFieldObjInp
{
  public String AsString { get; set; }
}

public class InputAltCnstFieldObjInp
  : InputPrntCnstFieldObjInp
  , IAltCnstFieldObjInp
{
  public Number alt { get; set; }
}
