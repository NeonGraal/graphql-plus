//HintName: test_Result_Model.gen.cs
// Generated from {CurrentDirectory}Result.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Result;

public class test_OpResult
  : GqlpModelBase
  , Itest_OpResult
{
  public Itest_OpResultObject? As__OpResult { get; set; }
}

public class test_OpResultObject
  : GqlpModelBase
  , Itest_OpResultObject
{
  public Itest_Identifier? Domain { get; set; }
  public Itest_OpArgument? Argument { get; set; }
  public ICollection<Itest_OpObject> Body { get; set; }

  public test_OpResultObject
    ( ICollection<Itest_OpObject> pbody
    )
  {
    Body = pbody;
  }
}

public class test_OpObject
  : GqlpModelBase
  , Itest_OpObject
{
  public Itest_OpField? As_OpField { get; set; }
  public Itest_OpSpread? As_OpSpread { get; set; }
  public Itest_OpInline? As_OpInline { get; set; }
  public Itest_OpObjectObject? As__OpObject { get; set; }
}

public class test_OpObjectObject
  : GqlpModelBase
  , Itest_OpObjectObject
{

  public test_OpObjectObject
    ()
  {
  }
}

public class test_OpField
  : GqlpModelBase
  , Itest_OpField
{
  public Itest_OpFieldObject? As__OpField { get; set; }
}

public class test_OpFieldObject
  : GqlpModelBase
  , Itest_OpFieldObject
{
  public Itest_Identifier? Alias { get; set; }
  public Itest_Identifier Field { get; set; }
  public Itest_OpArgument? Argument { get; set; }
  public ICollection<Itest_Modifier> Modifiers { get; set; }
  public ICollection<Itest_OpDirective> Directives { get; set; }
  public string Body { get; set; }

  public test_OpFieldObject
    ( Itest_Identifier pfield
    , ICollection<Itest_Modifier> pmodifiers
    , ICollection<Itest_OpDirective> pdirectives
    , string pbody
    )
  {
    Field = pfield;
    Modifiers = pmodifiers;
    Directives = pdirectives;
    Body = pbody;
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
  public string Body { get; set; }

  public test_OpInlineObject
    ( ICollection<Itest_OpDirective> pdirectives
    , string pbody
    )
  {
    Directives = pdirectives;
    Body = pbody;
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
