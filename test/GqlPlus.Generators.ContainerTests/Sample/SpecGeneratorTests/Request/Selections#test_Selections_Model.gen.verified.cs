//HintName: test_Selections_Model.gen.cs
// Generated from {CurrentDirectory}Selections.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Selections;

public class test_OpSelection
  : GqlpModelBase
  , Itest_OpSelection
{
  public Itest_OpField? As_OpField { get; set; }
  public Itest_OpSpread? As_OpSpread { get; set; }
  public Itest_OpInline? As_OpInline { get; set; }
  public Itest_OpSelectionObject? As__OpSelection { get; set; }
}

public class test_OpSelectionObject
  : GqlpModelBase
  , Itest_OpSelectionObject
{

  public test_OpSelectionObject
    ()
  {
  }
}

public class test_OpField
  : test_OpDirectives
  , Itest_OpField
{
  public Itest_OpFieldObject? As__OpField { get; set; }
}

public class test_OpFieldObject
  : test_OpDirectivesObject
  , Itest_OpFieldObject
{
  public Itest_Identifier? FieldAlias { get; set; }
  public Itest_OpArgument? Argument { get; set; }
  public ICollection<Itest_Modifiers> Modifiers { get; set; }

  public test_OpFieldObject
    ( ICollection<Itest_Modifiers> pmodifiers
    )
  {
    Modifiers = pmodifiers;
  }
}

public class test_OpInline
  : GqlpModelBase
  , Itest_OpInline
{
  public Itest_OpInlineObject? As__OpInline { get; set; }
}

public class test_OpInlineObject
  : GqlpModelBase
  , Itest_OpInlineObject
{
  public Itest_Identifier? Type { get; set; }
  public ICollection<Itest_OpDirective> Directives { get; set; }

  public test_OpInlineObject
    ( ICollection<Itest_OpDirective> pdirectives
    )
  {
    Directives = pdirectives;
  }
}

public class test_OpSpread
  : GqlpModelBase
  , Itest_OpSpread
{
  public Itest_OpSpreadObject? As__OpSpread { get; set; }
}

public class test_OpSpreadObject
  : GqlpModelBase
  , Itest_OpSpreadObject
{
  public Itest_Identifier Fragment { get; set; }
  public ICollection<Itest_OpDirective> Directives { get; set; }

  public test_OpSpreadObject
    ( Itest_Identifier pfragment
    , ICollection<Itest_OpDirective> pdirectives
    )
  {
    Fragment = pfragment;
    Directives = pdirectives;
  }
}
