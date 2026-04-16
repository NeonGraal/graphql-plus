//HintName: test_Schema_Dec.gen.cs
// Generated from {CurrentDirectory}Schema.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Schema;

internal class test_OptDecoder<TT>
{
}

internal class test_ListDecoder<TT>
{
}

internal class test_DictDecoder<TK,TT>
{
}

internal class test_MapDecoder<TT>
{
}

internal class test_ArrayDecoder<TT>
{
}

internal class test_IfElseDecoder<TT>
{
}

internal class test_SetDecoder<TK>
{
}

internal class test_MaskDecoder<TK>
{
}

internal class test_KeyDecoder
{

  internal static test_KeyDecoder Factory(IDecoderRepository _) => new();
}

internal class test_AnyDecoder
{

  internal static test_AnyDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_SchemaDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_SchemaDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<Itest_Key>(test_KeyDecoder.Factory)
      .AddDecoder<Itest_AnyObject>(test_AnyDecoder.Factory);
}
