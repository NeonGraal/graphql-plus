//HintName: Gqlp_constraint-enum+Dual_Intf.gen.cs
// Generated from constraint-enum+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_enum_Dual;

public interface ICnstEnumDual
{
  RefCnstEnumDual<EnumCnstEnumDual> AsRefCnstEnumDual { get; }
}

public interface IRefCnstEnumDual<Ttype>
{
  Ttype field { get; }
}
