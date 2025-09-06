//HintName: Gqlp_parent+Dual_Intf.gen.cs
// Generated from parent+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_parent_Dual;

public interface IPrntDual
  : IRefPrntDual
{
}

public interface IRefPrntDual
{
  Number parent { get; }
  String AsString { get; }
}
