//HintName: test_-Type_Dec.gen.cs
// Generated from {CurrentDirectory}-Type.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Type;

internal class test_TypeDecoder
{
}

internal class test_BaseTypeDecoder<TTypeKind>
{
  public TTypeKind TypeKind { get; set; }
}

internal class test_ChildTypeDecoder<TTypeKind,TParent>
{
  public TParent Parent { get; set; }
}

internal class test_ParentTypeDecoder<TTypeKind,TItem,TAllItem>
{
  public ICollection<TItem> Items { get; set; }
  public ICollection<TAllItem> AllItems { get; set; }
}

internal class test_SimpleKindDecoder
{
  public string Basic { get; set; }
  public string Enum { get; set; }
  public string Internal { get; set; }
  public string Domain { get; set; }
  public string Union { get; set; }
}

internal class test_TypeKindDecoder
{
  public string Basic { get; set; }
  public string Enum { get; set; }
  public string Internal { get; set; }
  public string Domain { get; set; }
  public string Union { get; set; }
  public string Dual { get; set; }
  public string Input { get; set; }
  public string Output { get; set; }
}

internal class test_TypeRefDecoder<TTypeKind>
{
  public TTypeKind TypeKind { get; set; }
}

internal class test_TypeSimpleDecoder
{
}

internal class test_CollectionsDecoder
{
}

internal class test_ModifierKeyedDecoder<TModifierKind>
{
  public Itest_TypeSimple By { get; set; }
  public bool IsOptional { get; set; }
}

internal class test_ModifiersDecoder
{
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

internal class test_ModifierDecoder<TModifierKind>
{
  public TModifierKind ModifierKind { get; set; }
}

internal static class test__TypeDecoders
{
  internal static IDecoderRepositoryBuilder Addtest__TypeDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<Itest_TypeObject>(_ => new test_TypeDecoder())
      .AddDecoder<test_SimpleKind>(_ => new test_SimpleKindDecoder())
      .AddDecoder<test_TypeKind>(_ => new test_TypeKindDecoder())
      .AddDecoder<Itest_TypeSimpleObject>(_ => new test_TypeSimpleDecoder())
      .AddDecoder<Itest_CollectionsObject>(_ => new test_CollectionsDecoder())
      .AddDecoder<Itest_ModifiersObject>(_ => new test_ModifiersDecoder())
      .AddDecoder<test_ModifierKind>(_ => new test_ModifierKindDecoder());
}
