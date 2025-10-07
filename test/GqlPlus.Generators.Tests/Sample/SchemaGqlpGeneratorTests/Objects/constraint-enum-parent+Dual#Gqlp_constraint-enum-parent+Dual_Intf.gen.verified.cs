//HintName: Gqlp_constraint-enum-parent+Dual_Intf.gen.cs
// Generated from constraint-enum-parent+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_enum_parent_Dual;

public interface ICnstEnumPrntDual
{
  RefCnstEnumPrntDual<EnumCnstEnumPrntDual> AsRefCnstEnumPrntDual { get; }
}

public interface IRefCnstEnumPrntDual<Ttype>
{
  Ttype field { get; }
}
