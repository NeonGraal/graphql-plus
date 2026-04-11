//HintName: test_Operation_Enc.gen.cs
// Generated from {CurrentDirectory}Operation.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Operation;

internal class test_OperationsEncoder
{
  public Itest_Operation Operation { get; set; }
  public Itest_Type Type { get; set; }
}

internal class test_OpDirectivesEncoder
{
  public ICollection<Itest_OpDirective> Directives { get; set; }
}

internal class test_OperationEncoder
{
  public Itest_Name Category { get; set; }
  public IDictionary<Itest_Name, Itest_OpVariable> Variables { get; set; }
  public ICollection<Itest_OpDirective> Directives { get; set; }
  public IDictionary<Itest_Name, Itest_OpFragment> Fragments { get; set; }
  public Itest_OpResult Result { get; set; }
  public IDictionary<Itest_Path, ICollection<Itest_OpSelection>> Selections { get; set; }
}

internal class test_OpVariableEncoder
{
  public Itest_TypeRef<Itest_TypeKind> Type { get; set; }
  public ICollection<Itest_Modifiers> Modifiers { get; set; }
  public GqlpValue? DefaultValue { get; set; }
}

internal class test_OpDirectiveEncoder
{
  public Itest_OpArgument? Argument { get; set; }
}

internal class test_OpFragmentEncoder
{
  public Itest_TypeRef<Itest_TypeKind> Type { get; set; }
}

internal class test_OpArgumentEncoder
{
}

internal class test_OpArgValueEncoder
{
  public Itest_Name Variable { get; set; }
}

internal class test_OpArgListEncoder
{
}

internal class test_OpArgMapEncoder
{
  public Itest_OpArgValue Value { get; set; }
  public Itest_Name ByVariable { get; set; }
}

internal class test_OpResultEncoder
{
  public Itest_OpArgument? Argument { get; set; }
}

internal class test_PathEncoder
{
}

internal class test_OpSelectionEncoder
{
}

internal class test_OpFieldEncoder
{
  public string? FieldAlias { get; set; }
  public Itest_OpArgument? Argument { get; set; }
  public ICollection<Itest_Modifiers> Modifiers { get; set; }
}

internal class test_OpInlineEncoder
{
  public Itest_TypeRef<Itest_TypeKind>? Type { get; set; }
  public ICollection<Itest_OpDirective> Directives { get; set; }
}

internal class test_OpSpreadEncoder
{
  public string Fragment { get; set; }
  public ICollection<Itest_OpDirective> Directives { get; set; }
}
