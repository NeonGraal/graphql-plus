//HintName: Model_generic-parent-enum-parent+Dual.gen.cs
// Generated from generic-parent-enum-parent+Dual.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_generic_parent_enum_parent_Dual;

public interface IGnrcPrntEnumPrntDual
  : IFieldGnrcPrntEnumPrntDual
{
}
public class DualGnrcPrntEnumPrntDual
  : DualFieldGnrcPrntEnumPrntDual
  , IGnrcPrntEnumPrntDual
{
}

public interface IFieldGnrcPrntEnumPrntDual<Tref>
{
  Tref field { get; }
}
public class DualFieldGnrcPrntEnumPrntDual<Tref>
  : IFieldGnrcPrntEnumPrntDual<Tref>
{
  public Tref field { get; set; }
}

public enum EnumGnrcPrntEnumPrntDual
{
  gnrcPrntEnumPrntDualParent = ParentGnrcPrntEnumPrntDual.gnrcPrntEnumPrntDualParent,
  gnrcPrntEnumPrntDualLabel,
}

public enum ParentGnrcPrntEnumPrntDual
{
  gnrcPrntEnumPrntDualParent,
}
