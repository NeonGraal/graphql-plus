//HintName: test_generic-parent-enum-parent+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_parent_Input;

public interface ItestGnrcPrntEnumPrntInp
  : ItestFieldGnrcPrntEnumPrntInp<testEnumGnrcPrntEnumPrntInp>
{
  ItestGnrcPrntEnumPrntInpObject? As_GnrcPrntEnumPrntInp { get; }
}

public interface ItestGnrcPrntEnumPrntInpObject
  : ItestFieldGnrcPrntEnumPrntInpObject<testEnumGnrcPrntEnumPrntInp>
{
}

public interface ItestFieldGnrcPrntEnumPrntInp<TRef>
  // No Base because it's Class
{
  ItestFieldGnrcPrntEnumPrntInpObject<TRef>? As_FieldGnrcPrntEnumPrntInp { get; }
}

public interface ItestFieldGnrcPrntEnumPrntInpObject<TRef>
  // No Base because it's Class
{
  TRef Field { get; }
}

public enum testEnumGnrcPrntEnumPrntInp
{
  gnrcPrntEnumPrntInpParent = testParentGnrcPrntEnumPrntInp.gnrcPrntEnumPrntInpParent,
  gnrcPrntEnumPrntInpLabel,
}

public enum testParentGnrcPrntEnumPrntInp
{
  gnrcPrntEnumPrntInpParent,
}
