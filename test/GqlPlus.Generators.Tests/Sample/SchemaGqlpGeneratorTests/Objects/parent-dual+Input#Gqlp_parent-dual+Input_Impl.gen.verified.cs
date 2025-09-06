//HintName: Gqlp_parent-dual+Input_Impl.gen.cs
// Generated from parent-dual+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_parent_dual_Input;

public class InputPrntDualInp
  : InputRefPrntDualInp
  , IPrntDualInp
{
}

public class DualRefPrntDualInp
  : IRefPrntDualInp
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
