//HintName: Gqlp_generic-enum+Dual_Intf.gen.cs
// Generated from generic-enum+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_enum_Dual;

public interface IGnrcEnumDual
{
  RefGnrcEnumDual<EnumGnrcEnumDual> AsRefGnrcEnumDual { get; }
}

public interface IRefGnrcEnumDual<Ttype>
{
  Ttype field { get; }
}
