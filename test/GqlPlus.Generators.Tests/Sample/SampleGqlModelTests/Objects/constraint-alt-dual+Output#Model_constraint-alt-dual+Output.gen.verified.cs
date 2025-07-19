//HintName: Model_constraint-alt-dual+Output.gen.cs
// Generated from constraint-alt-dual+Output.graphql+

/*
*/

namespace GqlTest.Model_constraint_alt_dual_Output;

public interface ICnstAltDualOutp
{
  RefCnstAltDualOutp<AltCnstAltDualOutp> AsRefCnstAltDualOutp { get; }
}
public class OutputCnstAltDualOutp
  : ICnstAltDualOutp
{
  public RefCnstAltDualOutp<AltCnstAltDualOutp> AsRefCnstAltDualOutp { get; set; }
}

public interface IRefCnstAltDualOutp<Tref>
{
  Tref Asref { get; }
}
public class OutputRefCnstAltDualOutp<Tref>
  : IRefCnstAltDualOutp<Tref>
{
  public Tref Asref { get; set; }
}

public interface IPrntCnstAltDualOutp
{
  String AsString { get; }
}
public class DualPrntCnstAltDualOutp
  : IPrntCnstAltDualOutp
{
  public String AsString { get; set; }
}

public interface IAltCnstAltDualOutp
  : IPrntCnstAltDualOutp
{
  Number alt { get; }
}
public class OutputAltCnstAltDualOutp
  : OutputPrntCnstAltDualOutp
  , IAltCnstAltDualOutp
{
  public Number alt { get; set; }
}
