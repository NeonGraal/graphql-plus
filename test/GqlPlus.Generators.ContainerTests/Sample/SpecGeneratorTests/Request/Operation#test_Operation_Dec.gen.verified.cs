//HintName: test_Operation_Dec.gen.cs
// Generated from {CurrentDirectory}Operation.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Operation;

internal class test_OperationDecoder
{
  public ICollection<Itest_OpVariable> Variables { get; set; }
  public ICollection<Itest_OpDirective> Directives { get; set; }
  public ICollection<Itest_OpFragment> Fragments { get; set; }
  public Itest_OpResult Result { get; set; }

  internal static test_OperationDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpVariableDecoder
{
  public Itest_Identifier Name { get; set; }
  public Itest_Identifier? Type { get; set; }
  public ICollection<Itest_Modifier> Modifiers { get; set; }
  public GqlpValue? Default { get; set; }
  public ICollection<Itest_OpDirective> Directives { get; set; }

  internal static test_OpVariableDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpDirectiveDecoder
{
  public Itest_Identifier Name { get; set; }
  public Itest_OpArgument? Argument { get; set; }

  internal static test_OpDirectiveDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpFragmentDecoder
{
  public Itest_Identifier Name { get; set; }
  public Itest_Identifier? Type { get; set; }
  public ICollection<Itest_OpDirective> Directives { get; set; }
  public ICollection<Itest_OpObject> Body { get; set; }

  internal static test_OpFragmentDecoder Factory(IDecoderRepository _) => new();
}

internal class test_ModifierKindDecoder
{
  public string Opt { get; set; }
  public string Optional { get; set; }
  public string List { get; set; }
  public string Dict { get; set; }
  public string Dictionary { get; set; }
  public string Param { get; set; }
  public string TypeParam { get; set; }

  internal static test_ModifierKindDecoder Factory(IDecoderRepository _) => new();
}

internal class test_ModifierDecoder
{
  public test_ModifierKind ModifierKind { get; set; }
  public Itest_Identifier? By { get; set; }
  public bool? Optional { get; set; }

  internal static test_ModifierDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpArgumentDecoder
{

  internal static test_OpArgumentDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpArgValueDecoder
{
  public Itest_Identifier Variable { get; set; }

  internal static test_OpArgValueDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpArgListDecoder
{

  internal static test_OpArgListDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpArgMapDecoder
{
  public Itest_OpArgValue Value { get; set; }
  public Itest_Identifier ByVariable { get; set; }

  internal static test_OpArgMapDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_OperationDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_OperationDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<Itest_OperationObject>(test_OperationDecoder.Factory)
      .AddDecoder<Itest_OpVariableObject>(test_OpVariableDecoder.Factory)
      .AddDecoder<Itest_OpDirectiveObject>(test_OpDirectiveDecoder.Factory)
      .AddDecoder<Itest_OpFragmentObject>(test_OpFragmentDecoder.Factory)
      .AddDecoder<test_ModifierKind>(test_ModifierKindDecoder.Factory)
      .AddDecoder<Itest_ModifierObject>(test_ModifierDecoder.Factory)
      .AddDecoder<Itest_OpArgumentObject>(test_OpArgumentDecoder.Factory)
      .AddDecoder<Itest_OpArgValueObject>(test_OpArgValueDecoder.Factory)
      .AddDecoder<Itest_OpArgListObject>(test_OpArgListDecoder.Factory)
      .AddDecoder<Itest_OpArgMapObject>(test_OpArgMapDecoder.Factory);
}
