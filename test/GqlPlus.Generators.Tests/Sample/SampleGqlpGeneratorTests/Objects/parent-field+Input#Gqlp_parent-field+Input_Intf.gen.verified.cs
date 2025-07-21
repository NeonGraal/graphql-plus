//HintName: Gqlp_parent-field+Input_Intf.gen.cs
// Generated from parent-field+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_parent_field_Input;

public interface IPrntFieldInp
  : IRefPrntFieldInp
{
  Number field { get; }
}

public interface IRefPrntFieldInp
{
  Number parent { get; }
  String AsString { get; }
}
