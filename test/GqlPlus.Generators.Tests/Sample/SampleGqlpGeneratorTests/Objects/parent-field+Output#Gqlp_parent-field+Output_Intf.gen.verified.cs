//HintName: Gqlp_parent-field+Output_Intf.gen.cs
// Generated from parent-field+Output.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_parent_field_Output;

public interface IPrntFieldOutp
  : IRefPrntFieldOutp
{
  Number field { get; }
}

public interface IRefPrntFieldOutp
{
  Number parent { get; }
  String AsString { get; }
}
