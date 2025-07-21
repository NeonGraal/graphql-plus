//HintName: Gqlp_generic-field-dual+Dual_Intf.gen.cs
// Generated from generic-field-dual+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_field_dual_Dual;

public interface IGnrcFieldDualDual
{
  RefGnrcFieldDualDual<AltGnrcFieldDualDual> field { get; }
}

public interface IRefGnrcFieldDualDual<Tref>
{
  Tref Asref { get; }
}

public interface IAltGnrcFieldDualDual
{
  Number alt { get; }
  String AsString { get; }
}
