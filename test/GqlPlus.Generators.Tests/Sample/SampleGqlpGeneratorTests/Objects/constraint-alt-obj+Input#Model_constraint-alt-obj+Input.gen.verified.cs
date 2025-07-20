//HintName: Model_constraint-alt-obj+Input.gen.cs
// Generated from constraint-alt-obj+Input.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_constraint_alt_obj_Input;

public interface ICnstAltObjInp
{
  RefCnstAltObjInp<AltCnstAltObjInp> AsRefCnstAltObjInp { get; }
}
public class InputCnstAltObjInp
  : ICnstAltObjInp
{
  public RefCnstAltObjInp<AltCnstAltObjInp> AsRefCnstAltObjInp { get; set; }
}

public interface IRefCnstAltObjInp<Tref>
{
  Tref Asref { get; }
}
public class InputRefCnstAltObjInp<Tref>
  : IRefCnstAltObjInp<Tref>
{
  public Tref Asref { get; set; }
}

public interface IPrntCnstAltObjInp
{
  String AsString { get; }
}
public class InputPrntCnstAltObjInp
  : IPrntCnstAltObjInp
{
  public String AsString { get; set; }
}

public interface IAltCnstAltObjInp
  : IPrntCnstAltObjInp
{
  Number alt { get; }
}
public class InputAltCnstAltObjInp
  : InputPrntCnstAltObjInp
  , IAltCnstAltObjInp
{
  public Number alt { get; set; }
}
