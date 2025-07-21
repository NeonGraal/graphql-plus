//HintName: Gqlp_constraint-alt-obj+Input_Impl.gen.cs
// Generated from constraint-alt-obj+Input.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_alt_obj_Input;
public class InputCnstAltObjInp
  : ICnstAltObjInp
{
  public RefCnstAltObjInp<AltCnstAltObjInp> AsRefCnstAltObjInp { get; set; }
}
public class InputRefCnstAltObjInp<Tref>
  : IRefCnstAltObjInp<Tref>
{
  public Tref Asref { get; set; }
}
public class InputPrntCnstAltObjInp
  : IPrntCnstAltObjInp
{
  public String AsString { get; set; }
}
public class InputAltCnstAltObjInp
  : InputPrntCnstAltObjInp
  , IAltCnstAltObjInp
{
  public Number alt { get; set; }
}
