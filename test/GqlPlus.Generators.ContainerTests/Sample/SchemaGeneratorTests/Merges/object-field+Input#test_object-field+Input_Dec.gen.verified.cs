//HintName: test_object-field+Input_Dec.gen.cs
// Generated from {CurrentDirectory}object-field+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_Input;

internal class testObjFieldInpDecoder
{
  public ItestFldObjFieldInp Field { get; set; }

  internal static testObjFieldInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldObjFieldInpDecoder
{

  internal static testFldObjFieldInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_object_field_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_object_field_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestObjFieldInpObject>(testObjFieldInpDecoder.Factory)
      .AddDecoder<ItestFldObjFieldInpObject>(testFldObjFieldInpDecoder.Factory);
}
