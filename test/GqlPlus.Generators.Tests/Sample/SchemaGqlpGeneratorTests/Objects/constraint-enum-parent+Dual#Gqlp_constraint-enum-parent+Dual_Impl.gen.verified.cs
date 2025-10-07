//HintName: Gqlp_constraint-enum-parent+Dual_Impl.gen.cs
// Generated from constraint-enum-parent+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_enum_parent_Dual;

public class DualCnstEnumPrntDual
  : ICnstEnumPrntDual
{
  public RefCnstEnumPrntDual<EnumCnstEnumPrntDual> AsRefCnstEnumPrntDual { get; set; }
}

public class DualRefCnstEnumPrntDual<Ttype>
  : IRefCnstEnumPrntDual<Ttype>
{
  public Ttype field { get; set; }
}
