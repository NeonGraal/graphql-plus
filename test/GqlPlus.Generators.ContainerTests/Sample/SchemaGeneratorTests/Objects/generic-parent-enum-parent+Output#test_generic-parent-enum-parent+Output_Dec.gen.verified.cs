//HintName: test_generic-parent-enum-parent+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_parent_Output;

public interface ItestGnrcPrntEnumPrntOutp
  : ItestFieldGnrcPrntEnumPrntOutp<testEnumGnrcPrntEnumPrntOutp>
{
  ItestGnrcPrntEnumPrntOutpObject? As_GnrcPrntEnumPrntOutp { get; }
}

public interface ItestGnrcPrntEnumPrntOutpObject
  : ItestFieldGnrcPrntEnumPrntOutpObject<testEnumGnrcPrntEnumPrntOutp>
{
}

public interface ItestFieldGnrcPrntEnumPrntOutp<TRef>
  // No Base because it's Class
{
  ItestFieldGnrcPrntEnumPrntOutpObject<TRef>? As_FieldGnrcPrntEnumPrntOutp { get; }
}

public interface ItestFieldGnrcPrntEnumPrntOutpObject<TRef>
  // No Base because it's Class
{
  TRef Field { get; }
}

public enum testEnumGnrcPrntEnumPrntOutp
{
  gnrcPrntEnumPrntOutpParent = testParentGnrcPrntEnumPrntOutp.gnrcPrntEnumPrntOutpParent,
  gnrcPrntEnumPrntOutpLabel,
}

public enum testParentGnrcPrntEnumPrntOutp
{
  gnrcPrntEnumPrntOutpParent,
}
