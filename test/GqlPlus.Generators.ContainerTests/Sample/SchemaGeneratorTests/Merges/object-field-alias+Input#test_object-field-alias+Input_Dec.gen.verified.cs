//HintName: test_object-field-alias+Input_Dec.gen.cs
// Generated from {CurrentDirectory}object-field-alias+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_alias_Input;

internal class testObjFieldAliasInpDecoder : IDecoder<ItestObjFieldAliasInpObject>
{
  public ItestFldObjFieldAliasInp? Field { get; set; }

  public IMessages Decode(IValue input, out ItestObjFieldAliasInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjFieldAliasInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldObjFieldAliasInpDecoder : IDecoder<ItestFldObjFieldAliasInpObject>
{

  public IMessages Decode(IValue input, out ItestFldObjFieldAliasInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFldObjFieldAliasInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_object_field_alias_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_object_field_alias_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestObjFieldAliasInpObject>(testObjFieldAliasInpDecoder.Factory)
      .AddDecoder<ItestFldObjFieldAliasInpObject>(testFldObjFieldAliasInpDecoder.Factory);
}
