//HintName: test_-Request_Dec.gen.cs
// Generated from {CurrentDirectory}-Request.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Request;

internal class test_RequestDecoder
{
  public Itest_Identifier? Category { get; set; }
  public Itest_Identifier? Operation { get; set; }
  public Itest_Operation Definition { get; set; }
  public Itest_Any? Parameters { get; set; }
}

internal class test_IdentifierDecoder
{
}

internal class test_OperationDecoder
{
  public ICollection<Itest_OpVariable> Variables { get; set; }
  public ICollection<Itest_OpDirective> Directives { get; set; }
  public ICollection<Itest_OpFragment> Fragments { get; set; }
  public Itest_OpResult Result { get; set; }
}

internal class test_OpVariableDecoder
{
  public Itest_Identifier Name { get; set; }
  public Itest_Identifier? Type { get; set; }
  public ICollection<Itest_Modifier> Modifiers { get; set; }
  public GqlpValue? Default { get; set; }
  public ICollection<Itest_OpDirective> Directives { get; set; }
}

internal class test_OpDirectiveDecoder
{
  public Itest_Identifier Name { get; set; }
  public Itest_OpArgument? Argument { get; set; }
}

internal class test_OpFragmentDecoder
{
  public Itest_Identifier Name { get; set; }
  public Itest_Identifier? Type { get; set; }
  public ICollection<Itest_OpDirective> Directives { get; set; }
  public ICollection<Itest_OpObject> Body { get; set; }
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
}

internal class test_ModifierDecoder
{
  public test_ModifierKind ModifierKind { get; set; }
  public Itest_Identifier? By { get; set; }
  public bool? Optional { get; set; }
}

internal class test_OpArgumentDecoder
{
}

internal class test_OpArgValueDecoder
{
  public Itest_Identifier Variable { get; set; }
}

internal class test_OpArgListDecoder
{
}

internal class test_OpArgMapDecoder
{
  public Itest_OpArgValue Value { get; set; }
  public Itest_Identifier ByVariable { get; set; }
}

internal class test_OpResultDecoder
{
  public Itest_Identifier? Domain { get; set; }
  public Itest_OpArgument? Argument { get; set; }
  public ICollection<Itest_OpObject> Body { get; set; }
}

internal class test_OpObjectDecoder
{
}

internal class test_OpFieldDecoder
{
  public Itest_Identifier? Alias { get; set; }
  public Itest_Identifier Field { get; set; }
  public Itest_OpArgument? Argument { get; set; }
  public ICollection<Itest_Modifier> Modifiers { get; set; }
  public ICollection<Itest_OpDirective> Directives { get; set; }
  public string Body { get; set; }
}

internal class test_OpInlineDecoder
{
  public Itest_Identifier? Type { get; set; }
  public ICollection<Itest_OpDirective> Directives { get; set; }
  public string Body { get; set; }
}

internal class test_OpSpreadDecoder
{
  public Itest_Identifier Fragment { get; set; }
  public ICollection<Itest_OpDirective> Directives { get; set; }
}

internal static class test__RequestDecoders
{
  internal static IDecoderRepositoryBuilder Addtest__RequestDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<Itest_RequestObject>(_ => new test_RequestDecoder())
      .AddDecoder<Itest_Identifier>(_ => new test_IdentifierDecoder())
      .AddDecoder<Itest_OperationObject>(_ => new test_OperationDecoder())
      .AddDecoder<Itest_OpVariableObject>(_ => new test_OpVariableDecoder())
      .AddDecoder<Itest_OpDirectiveObject>(_ => new test_OpDirectiveDecoder())
      .AddDecoder<Itest_OpFragmentObject>(_ => new test_OpFragmentDecoder())
      .AddDecoder<test_ModifierKind>(_ => new test_ModifierKindDecoder())
      .AddDecoder<Itest_ModifierObject>(_ => new test_ModifierDecoder())
      .AddDecoder<Itest_OpArgumentObject>(_ => new test_OpArgumentDecoder())
      .AddDecoder<Itest_OpArgValueObject>(_ => new test_OpArgValueDecoder())
      .AddDecoder<Itest_OpArgListObject>(_ => new test_OpArgListDecoder())
      .AddDecoder<Itest_OpArgMapObject>(_ => new test_OpArgMapDecoder())
      .AddDecoder<Itest_OpResultObject>(_ => new test_OpResultDecoder())
      .AddDecoder<Itest_OpObjectObject>(_ => new test_OpObjectDecoder())
      .AddDecoder<Itest_OpFieldObject>(_ => new test_OpFieldDecoder())
      .AddDecoder<Itest_OpInlineObject>(_ => new test_OpInlineDecoder())
      .AddDecoder<Itest_OpSpreadObject>(_ => new test_OpSpreadDecoder());
}
