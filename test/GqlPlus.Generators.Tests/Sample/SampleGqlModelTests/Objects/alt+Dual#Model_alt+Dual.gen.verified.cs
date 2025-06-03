//HintName: Model_alt+Dual.gen.cs
// Generated from alt+Dual.graphql+

/*
*/

namespace GqlTest.Model_alt_Dual;

public interface IDualAlt
{
  AltDualAlt AsAltDualAlt { get; }
}
public class DualDualAlt
  : IDualAlt
{
  public AltDualAlt AsAltDualAlt { get; set; }
}

public interface IAltDualAlt
{
  Number alt { get; }
  String AsString { get; }
}
public class DualAltDualAlt
  : IAltDualAlt
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
