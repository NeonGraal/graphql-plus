//HintName: Gqlp_parent-alt+Dual_Intf.gen.cs
// Generated from parent-alt+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_parent_alt_Dual;

public interface IPrntAltDual
  : IRefPrntAltDual
{
  Number AsNumber { get; }
}

public interface IRefPrntAltDual
{
  Number parent { get; }
  String AsString { get; }
}
