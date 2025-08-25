//HintName: Gqlp_parent-field+Dual_Intf.gen.cs
// Generated from parent-field+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_parent_field_Dual;

public interface IPrntFieldDual
  : IRefPrntFieldDual
{
  Number field { get; }
}

public interface IRefPrntFieldDual
{
  Number parent { get; }
  String AsString { get; }
}
