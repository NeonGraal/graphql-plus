//HintName: Model_alt-mod-Boolean+dual.gen.cs
// Generated from alt-mod-Boolean+dual.graphql+

/*
*/

namespace GqlTest.Model_alt_mod_Boolean_dual;

public interface IDualAltModBool
{
  AltDualAltModBool AsAltDualAltModBool { get; }
}
public class DualDualAltModBool
  : IDualAltModBool
{
  public AltDualAltModBool AsAltDualAltModBool { get; set; }
}

public interface IAltDualAltModBool
{
  Number alt { get; }
  String AsString { get; }
}
public class DualAltDualAltModBool
  : IAltDualAltModBool
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
