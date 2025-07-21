//HintName: Gqlp_parent-alt+Input_Impl.gen.cs
// Generated from parent-alt+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_parent_alt_Input;
public class InputPrntAltInp
  : InputRefPrntAltInp
  , IPrntAltInp
{
  public Number AsNumber { get; set; }
}
public class InputRefPrntAltInp
  : IRefPrntAltInp
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
