//HintName: Gqlp_generic-parent-enum-child+Dual_Impl.gen.cs
// Generated from generic-parent-enum-child+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_parent_enum_child_Dual;

public class DualGnrcPrntEnumChildDual
  : DualFieldGnrcPrntEnumChildDual
  , IGnrcPrntEnumChildDual
{
}

public class DualFieldGnrcPrntEnumChildDual<Tref>
  : IFieldGnrcPrntEnumChildDual<Tref>
{
  public Tref field { get; set; }
}
