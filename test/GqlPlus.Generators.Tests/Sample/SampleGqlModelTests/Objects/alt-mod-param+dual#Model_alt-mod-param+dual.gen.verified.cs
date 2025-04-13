//HintName: Model_alt-mod-param+dual.gen.cs
// Generated from alt-mod-param+dual.graphql+

/*
*/

namespace GqlTest.Model_alt_mod_param_dual;

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
