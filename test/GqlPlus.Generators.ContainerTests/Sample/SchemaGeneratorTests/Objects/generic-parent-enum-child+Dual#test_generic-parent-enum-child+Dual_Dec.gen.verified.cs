//HintName: test_generic-parent-enum-child+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-child+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_child_Dual;

public interface ItestGnrcPrntEnumChildDual
  : ItestFieldGnrcPrntEnumChildDual<testParentGnrcPrntEnumChildDual>
{
  ItestGnrcPrntEnumChildDualObject? As_GnrcPrntEnumChildDual { get; }
}

public interface ItestGnrcPrntEnumChildDualObject
  : ItestFieldGnrcPrntEnumChildDualObject<testParentGnrcPrntEnumChildDual>
{
}

public interface ItestFieldGnrcPrntEnumChildDual<TRef>
  // No Base because it's Class
{
  ItestFieldGnrcPrntEnumChildDualObject<TRef>? As_FieldGnrcPrntEnumChildDual { get; }
}

public interface ItestFieldGnrcPrntEnumChildDualObject<TRef>
  // No Base because it's Class
{
  TRef Field { get; }
}

public enum testEnumGnrcPrntEnumChildDual
{
  gnrcPrntEnumChildDualParent = testParentGnrcPrntEnumChildDual.gnrcPrntEnumChildDualParent,
  gnrcPrntEnumChildDualLabel,
}

public enum testParentGnrcPrntEnumChildDual
{
  gnrcPrntEnumChildDualParent,
}
