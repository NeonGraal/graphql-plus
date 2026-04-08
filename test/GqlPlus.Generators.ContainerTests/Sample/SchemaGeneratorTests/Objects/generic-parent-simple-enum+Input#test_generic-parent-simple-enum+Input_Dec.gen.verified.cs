//HintName: test_generic-parent-simple-enum+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-simple-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_simple_enum_Input;

public interface ItestGnrcPrntSmplEnumInp
  : ItestFieldGnrcPrntSmplEnumInp<testEnumGnrcPrntSmplEnumInp>
{
  ItestGnrcPrntSmplEnumInpObject? As_GnrcPrntSmplEnumInp { get; }
}

public interface ItestGnrcPrntSmplEnumInpObject
  : ItestFieldGnrcPrntSmplEnumInpObject<testEnumGnrcPrntSmplEnumInp>
{
}

public interface ItestFieldGnrcPrntSmplEnumInp<TRef>
  // No Base because it's Class
{
  ItestFieldGnrcPrntSmplEnumInpObject<TRef>? As_FieldGnrcPrntSmplEnumInp { get; }
}

public interface ItestFieldGnrcPrntSmplEnumInpObject<TRef>
  // No Base because it's Class
{
  TRef Field { get; }
}

public enum testEnumGnrcPrntSmplEnumInp
{
  gnrcPrntSmplEnumInp,
}
