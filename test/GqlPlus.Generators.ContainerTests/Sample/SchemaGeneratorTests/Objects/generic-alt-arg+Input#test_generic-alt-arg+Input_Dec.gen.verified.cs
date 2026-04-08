//HintName: test_generic-alt-arg+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-alt-arg+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_Input;

public interface ItestGnrcAltArgInp<TType>
  // No Base because it's Class
{
  ItestRefGnrcAltArgInp<TType>? AsRefGnrcAltArgInp { get; }
  ItestGnrcAltArgInpObject<TType>? As_GnrcAltArgInp { get; }
}

public interface ItestGnrcAltArgInpObject<TType>
  // No Base because it's Class
{
}

public interface ItestRefGnrcAltArgInp<TRef>
  // No Base because it's Class
{
  TRef? Asref { get; }
  ItestRefGnrcAltArgInpObject<TRef>? As_RefGnrcAltArgInp { get; }
}

public interface ItestRefGnrcAltArgInpObject<TRef>
  // No Base because it's Class
{
}
