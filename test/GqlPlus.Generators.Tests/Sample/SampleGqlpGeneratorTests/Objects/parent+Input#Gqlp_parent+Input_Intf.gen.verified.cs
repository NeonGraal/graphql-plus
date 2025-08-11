//HintName: Gqlp_parent+Input_Intf.gen.cs
// Generated from parent+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_parent_Input;

public interface IPrntInp
  : IRefPrntInp
{
}

public interface IRefPrntInp
{
  Number parent { get; }
  String AsString { get; }
}
