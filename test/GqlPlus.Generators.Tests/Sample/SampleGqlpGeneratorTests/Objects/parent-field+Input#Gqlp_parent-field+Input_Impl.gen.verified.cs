//HintName: Gqlp_parent-field+Input_Impl.gen.cs
// Generated from parent-field+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_parent_field_Input;
public class InputPrntFieldInp
  : InputRefPrntFieldInp
  , IPrntFieldInp
{
  public Number field { get; set; }
}
public class InputRefPrntFieldInp
  : IRefPrntFieldInp
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
