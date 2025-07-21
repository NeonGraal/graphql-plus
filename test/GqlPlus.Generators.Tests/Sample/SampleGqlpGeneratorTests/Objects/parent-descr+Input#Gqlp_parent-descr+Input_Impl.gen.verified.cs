//HintName: Gqlp_parent-descr+Input_Impl.gen.cs
// Generated from parent-descr+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_parent_descr_Input;
public class InputPrntDescrInp
  : InputRefPrntDescrInp
  , IPrntDescrInp
{
}
public class InputRefPrntDescrInp
  : IRefPrntDescrInp
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
