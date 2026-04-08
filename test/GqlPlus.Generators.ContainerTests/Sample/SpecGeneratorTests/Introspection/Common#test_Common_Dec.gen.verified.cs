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
