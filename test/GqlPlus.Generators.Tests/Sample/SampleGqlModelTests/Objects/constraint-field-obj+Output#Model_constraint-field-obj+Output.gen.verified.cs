//HintName: Model_constraint-field-obj+Output.gen.cs
// Generated from constraint-field-obj+Output.graphql+

/*
*/

namespace GqlTest.Model_constraint_field_obj_Output;

public interface ICnstFieldObjOutp
  : IRefCnstFieldObjOutp
{
}
public class OutputCnstFieldObjOutp
  : OutputRefCnstFieldObjOutp
  , ICnstFieldObjOutp
{
}

public interface IRefCnstFieldObjOutp<Tref>
{
  Tref field { get; }
}
public class OutputRefCnstFieldObjOutp<Tref>
  : IRefCnstFieldObjOutp<Tref>
{
  public Tref field { get; set; }
}

public interface IPrntCnstFieldObjOutp
{
  String AsString { get; }
}
public class OutputPrntCnstFieldObjOutp
  : IPrntCnstFieldObjOutp
{
  public String AsString { get; set; }
}

public interface IAltCnstFieldObjOutp
  : IPrntCnstFieldObjOutp
{
  Number alt { get; }
}
public class OutputAltCnstFieldObjOutp
  : OutputPrntCnstFieldObjOutp
  , IAltCnstFieldObjOutp
{
  public Number alt { get; set; }
}
