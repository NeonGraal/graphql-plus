//HintName: Model_constraint-alt-dual+Input.gen.cs
// Generated from constraint-alt-dual+Input.graphql+

/*
*/

namespace GqlTest.Model_constraint_alt_dual_Input;

public interface ICnstAltDualInp
{
  RefCnstAltDualInp<AltCnstAltDualInp> AsRefCnstAltDualInp { get; }
}
public class InputCnstAltDualInp
  : ICnstAltDualInp
{
  public RefCnstAltDualInp<AltCnstAltDualInp> AsRefCnstAltDualInp { get; set; }
}

public interface IRefCnstAltDualInp<Tref>
{
  Tref Asref { get; }
}
public class InputRefCnstAltDualInp<Tref>
  : IRefCnstAltDualInp<Tref>
{
  public Tref Asref { get; set; }
}

public interface IPrntCnstAltDualInp
{
  String AsString { get; }
}
public class DualPrntCnstAltDualInp
  : IPrntCnstAltDualInp
{
  public String AsString { get; set; }
}

public interface IAltCnstAltDualInp
  : IPrntCnstAltDualInp
{
  Number alt { get; }
}
public class InputAltCnstAltDualInp
  : InputPrntCnstAltDualInp
  , IAltCnstAltDualInp
{
  public Number alt { get; set; }
}
