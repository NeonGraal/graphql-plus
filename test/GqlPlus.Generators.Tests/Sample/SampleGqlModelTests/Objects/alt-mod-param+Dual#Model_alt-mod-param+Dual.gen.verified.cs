//HintName: Model_alt-mod-param+Dual.gen.cs
// Generated from alt-mod-param+Dual.graphql+

/*
*/

namespace GqlTest.Model_alt_mod_param_Dual;

public interface IAltModParamDual<Tmod>
{
  AltAltModParamDual AsAltAltModParamDual { get; }
}
public class DualAltModParamDual<Tmod>
  : IAltModParamDual<Tmod>
{
  public AltAltModParamDual AsAltAltModParamDual { get; set; }
}

public interface IAltAltModParamDual
{
  Number alt { get; }
  String AsString { get; }
}
public class DualAltAltModParamDual
  : IAltAltModParamDual
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
