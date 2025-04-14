//HintName: Model_generic-alt-param+dual.gen.cs
// Generated from generic-alt-param+dual.graphql+

/*
*/

namespace GqlTest.Model_generic_alt_param_dual;

public interface IDualGnrcAltParam
{
  RefDualGnrcAltParam<AltDualGnrcAltParam> AsRefDualGnrcAltParam { get; }
}
public class DualDualGnrcAltParam
  : IDualGnrcAltParam
{
  public RefDualGnrcAltParam<AltDualGnrcAltParam> AsRefDualGnrcAltParam { get; set; }
}

public interface IRefDualGnrcAltParam<Tref>
{
  Tref Asref { get; }
}
public class DualRefDualGnrcAltParam<Tref>
  : IRefDualGnrcAltParam<Tref>
{
  public Tref Asref { get; set; }
}

public interface IAltDualGnrcAltParam
{
  Number alt { get; }
  String AsString { get; }
}
public class DualAltDualGnrcAltParam
  : IAltDualGnrcAltParam
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
