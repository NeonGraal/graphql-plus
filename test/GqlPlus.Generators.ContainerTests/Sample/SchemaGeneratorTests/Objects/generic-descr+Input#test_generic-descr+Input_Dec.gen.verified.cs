//HintName: test_generic-descr+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-descr+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_descr_Input;

public interface ItestGnrcDescrInp<TType>
  // No Base because it's Class
{
  ItestGnrcDescrInpObject<TType>? As_GnrcDescrInp { get; }
}

public interface ItestGnrcDescrInpObject<TType>
  // No Base because it's Class
{
  TType Field { get; }
}
