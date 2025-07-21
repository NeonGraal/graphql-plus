//HintName: Gqlp_parent-alt+Output_Intf.gen.cs
// Generated from parent-alt+Output.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_parent_alt_Output;

public interface IPrntAltOutp
  : IRefPrntAltOutp
{
  Number AsNumber { get; }
}

public interface IRefPrntAltOutp
{
  Number parent { get; }
  String AsString { get; }
}
