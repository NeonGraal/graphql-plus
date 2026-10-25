//HintName: test_Schema_Enc.gen.cs
// Generated from {CurrentDirectory}Schema.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Schema;

internal class test_ReqEncoder<TT> : IEncoder<Itest_ReqObject<TT>>
{
  public IGqlpValue Encode(Itest_ReqObject<TT> input)
    => new GqlpUnit();
}

internal class test_OptEncoder<TT> : IEncoder<Itest_OptObject<TT>>
{
  public IGqlpValue Encode(Itest_OptObject<TT> input)
    => new GqlpUnit();
}

internal class test_ListEncoder<TT> : IEncoder<Itest_ListObject<TT>>
{
  public IGqlpValue Encode(Itest_ListObject<TT> input)
    => new GqlpUnit();
}

internal class test_DictEncoder<TK,TT> : IEncoder<Itest_DictObject<TK,TT>>
{
  public IGqlpValue Encode(Itest_DictObject<TK,TT> input)
    => new GqlpUnit();
}

internal class test_MapEncoder<TT> : IEncoder<Itest_MapObject<TT>>
{
  public IGqlpValue Encode(Itest_MapObject<TT> input)
    => new GqlpUnit();
}

internal class test_ArrayEncoder<TT> : IEncoder<Itest_ArrayObject<TT>>
{
  public IGqlpValue Encode(Itest_ArrayObject<TT> input)
    => new GqlpUnit();
}

internal class test_IfElseEncoder<TT> : IEncoder<Itest_IfElseObject<TT>>
{
  public IGqlpValue Encode(Itest_IfElseObject<TT> input)
    => new GqlpUnit();
}

internal class test_SetEncoder<TK> : IEncoder<Itest_SetObject<TK>>
{
  public IGqlpValue Encode(Itest_SetObject<TK> input)
    => new GqlpUnit();
}

internal class test_MaskEncoder<TK> : IEncoder<Itest_MaskObject<TK>>
{
  public IGqlpValue Encode(Itest_MaskObject<TK> input)
    => new GqlpUnit();
}

internal class test_KeyEncoder : IEncoder<Itest_Key>
{
  public IGqlpValue Encode(Itest_Key input)
    => new GqlpUnit();

  internal static test_KeyEncoder Factory(IEncoderRepository _) => new();
}

internal class objectEncoder : IEncoder<objectObject>
{
  public IGqlpValue Encode(objectObject input)
    => new GqlpUnit();

  internal static objectEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_SchemaEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_SchemaEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<Itest_Key>(test_KeyEncoder.Factory)
      .AddEncoder<objectObject>(objectEncoder.Factory);
}
