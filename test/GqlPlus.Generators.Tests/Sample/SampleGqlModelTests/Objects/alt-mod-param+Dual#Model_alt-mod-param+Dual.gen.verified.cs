//HintName: Model_alt-mod-param+Dual.gen.cs
// Generated from alt-mod-param+Dual.graphql+

/*
*/

namespace GqlTest.Model_alt_mod_param_Dual;

public interface IDualAltModParam<Tmod>
{
  AltDualAltModParam AsAltDualAltModParam { get; }
}
public class DualDualAltModParam<Tmod>
  : IDualAltModParam<Tmod>
{
  public AltDualAltModParam AsAltDualAltModParam { get; set; }
}

public interface IAltDualAltModParam
{
  Number alt { get; }
  String AsString { get; }
}
public class DualAltDualAltModParam
  : IAltDualAltModParam
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
