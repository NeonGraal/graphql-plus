//HintName: Model_field-dual+Input.gen.cs
// Generated from field-dual+Input.graphql+

/*
*/

namespace GqlTest.Model_field_dual_Input;

public interface IFieldDualInp
{
  FldFieldDualInp field { get; }
}
public class InputFieldDualInp
  : IFieldDualInp
{
  public FldFieldDualInp field { get; set; }
}

public interface IFldFieldDualInp
{
  Number field { get; }
  String AsString { get; }
}
public class DualFldFieldDualInp
  : IFldFieldDualInp
{
  public Number field { get; set; }
  public String AsString { get; set; }
}
