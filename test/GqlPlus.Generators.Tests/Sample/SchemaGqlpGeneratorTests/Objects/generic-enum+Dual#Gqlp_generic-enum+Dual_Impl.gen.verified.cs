//HintName: Gqlp_generic-enum+Dual_Impl.gen.cs
// Generated from generic-enum+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_enum_Dual;

public class DualGnrcEnumDual
  : IGnrcEnumDual
{
  public RefGnrcEnumDual<EnumGnrcEnumDual> AsRefGnrcEnumDual { get; set; }
}

public class DualRefGnrcEnumDual<Ttype>
  : IRefGnrcEnumDual<Ttype>
{
  public Ttype field { get; set; }
}
