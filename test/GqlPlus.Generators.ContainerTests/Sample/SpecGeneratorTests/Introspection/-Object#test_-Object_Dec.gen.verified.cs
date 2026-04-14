//HintName: test_-Object_Dec.gen.cs
// Generated from {CurrentDirectory}-Object.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Object;

internal class test_ObjectKindDecoder
{
}

internal class test_TypeObjectDecoder<TObjectKind,TField>
{
  public ICollection<Itest_ObjTypeParam> TypeParams { get; set; }
  public ICollection<TField> Fields { get; set; }
  public ICollection<Itest_ObjAlternate> Alternates { get; set; }
  public ICollection<Itest_ObjectFor<TField>> AllFields { get; set; }
  public ICollection<Itest_ObjectFor<Itest_ObjAlternate>> AllAlternates { get; set; }
}

internal class test_ObjTypeParamDecoder
{
  public Itest_TypeRef<Itest_TypeKind> Constraint { get; set; }
}

internal class test_ObjBaseDecoder
{
  public ICollection<Itest_ObjTypeArg> TypeArgs { get; set; }
}

internal class test_ObjTypeArgDecoder
{
  public Itest_Name? Label { get; set; }
}

internal class test_TypeParamDecoder
{
  public Itest_Name TypeParam { get; set; }
}

internal class test_ObjAlternateDecoder
{
  public Itest_ObjBase Type { get; set; }
  public ICollection<Itest_Collections> Collections { get; set; }
}

internal class test_ObjAlternateEnumDecoder
{
  public Itest_Name Label { get; set; }
}

internal class test_ObjectForDecoder<TFor>
{
  public Itest_Name ObjectType { get; set; }
}

internal class test_ObjFieldDecoder<TType>
{
  public TType Type { get; set; }
}

internal class test_ObjFieldTypeDecoder
{
  public ICollection<Itest_Modifiers> Modifiers { get; set; }
}

internal class test_ObjFieldEnumDecoder
{
  public Itest_Name Label { get; set; }
}

internal class test_ForParamDecoder<TType>
{
}

internal class test_DualFieldDecoder
{
}

internal class test_InputFieldDecoder
{
}

internal class test_InputFieldTypeDecoder
{
  public GqlpValue? DefaultValue { get; set; }
}

internal class test_OutputFieldDecoder
{
}

internal class test_OutputFieldTypeDecoder
{
  public Itest_InputFieldType? Parameter { get; set; }
}

internal static class test__ObjectDecoders
{
  internal static IDecoderRepositoryBuilder Addtest__ObjectDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<Itest_ObjectKind>(_ => new test_ObjectKindDecoder())
      .AddDecoder<Itest_ObjTypeParamObject>(r => new test_ObjTypeParamDecoder(r))
      .AddDecoder<Itest_ObjBaseObject>(r => new test_ObjBaseDecoder(r))
      .AddDecoder<Itest_ObjTypeArgObject>(r => new test_ObjTypeArgDecoder(r))
      .AddDecoder<Itest_TypeParamObject>(r => new test_TypeParamDecoder(r))
      .AddDecoder<Itest_ObjAlternateObject>(r => new test_ObjAlternateDecoder(r))
      .AddDecoder<Itest_ObjAlternateEnumObject>(r => new test_ObjAlternateEnumDecoder(r))
      .AddDecoder<Itest_ObjFieldTypeObject>(r => new test_ObjFieldTypeDecoder(r))
      .AddDecoder<Itest_ObjFieldEnumObject>(r => new test_ObjFieldEnumDecoder(r))
      .AddDecoder<Itest_DualFieldObject>(_ => new test_DualFieldDecoder())
      .AddDecoder<Itest_InputFieldObject>(_ => new test_InputFieldDecoder())
      .AddDecoder<Itest_InputFieldTypeObject>(r => new test_InputFieldTypeDecoder(r))
      .AddDecoder<Itest_OutputFieldObject>(_ => new test_OutputFieldDecoder())
      .AddDecoder<Itest_OutputFieldTypeObject>(r => new test_OutputFieldTypeDecoder(r));
}
