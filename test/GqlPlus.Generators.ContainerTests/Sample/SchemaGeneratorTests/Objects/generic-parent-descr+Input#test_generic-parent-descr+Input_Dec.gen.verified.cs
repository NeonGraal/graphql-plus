//HintName: test_generic-parent-descr+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-descr+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_descr_Input;

public interface ItestGnrcPrntDescrInp<TType>
  // No Base because it's Class
{
  TType? As_Parent { get; }
  ItestGnrcPrntDescrInpObject<TType>? As_GnrcPrntDescrInp { get; }
}

public interface ItestGnrcPrntDescrInpObject<TType>
  // No Base because it's Class
{
}
