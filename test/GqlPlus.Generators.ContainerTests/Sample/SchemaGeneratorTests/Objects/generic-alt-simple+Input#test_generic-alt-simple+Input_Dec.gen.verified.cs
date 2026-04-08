//HintName: test_generic-alt-simple+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-alt-simple+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_simple_Input;

public interface ItestGnrcAltSmplInp
  // No Base because it's Class
{
  ItestRefGnrcAltSmplInp<string>? AsRefGnrcAltSmplInp { get; }
  ItestGnrcAltSmplInpObject? As_GnrcAltSmplInp { get; }
}

public interface ItestGnrcAltSmplInpObject
  // No Base because it's Class
{
}

public interface ItestRefGnrcAltSmplInp<TRef>
  // No Base because it's Class
{
  TRef? Asref { get; }
  ItestRefGnrcAltSmplInpObject<TRef>? As_RefGnrcAltSmplInp { get; }
}

public interface ItestRefGnrcAltSmplInpObject<TRef>
  // No Base because it's Class
{
}
