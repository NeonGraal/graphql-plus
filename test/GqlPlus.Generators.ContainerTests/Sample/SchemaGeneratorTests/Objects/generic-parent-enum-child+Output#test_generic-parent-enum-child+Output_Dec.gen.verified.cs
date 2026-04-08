//HintName: test_generic-parent-enum-child+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-child+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_child_Output;

public interface ItestGnrcPrntEnumChildOutp
  : ItestFieldGnrcPrntEnumChildOutp<testParentGnrcPrntEnumChildOutp>
{
  ItestGnrcPrntEnumChildOutpObject? As_GnrcPrntEnumChildOutp { get; }
}

public interface ItestGnrcPrntEnumChildOutpObject
  : ItestFieldGnrcPrntEnumChildOutpObject<testParentGnrcPrntEnumChildOutp>
{
}

public interface ItestFieldGnrcPrntEnumChildOutp<TRef>
  // No Base because it's Class
{
  ItestFieldGnrcPrntEnumChildOutpObject<TRef>? As_FieldGnrcPrntEnumChildOutp { get; }
}

public interface ItestFieldGnrcPrntEnumChildOutpObject<TRef>
  // No Base because it's Class
{
  TRef Field { get; }
}

public enum testEnumGnrcPrntEnumChildOutp
{
  gnrcPrntEnumChildOutpParent = testParentGnrcPrntEnumChildOutp.gnrcPrntEnumChildOutpParent,
  gnrcPrntEnumChildOutpLabel,
}

public enum testParentGnrcPrntEnumChildOutp
{
  gnrcPrntEnumChildOutpParent,
}
