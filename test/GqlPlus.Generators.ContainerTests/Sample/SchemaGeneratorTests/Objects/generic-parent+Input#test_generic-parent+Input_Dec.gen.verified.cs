//HintName: test_generic-parent+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_Input;

public interface ItestGnrcPrntInp<TType>
  // No Base because it's Class
{
  TType? As_Parent { get; }
  ItestGnrcPrntInpObject<TType>? As_GnrcPrntInp { get; }
}

public interface ItestGnrcPrntInpObject<TType>
  // No Base because it's Class
{
}
