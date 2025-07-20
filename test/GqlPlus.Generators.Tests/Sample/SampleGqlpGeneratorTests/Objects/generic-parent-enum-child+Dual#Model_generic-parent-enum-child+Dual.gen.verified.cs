//HintName: Model_generic-parent-enum-child+Dual.gen.cs
// Generated from generic-parent-enum-child+Dual.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_generic_parent_enum_child_Dual;

public interface IGnrcPrntEnumChildDual
  : IFieldGnrcPrntEnumChildDual
{
}
public class DualGnrcPrntEnumChildDual
  : DualFieldGnrcPrntEnumChildDual
  , IGnrcPrntEnumChildDual
{
}

public interface IFieldGnrcPrntEnumChildDual<Tref>
{
  Tref field { get; }
}
public class DualFieldGnrcPrntEnumChildDual<Tref>
  : IFieldGnrcPrntEnumChildDual<Tref>
{
  public Tref field { get; set; }
}

public enum EnumGnrcPrntEnumChildDual
{
  gnrcPrntEnumChildDualParent = ParentGnrcPrntEnumChildDual.gnrcPrntEnumChildDualParent,
  gnrcPrntEnumChildDualLabel,
}

public enum ParentGnrcPrntEnumChildDual
{
  gnrcPrntEnumChildDualParent,
}
