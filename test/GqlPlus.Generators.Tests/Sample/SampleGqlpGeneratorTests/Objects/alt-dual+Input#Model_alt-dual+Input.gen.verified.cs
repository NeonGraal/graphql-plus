//HintName: Model_alt-dual+Input.gen.cs
// Generated from alt-dual+Input.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_alt_dual_Input;

public interface IAltDualInp
{
  ObjDualAltDualInp AsObjDualAltDualInp { get; }
}
public class InputAltDualInp
  : IAltDualInp
{
  public ObjDualAltDualInp AsObjDualAltDualInp { get; set; }
}

public interface IObjDualAltDualInp
{
  Number alt { get; }
  String AsString { get; }
}
public class DualObjDualAltDualInp
  : IObjDualAltDualInp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
