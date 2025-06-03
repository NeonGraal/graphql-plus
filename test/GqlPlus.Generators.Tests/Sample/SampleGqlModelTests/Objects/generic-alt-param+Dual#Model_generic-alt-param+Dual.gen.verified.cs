//HintName: Model_generic-alt-param+Dual.gen.cs
// Generated from generic-alt-param+Dual.graphql+

/*
*/

namespace GqlTest.Model_generic_alt_param_Dual;

public interface IGnrcAltParamDual
{
  RefGnrcAltParamDual<AltGnrcAltParamDual> AsRefGnrcAltParamDual { get; }
}
public class DualGnrcAltParamDual
  : IGnrcAltParamDual
{
  public RefGnrcAltParamDual<AltGnrcAltParamDual> AsRefGnrcAltParamDual { get; set; }
}

public interface IRefGnrcAltParamDual<Tref>
{
  Tref Asref { get; }
}
public class DualRefGnrcAltParamDual<Tref>
  : IRefGnrcAltParamDual<Tref>
{
  public Tref Asref { get; set; }
}

public interface IAltGnrcAltParamDual
{
  Number alt { get; }
  String AsString { get; }
}
public class DualAltGnrcAltParamDual
  : IAltGnrcAltParamDual
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
