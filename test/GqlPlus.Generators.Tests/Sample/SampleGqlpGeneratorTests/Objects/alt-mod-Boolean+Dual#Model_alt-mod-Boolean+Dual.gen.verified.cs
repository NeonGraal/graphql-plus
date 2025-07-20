//HintName: Model_alt-mod-Boolean+Dual.gen.cs
// Generated from alt-mod-Boolean+Dual.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_alt_mod_Boolean_Dual;

public interface IAltModBoolDual
{
  AltAltModBoolDual AsAltAltModBoolDual { get; }
}
public class DualAltModBoolDual
  : IAltModBoolDual
{
  public AltAltModBoolDual AsAltAltModBoolDual { get; set; }
}

public interface IAltAltModBoolDual
{
  Number alt { get; }
  String AsString { get; }
}
public class DualAltAltModBoolDual
  : IAltAltModBoolDual
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
