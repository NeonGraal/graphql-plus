//HintName: Gqlp_parent-alt+Input_Intf.gen.cs
// Generated from parent-alt+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_parent_alt_Input;

public interface IPrntAltInp
  : IRefPrntAltInp
{
  Number AsNumber { get; }
}

public interface IRefPrntAltInp
{
  Number parent { get; }
  String AsString { get; }
}
