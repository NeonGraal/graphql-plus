//HintName: test_generic-parent-enum-parent+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_parent_Dual;

public interface ItestGnrcPrntEnumPrntDual
  : ItestFieldGnrcPrntEnumPrntDual<testEnumGnrcPrntEnumPrntDual>
{
  ItestGnrcPrntEnumPrntDualObject? As_GnrcPrntEnumPrntDual { get; }
}

public interface ItestGnrcPrntEnumPrntDualObject
  : ItestFieldGnrcPrntEnumPrntDualObject<testEnumGnrcPrntEnumPrntDual>
{
}

public interface ItestFieldGnrcPrntEnumPrntDual<TRef>
  // No Base because it's Class
{
  ItestFieldGnrcPrntEnumPrntDualObject<TRef>? As_FieldGnrcPrntEnumPrntDual { get; }
}

public interface ItestFieldGnrcPrntEnumPrntDualObject<TRef>
  // No Base because it's Class
{
  TRef Field { get; }
}

public enum testEnumGnrcPrntEnumPrntDual
{
  gnrcPrntEnumPrntDualParent = testParentGnrcPrntEnumPrntDual.gnrcPrntEnumPrntDualParent,
  gnrcPrntEnumPrntDualLabel,
}

public enum testParentGnrcPrntEnumPrntDual
{
  gnrcPrntEnumPrntDualParent,
}
