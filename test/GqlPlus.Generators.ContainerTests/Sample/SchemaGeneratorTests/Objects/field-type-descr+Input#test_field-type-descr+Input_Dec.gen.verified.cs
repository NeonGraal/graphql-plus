//HintName: test_field-type-descr+Input_Dec.gen.cs
// Generated from {CurrentDirectory}field-type-descr+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_type_descr_Input;

internal class testFieldTypeDescrInpDecoder : IDecoder<ItestFieldTypeDescrInpObject>
{
  public decimal? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFieldTypeDescrInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFieldTypeDescrInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_field_type_descr_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_type_descr_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldTypeDescrInpObject>(testFieldTypeDescrInpDecoder.Factory);
}
