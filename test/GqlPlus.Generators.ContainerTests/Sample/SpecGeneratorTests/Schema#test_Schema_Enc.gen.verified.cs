//HintName: test_Schema_Enc.gen.cs
// Generated from {CurrentDirectory}Schema.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Schema;

internal class test_OptEncoder<TT> : IEncoder<Itest_OptObject<TT>>
{
  public Structured Encode(Itest_OptObject<TT> input)
    => Structured.Empty();
}

internal class test_ListEncoder<TT> : IEncoder<Itest_ListObject<TT>>
{
  public Structured Encode(Itest_ListObject<TT> input)
    => Structured.Empty();
}

internal class test_DictEncoder<TK,TT> : IEncoder<Itest_DictObject<TK,TT>>
{
  public Structured Encode(Itest_DictObject<TK,TT> input)
    => Structured.Empty();
}

internal class test_MapEncoder<TT> : IEncoder<Itest_MapObject<TT>>
{
  public Structured Encode(Itest_MapObject<TT> input)
    => Structured.Empty();
}

internal class test_ArrayEncoder<TT> : IEncoder<Itest_ArrayObject<TT>>
{
  public Structured Encode(Itest_ArrayObject<TT> input)
    => Structured.Empty();
}

internal class test_IfElseEncoder<TT> : IEncoder<Itest_IfElseObject<TT>>
{
  public Structured Encode(Itest_IfElseObject<TT> input)
    => Structured.Empty();
}

internal class test_SetEncoder<TK> : IEncoder<Itest_SetObject<TK>>
{
  public Structured Encode(Itest_SetObject<TK> input)
    => Structured.Empty();
}

internal class test_MaskEncoder<TK> : IEncoder<Itest_MaskObject<TK>>
{
  public Structured Encode(Itest_MaskObject<TK> input)
    => Structured.Empty();
}

internal class test_KeyEncoder : IEncoder<Itest_Key>
{
  public Structured Encode(Itest_Key input)
    => Structured.Empty();
}

internal class test_AnyEncoder : IEncoder<Itest_AnyObject>
{
  public Structured Encode(Itest_AnyObject input)
    => Structured.Empty();
}
