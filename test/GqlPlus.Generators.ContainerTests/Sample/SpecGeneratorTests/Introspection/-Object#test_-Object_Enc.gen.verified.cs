//HintName: test_-Object_Enc.gen.cs
// Generated from {CurrentDirectory}-Object.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Object;

internal class test_ObjectKindEncoder
{
}

internal class test_TypeObjectEncoder<TObjectKind,TField>
{
  public ICollection<Itest_ObjTypeParam> TypeParams { get; set; }
  public ICollection<TField> Fields { get; set; }
  public ICollection<Itest_ObjAlternate> Alternates { get; set; }
  public ICollection<Itest_ObjectFor<TField>> AllFields { get; set; }
  public ICollection<Itest_ObjectFor<Itest_ObjAlternate>> AllAlternates { get; set; }
}

internal class test_ObjTypeParamEncoder
{
  public Itest_TypeRef<Itest_TypeKind> Constraint { get; set; }
}

internal class test_ObjBaseEncoder
{
  public ICollection<Itest_ObjTypeArg> TypeArgs { get; set; }
}

internal class test_ObjTypeArgEncoder
{
  public Itest_Name? Label { get; set; }
}

internal class test_TypeParamEncoder
{
  public Itest_Name TypeParam { get; set; }
}

internal class test_ObjAlternateEncoder
{
  public Itest_ObjBase Type { get; set; }
  public ICollection<Itest_Collections> Collections { get; set; }
}

internal class test_ObjAlternateEnumEncoder
{
  public Itest_Name Label { get; set; }
}

internal class test_ObjectForEncoder<TFor>
{
  public Itest_Name ObjectType { get; set; }
}

internal class test_ObjFieldEncoder<TType>
{
  public TType Type { get; set; }
}

internal class test_ObjFieldTypeEncoder
{
  public ICollection<Itest_Modifiers> Modifiers { get; set; }
}

internal class test_ObjFieldEnumEncoder
{
  public Itest_Name Label { get; set; }
}

internal class test_ForParamEncoder<TType>
{
}

internal class test_DualFieldEncoder
{
}

internal class test_InputFieldEncoder
{
}

internal class test_InputFieldTypeEncoder
{
  public GqlpValue? DefaultValue { get; set; }
}

internal class test_OutputFieldEncoder
{
}

internal class test_OutputFieldTypeEncoder
{
  public Itest_InputFieldType? Parameter { get; set; }
}
