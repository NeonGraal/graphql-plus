//HintName: test_generic-parent-simple-enum+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-simple-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_simple_enum_Output;

public interface ItestGnrcPrntSmplEnumOutp
  : ItestFieldGnrcPrntSmplEnumOutp<testEnumGnrcPrntSmplEnumOutp>
{
  ItestGnrcPrntSmplEnumOutpObject? As_GnrcPrntSmplEnumOutp { get; }
}

public interface ItestGnrcPrntSmplEnumOutpObject
  : ItestFieldGnrcPrntSmplEnumOutpObject<testEnumGnrcPrntSmplEnumOutp>
{
}

public interface ItestFieldGnrcPrntSmplEnumOutp<TRef>
  // No Base because it's Class
{
  ItestFieldGnrcPrntSmplEnumOutpObject<TRef>? As_FieldGnrcPrntSmplEnumOutp { get; }
}

public interface ItestFieldGnrcPrntSmplEnumOutpObject<TRef>
  // No Base because it's Class
{
  TRef Field { get; }
}

public enum testEnumGnrcPrntSmplEnumOutp
{
  gnrcPrntSmplEnumOutp,
}
