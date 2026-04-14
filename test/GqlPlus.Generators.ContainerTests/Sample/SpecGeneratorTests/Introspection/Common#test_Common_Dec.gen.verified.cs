//HintName: test_Common_Dec.gen.cs
// Generated from {CurrentDirectory}Common.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Common;

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

internal static class test_CommonDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_CommonDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<Itest_TypeObject>(_ => new test_TypeDecoder())
      .AddDecoder<test_SimpleKind>(_ => new test_SimpleKindDecoder())
      .AddDecoder<test_TypeKind>(_ => new test_TypeKindDecoder())
      .AddDecoder<Itest_TypeSimpleObject>(_ => new test_TypeSimpleDecoder());
}
