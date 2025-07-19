//HintName: Model_constraint-field-dual+Input.gen.cs
// Generated from constraint-field-dual+Input.graphql+

/*
*/

namespace GqlTest.Model_constraint_field_dual_Input;

public interface ICnstFieldDualInp
  : IRefCnstFieldDualInp
{
}
public class InputCnstFieldDualInp
  : InputRefCnstFieldDualInp
  , ICnstFieldDualInp
{
}

public interface IRefCnstFieldDualInp<Tref>
{
  Tref field { get; }
}
public class InputRefCnstFieldDualInp<Tref>
  : IRefCnstFieldDualInp<Tref>
{
  public Tref field { get; set; }
}

public interface IPrntCnstFieldDualInp
{
  String AsString { get; }
}
public class DualPrntCnstFieldDualInp
  : IPrntCnstFieldDualInp
{
  public String AsString { get; set; }
}

public interface IAltCnstFieldDualInp
  : IPrntCnstFieldDualInp
{
  Number alt { get; }
}
public class InputAltCnstFieldDualInp
  : InputPrntCnstFieldDualInp
  , IAltCnstFieldDualInp
{
  public Number alt { get; set; }
}
