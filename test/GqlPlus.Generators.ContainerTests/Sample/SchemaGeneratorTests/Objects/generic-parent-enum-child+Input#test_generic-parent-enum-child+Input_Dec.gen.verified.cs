//HintName: test_generic-parent-enum-child+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-child+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_child_Input;

public interface ItestGnrcPrntEnumChildInp
  : ItestFieldGnrcPrntEnumChildInp<testParentGnrcPrntEnumChildInp>
{
  ItestGnrcPrntEnumChildInpObject? As_GnrcPrntEnumChildInp { get; }
}

public interface ItestGnrcPrntEnumChildInpObject
  : ItestFieldGnrcPrntEnumChildInpObject<testParentGnrcPrntEnumChildInp>
{
}

public interface ItestFieldGnrcPrntEnumChildInp<TRef>
  // No Base because it's Class
{
  ItestFieldGnrcPrntEnumChildInpObject<TRef>? As_FieldGnrcPrntEnumChildInp { get; }
}

public interface ItestFieldGnrcPrntEnumChildInpObject<TRef>
  // No Base because it's Class
{
  TRef Field { get; }
}

public enum testEnumGnrcPrntEnumChildInp
{
  gnrcPrntEnumChildInpParent = testParentGnrcPrntEnumChildInp.gnrcPrntEnumChildInpParent,
  gnrcPrntEnumChildInpLabel,
}

public enum testParentGnrcPrntEnumChildInp
{
  gnrcPrntEnumChildInpParent,
}
