//HintName: test_generic-parent-simple-enum+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-simple-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_simple_enum_Dual;

public interface ItestGnrcPrntSmplEnumDual
  : ItestFieldGnrcPrntSmplEnumDual<testEnumGnrcPrntSmplEnumDual>
{
  ItestGnrcPrntSmplEnumDualObject? As_GnrcPrntSmplEnumDual { get; }
}

public interface ItestGnrcPrntSmplEnumDualObject
  : ItestFieldGnrcPrntSmplEnumDualObject<testEnumGnrcPrntSmplEnumDual>
{
}

public interface ItestFieldGnrcPrntSmplEnumDual<TRef>
  // No Base because it's Class
{
  ItestFieldGnrcPrntSmplEnumDualObject<TRef>? As_FieldGnrcPrntSmplEnumDual { get; }
}

public interface ItestFieldGnrcPrntSmplEnumDualObject<TRef>
  // No Base because it's Class
{
  TRef Field { get; }
}

public enum testEnumGnrcPrntSmplEnumDual
{
  gnrcPrntSmplEnumDual,
}
