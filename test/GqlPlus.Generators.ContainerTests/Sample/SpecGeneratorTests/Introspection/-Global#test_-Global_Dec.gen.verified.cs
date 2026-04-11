//HintName: test_-Global_Dec.gen.cs
// Generated from {CurrentDirectory}-Global.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Global;

internal class test_AndTypeDecoder
{
  public Itest_Type Type { get; set; }
}

internal class test_CategoriesDecoder
{
  public Itest_Category Category { get; set; }
}

internal class test_CategoryDecoder
{
  public test_Resolution Resolution { get; set; }
  public Itest_TypeRef<Itest_TypeKind> Output { get; set; }
  public ICollection<Itest_Modifiers> Modifiers { get; set; }
}

internal class test_ResolutionDecoder
{
  public string Parallel { get; set; }
  public string Sequential { get; set; }
  public string Single { get; set; }
}

internal class test_DirectivesDecoder
{
  public Itest_Directive Directive { get; set; }
}

internal class test_DirectiveDecoder
{
  public Itest_InputFieldType? Parameter { get; set; }
  public bool Repeatable { get; set; }
  public IDictionary<test_Location, GqlpUnit> Locations { get; set; }
}

internal class test_LocationDecoder
{
  public string Operation { get; set; }
  public string Variable { get; set; }
  public string Field { get; set; }
  public string Inline { get; set; }
  public string Spread { get; set; }
  public string Fragment { get; set; }
}

internal class test_OperationsDecoder
{
  public Itest_Operation Operation { get; set; }
  public Itest_Type Type { get; set; }
}

internal class test_OpDirectivesDecoder
{
  public ICollection<Itest_OpDirective> Directives { get; set; }
}

internal class test_OperationDecoder
{
  public Itest_Name Category { get; set; }
  public IDictionary<Itest_Name, Itest_OpVariable> Variables { get; set; }
  public ICollection<Itest_OpDirective> Directives { get; set; }
  public IDictionary<Itest_Name, Itest_OpFragment> Fragments { get; set; }
  public Itest_OpResult Result { get; set; }
  public IDictionary<Itest_Path, ICollection<Itest_OpSelection>> Selections { get; set; }
}

internal class test_OpVariableDecoder
{
  public Itest_TypeRef<Itest_TypeKind> Type { get; set; }
  public ICollection<Itest_Modifiers> Modifiers { get; set; }
  public GqlpValue? DefaultValue { get; set; }
}

internal class test_OpDirectiveDecoder
{
  public Itest_OpArgument? Argument { get; set; }
}

internal class test_OpFragmentDecoder
{
  public Itest_TypeRef<Itest_TypeKind> Type { get; set; }
}

internal class test_OpArgumentDecoder
{
}

internal class test_OpArgValueDecoder
{
  public Itest_Name Variable { get; set; }
}

internal class test_OpArgListDecoder
{
}

internal class test_OpArgMapDecoder
{
  public Itest_OpArgValue Value { get; set; }
  public Itest_Name ByVariable { get; set; }
}

internal class test_OpResultDecoder
{
  public Itest_OpArgument? Argument { get; set; }
}

internal class test_PathDecoder
{
}

internal class test_OpSelectionDecoder
{
}

internal class test_OpFieldDecoder
{
  public string? FieldAlias { get; set; }
  public Itest_OpArgument? Argument { get; set; }
  public ICollection<Itest_Modifiers> Modifiers { get; set; }
}

internal class test_OpInlineDecoder
{
  public Itest_TypeRef<Itest_TypeKind>? Type { get; set; }
  public ICollection<Itest_OpDirective> Directives { get; set; }
}

internal class test_OpSpreadDecoder
{
  public string Fragment { get; set; }
  public ICollection<Itest_OpDirective> Directives { get; set; }
}

internal class test_SettingDecoder
{
  public GqlpValue Value { get; set; }
}
