//HintName: Model_parent-dual+Input.gen.cs
// Generated from parent-dual+Input.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_parent_dual_Input;

public interface IPrntDualInp
  : IRefPrntDualInp
{
}
public class InputPrntDualInp
  : InputRefPrntDualInp
  , IPrntDualInp
{
}

public interface IRefPrntDualInp
{
  Number parent { get; }
  String AsString { get; }
}
public class DualRefPrntDualInp
  : IRefPrntDualInp
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
