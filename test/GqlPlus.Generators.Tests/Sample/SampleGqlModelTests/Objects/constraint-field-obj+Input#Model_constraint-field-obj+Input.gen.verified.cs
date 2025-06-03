//HintName: Model_constraint-field-obj+Input.gen.cs
// Generated from constraint-field-obj+Input.graphql+

/*
*/

namespace GqlTest.Model_constraint_field_obj_Input;

public interface ICnstFieldObjInp
  : IRefCnstFieldObjInp
{
}
public class InputCnstFieldObjInp
  : InputRefCnstFieldObjInp
  , ICnstFieldObjInp
{
}

public interface IRefCnstFieldObjInp<Tref>
{
  Tref field { get; }
}
public class InputRefCnstFieldObjInp<Tref>
  : IRefCnstFieldObjInp<Tref>
{
  public Tref field { get; set; }
}

public interface IPrntCnstFieldObjInp
{
  String AsString { get; }
}
public class InputPrntCnstFieldObjInp
  : IPrntCnstFieldObjInp
{
  public String AsString { get; set; }
}

public interface IAltCnstFieldObjInp
  : IPrntCnstFieldObjInp
{
  Number alt { get; }
}
public class InputAltCnstFieldObjInp
  : InputPrntCnstFieldObjInp
  , IAltCnstFieldObjInp
{
  public Number alt { get; set; }
}
