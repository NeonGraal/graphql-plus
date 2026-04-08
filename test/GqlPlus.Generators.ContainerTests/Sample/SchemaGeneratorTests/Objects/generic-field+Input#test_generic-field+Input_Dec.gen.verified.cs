//HintName: test_generic-field+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-field+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_Input;

public interface ItestGnrcFieldInp<TType>
  // No Base because it's Class
{
  ItestGnrcFieldInpObject<TType>? As_GnrcFieldInp { get; }
}

public interface ItestGnrcFieldInpObject<TType>
  // No Base because it's Class
{
  TType Field { get; }
}
