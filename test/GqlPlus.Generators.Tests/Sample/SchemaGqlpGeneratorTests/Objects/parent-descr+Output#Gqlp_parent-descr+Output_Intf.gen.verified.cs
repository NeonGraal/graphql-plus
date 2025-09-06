//HintName: Gqlp_parent-descr+Output_Intf.gen.cs
// Generated from parent-descr+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_parent_descr_Output;

public interface IPrntDescrOutp
  : IRefPrntDescrOutp
{
}

public interface IRefPrntDescrOutp
{
  Number parent { get; }
  String AsString { get; }
}
