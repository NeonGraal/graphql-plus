//HintName: test_Common_Enc.gen.cs
// Generated from {CurrentDirectory}Common.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Common;

internal class test_TypeEncoder : IEncoder<Itest_TypeObject>
{
  public Structured Encode(Itest_TypeObject input)
    => Structured.Empty();
}

internal class test_BaseTypeEncoder<TTypeKind>(
  IEncoderRepository encoders
) : IEncoder<Itest_BaseTypeObject<TTypeKind>>
{
  private readonly IEncoder<Itest_AliasedObject> _itest_Aliased = encoders.EncoderFor<Itest_AliasedObject>();
  private readonly IEncoder<TTypeKind> _typeKind = encoders.EncoderFor<TTypeKind>();
  public Structured Encode(Itest_BaseTypeObject<TTypeKind> input)
    => _itest_Aliased.Encode(input)
      .AddEncoded("typeKind", input.TypeKind, _typeKind);
}

internal class test_ChildTypeEncoder<TTypeKind,TParent>(
  IEncoderRepository encoders
) : IEncoder<Itest_ChildTypeObject<TTypeKind,TParent>>
{
  private readonly IEncoder<Itest_BaseTypeObject<TTypeKind>> _itest_BaseType = encoders.EncoderFor<Itest_BaseTypeObject<TTypeKind>>();
  private readonly IEncoder<TParent> _parent = encoders.EncoderFor<TParent>();
  public Structured Encode(Itest_ChildTypeObject<TTypeKind,TParent> input)
    => _itest_BaseType.Encode(input)
      .AddEncoded("parent", input.Parent, _parent);
}

internal class test_ParentTypeEncoder<TTypeKind,TItem,TAllItem>(
  IEncoderRepository encoders
) : IEncoder<Itest_ParentTypeObject<TTypeKind,TItem,TAllItem>>
{
  private readonly IEncoder<Itest_ChildTypeObject<TTypeKind, Itest_Named>> _itest_ChildType = encoders.EncoderFor<Itest_ChildTypeObject<TTypeKind, Itest_Named>>();
  private readonly IEncoder<TItem> _item = encoders.EncoderFor<TItem>();
  private readonly IEncoder<TAllItem> _allItem = encoders.EncoderFor<TAllItem>();
  public Structured Encode(Itest_ParentTypeObject<TTypeKind,TItem,TAllItem> input)
    => _itest_ChildType.Encode(input)
      .AddList("items", input.Items, _item)
      .AddList("allItems", input.AllItems, _allItem);
}

internal class test_SimpleKindEncoder : IEncoder<test_SimpleKind>
{
  public Structured Encode(test_SimpleKind input)
    => new(input.ToString(), "_SimpleKind");
}

internal class test_TypeKindEncoder : IEncoder<test_TypeKind>
{
  public Structured Encode(test_TypeKind input)
    => new(input.ToString(), "_TypeKind");
}

internal class test_TypeRefEncoder<TTypeKind>(
  IEncoderRepository encoders
) : IEncoder<Itest_TypeRefObject<TTypeKind>>
{
  private readonly IEncoder<Itest_NamedObject> _itest_Named = encoders.EncoderFor<Itest_NamedObject>();
  private readonly IEncoder<TTypeKind> _typeKind = encoders.EncoderFor<TTypeKind>();
  public Structured Encode(Itest_TypeRefObject<TTypeKind> input)
    => _itest_Named.Encode(input)
      .AddEncoded("typeKind", input.TypeKind, _typeKind);
}

internal class test_TypeSimpleEncoder : IEncoder<Itest_TypeSimpleObject>
{
  public Structured Encode(Itest_TypeSimpleObject input)
    => Structured.Empty();
}

internal static class test_CommonEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_CommonEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<Itest_TypeObject>(_ => new test_TypeEncoder())
      .AddEncoder<test_SimpleKind>(_ => new test_SimpleKindEncoder())
      .AddEncoder<test_TypeKind>(_ => new test_TypeKindEncoder())
      .AddEncoder<Itest_TypeSimpleObject>(_ => new test_TypeSimpleEncoder());
}
