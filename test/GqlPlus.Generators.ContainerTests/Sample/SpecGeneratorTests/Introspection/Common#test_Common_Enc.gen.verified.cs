//HintName: test_Common_Enc.gen.cs
// Generated from {CurrentDirectory}Common.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Common;

internal class test_TypeEncoder : IEncoder<Itest_TypeObject>
{
  public Structured Encode(Itest_TypeObject input)
    => Structured.Empty();

  internal static test_TypeEncoder Factory(IEncoderRepository _) => new();
}

internal class test_BaseTypeEncoder<TTypeKind>(
  IEncoderRepository encoders
) : IEncoder<Itest_BaseTypeObject<TTypeKind>>
{
  private readonly DeferOne<IEncoder<Itest_AliasedObject>> _itest_Aliased = encoders.EncoderFor<Itest_AliasedObject>();
  private readonly DeferOne<IEncoder<TTypeKind>> _typeKind = encoders.EncoderFor<TTypeKind>();
  public Structured Encode(Itest_BaseTypeObject<TTypeKind> input)
    => _itest_Aliased.I.Encode(input)
      .AddEncoded("typeKind", input.TypeKind, _typeKind.I);
}

internal class test_ChildTypeEncoder<TTypeKind,TParent>(
  IEncoderRepository encoders
) : IEncoder<Itest_ChildTypeObject<TTypeKind,TParent>>
{
  private readonly DeferOne<IEncoder<Itest_BaseTypeObject<TTypeKind>>> _itest_BaseType = encoders.EncoderFor<Itest_BaseTypeObject<TTypeKind>>();
  private readonly DeferOne<IEncoder<TParent>> _parent = encoders.EncoderFor<TParent>();
  public Structured Encode(Itest_ChildTypeObject<TTypeKind,TParent> input)
    => _itest_BaseType.I.Encode(input)
      .AddEncoded("parent", input.Parent, _parent.I);
}

internal class test_ParentTypeEncoder<TTypeKind,TItem,TAllItem>(
  IEncoderRepository encoders
) : IEncoder<Itest_ParentTypeObject<TTypeKind,TItem,TAllItem>>
{
  private readonly DeferOne<IEncoder<Itest_ChildTypeObject<TTypeKind, Itest_Named>>> _itest_ChildType = encoders.EncoderFor<Itest_ChildTypeObject<TTypeKind, Itest_Named>>();
  private readonly DeferOne<IEncoder<TItem>> _item = encoders.EncoderFor<TItem>();
  private readonly DeferOne<IEncoder<TAllItem>> _allItem = encoders.EncoderFor<TAllItem>();
  public Structured Encode(Itest_ParentTypeObject<TTypeKind,TItem,TAllItem> input)
    => _itest_ChildType.I.Encode(input)
      .AddList("items", input.Items, _item.I)
      .AddList("allItems", input.AllItems, _allItem.I);
}

internal class test_SimpleKindEncoder : IEncoder<test_SimpleKind>
{
  public Structured Encode(test_SimpleKind input)
    => input.EncodeEnum("_SimpleKind");

  internal static test_SimpleKindEncoder Factory(IEncoderRepository _) => new();
}

internal class test_TypeKindEncoder : IEncoder<test_TypeKind>
{
  public Structured Encode(test_TypeKind input)
    => input.EncodeEnum("_TypeKind");

  internal static test_TypeKindEncoder Factory(IEncoderRepository _) => new();
}

internal class test_TypeRefEncoder<TTypeKind>(
  IEncoderRepository encoders
) : IEncoder<Itest_TypeRefObject<TTypeKind>>
{
  private readonly DeferOne<IEncoder<Itest_NamedObject>> _itest_Named = encoders.EncoderFor<Itest_NamedObject>();
  private readonly DeferOne<IEncoder<TTypeKind>> _typeKind = encoders.EncoderFor<TTypeKind>();
  public Structured Encode(Itest_TypeRefObject<TTypeKind> input)
    => _itest_Named.I.Encode(input)
      .AddEncoded("typeKind", input.TypeKind, _typeKind.I);
}

internal class test_TypeSimpleEncoder : IEncoder<Itest_TypeSimpleObject>
{
  public Structured Encode(Itest_TypeSimpleObject input)
    => Structured.Empty();

  internal static test_TypeSimpleEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_CommonEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_CommonEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<Itest_TypeObject>(test_TypeEncoder.Factory)
      .AddEncoder<test_SimpleKind>(test_SimpleKindEncoder.Factory)
      .AddEncoder<test_TypeKind>(test_TypeKindEncoder.Factory)
      .AddEncoder<Itest_TypeSimpleObject>(test_TypeSimpleEncoder.Factory);
}
