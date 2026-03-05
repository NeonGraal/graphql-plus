//HintName: test_Result_Model.gen.cs
// Generated from {CurrentDirectory}Result.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Result;

public class test_OpResult
  : GqlpModelImplementationBase
  , Itest_OpResult
{
  public Itest_OpResultObject? As__OpResult { get; set; }
}

public class test_OpResultObject
  : GqlpModelImplementationBase
  , Itest_OpResultObject
{
  public Itest_Identifier? Domain { get; set; }
  public Itest_OpArgument? Argument { get; set; }
  public ICollection<Itest_OpObject> Body { get; set; }

  public test_OpResultObject
    ( ICollection<Itest_OpObject> body
    )
  {
    Body = body;
  }
}

public class test_OpObject
  : GqlpModelImplementationBase
  , Itest_OpObject
{
  public Itest_OpField? As_OpField { get; set; }
  public Itest_OpSpread? As_OpSpread { get; set; }
  public Itest_OpInline? As_OpInline { get; set; }
  public Itest_OpObjectObject? As__OpObject { get; set; }
}

public class test_OpObjectObject
  : GqlpModelImplementationBase
  , Itest_OpObjectObject
{

  public test_OpObjectObject
    ()
  {
  }
}

public class test_OpField
  : GqlpModelImplementationBase
  , Itest_OpField
{
  public Itest_OpFieldObject? As__OpField { get; set; }
}

public class test_OpFieldObject
  : GqlpModelImplementationBase
  , Itest_OpFieldObject
{
  public Itest_Identifier? Alias { get; set; }
  public Itest_Identifier Field { get; set; }
  public Itest_OpArgument? Argument { get; set; }
  public ICollection<Itest_Modifier> Modifiers { get; set; }
  public ICollection<Itest_OpDirective> Directives { get; set; }
  public string Body { get; set; }

  public test_OpFieldObject
    ( Itest_Identifier field
    , ICollection<Itest_Modifier> modifiers
    , ICollection<Itest_OpDirective> directives
    , string body
    )
  {
    Field = field;
    Modifiers = modifiers;
    Directives = directives;
    Body = body;
  }
}

public class test_OpInline
  : GqlpModelImplementationBase
  , Itest_OpInline
{
  public Itest_OpInlineObject? As__OpInline { get; set; }
}

public class test_OpInlineObject
  : GqlpModelImplementationBase
  , Itest_OpInlineObject
{
  public Itest_Identifier? Type { get; set; }
  public ICollection<Itest_OpDirective> Directives { get; set; }
  public string Body { get; set; }

  public test_OpInlineObject
    ( ICollection<Itest_OpDirective> directives
    , string body
    )
  {
    Directives = directives;
    Body = body;
  }
}

public class test_OpSpread
  : GqlpModelImplementationBase
  , Itest_OpSpread
{
  public Itest_OpSpreadObject? As__OpSpread { get; set; }
}

public class test_OpSpreadObject
  : GqlpModelImplementationBase
  , Itest_OpSpreadObject
{
  public Itest_Identifier Fragment { get; set; }
  public ICollection<Itest_OpDirective> Directives { get; set; }

  public test_OpSpreadObject
    ( Itest_Identifier fragment
    , ICollection<Itest_OpDirective> directives
    )
  {
    Fragment = fragment;
    Directives = directives;
  }
}
