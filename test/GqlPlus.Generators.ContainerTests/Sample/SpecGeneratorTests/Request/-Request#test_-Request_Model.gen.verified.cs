//HintName: test_-Request_Model.gen.cs
// Generated from {CurrentDirectory}-Request.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Request;

public class test_Request
  : GqlpModelBase
  , Itest_Request
{
  public string? AsString { get; set; }
  public Itest_RequestObject? As__Request { get; set; }
}

public class test_RequestObject
  : GqlpModelBase
  , Itest_RequestObject
{
  public Itest_Identifier? Category { get; set; }
  public Itest_Identifier? Operation { get; set; }
  public Itest_Operation Definition { get; set; }
  public Itest_Any? Parameters { get; set; }

  public test_RequestObject
    ( Itest_Operation definition
    )
  {
    Definition = definition;
  }
}

public class test_Identifier
  : GqlpDomainString
  , Itest_Identifier
{
}

public class test_Operation
  : GqlpModelBase
  , Itest_Operation
{
  public string? AsString { get; set; }
  public Itest_OperationObject? As__Operation { get; set; }
}

public class test_OperationObject
  : GqlpModelBase
  , Itest_OperationObject
{
  public ICollection<Itest_OpVariable> Variables { get; set; }
  public ICollection<Itest_OpDirective> Directives { get; set; }
  public ICollection<Itest_OpFragment> Fragments { get; set; }
  public Itest_OpResult Result { get; set; }

  public test_OperationObject
    ( ICollection<Itest_OpVariable> variables
    , ICollection<Itest_OpDirective> directives
    , ICollection<Itest_OpFragment> fragments
    , Itest_OpResult result
    )
  {
    Variables = variables;
    Directives = directives;
    Fragments = fragments;
    Result = result;
  }
}

public class test_OpVariable
  : GqlpModelBase
  , Itest_OpVariable
{
  public Itest_OpVariableObject? As__OpVariable { get; set; }
}

public class test_OpVariableObject
  : GqlpModelBase
  , Itest_OpVariableObject
{
  public Itest_Identifier Name { get; set; }
  public Itest_Identifier? Type { get; set; }
  public ICollection<Itest_Modifier> Modifiers { get; set; }
  public GqlpValue? Default { get; set; }
  public ICollection<Itest_OpDirective> Directives { get; set; }

  public test_OpVariableObject
    ( Itest_Identifier name
    , ICollection<Itest_Modifier> modifiers
    , ICollection<Itest_OpDirective> directives
    )
  {
    Name = name;
    Modifiers = modifiers;
    Directives = directives;
  }
}

public class test_OpDirective
  : GqlpModelBase
  , Itest_OpDirective
{
  public Itest_OpDirectiveObject? As__OpDirective { get; set; }
}

public class test_OpDirectiveObject
  : GqlpModelBase
  , Itest_OpDirectiveObject
{
  public Itest_Identifier Name { get; set; }
  public Itest_OpArgument? Argument { get; set; }

  public test_OpDirectiveObject
    ( Itest_Identifier name
    )
  {
    Name = name;
  }
}

public class test_OpFragment
  : GqlpModelBase
  , Itest_OpFragment
{
  public Itest_OpFragmentObject? As__OpFragment { get; set; }
}

public class test_OpFragmentObject
  : GqlpModelBase
  , Itest_OpFragmentObject
{
  public Itest_Identifier Name { get; set; }
  public Itest_Identifier? Type { get; set; }
  public ICollection<Itest_OpDirective> Directives { get; set; }
  public ICollection<Itest_OpObject> Body { get; set; }

  public test_OpFragmentObject
    ( Itest_Identifier name
    , ICollection<Itest_OpDirective> directives
    , ICollection<Itest_OpObject> body
    )
  {
    Name = name;
    Directives = directives;
    Body = body;
  }
}

public class test_Modifier
  : GqlpModelBase
  , Itest_Modifier
{
  public Itest_ModifierObject? As__Modifier { get; set; }
}

public class test_ModifierObject
  : GqlpModelBase
  , Itest_ModifierObject
{
  public test_ModifierKind ModifierKind { get; set; }
  public Itest_Identifier? By { get; set; }
  public bool? Optional { get; set; }

  public test_ModifierObject
    ( test_ModifierKind modifierKind
    )
  {
    ModifierKind = modifierKind;
  }
}

public class test_OpArgument
  : GqlpModelBase
  , Itest_OpArgument
{
  public Itest_OpArgValue? As_OpArgValue { get; set; }
  public Itest_OpArgList? As_OpArgList { get; set; }
  public Itest_OpArgMap? As_OpArgMap { get; set; }
  public Itest_OpArgumentObject? As__OpArgument { get; set; }
}

public class test_OpArgumentObject
  : GqlpModelBase
  , Itest_OpArgumentObject
{

  public test_OpArgumentObject
    ()
  {
  }
}

public class test_OpArgValue
  : GqlpModelBase
  , Itest_OpArgValue
{
  public GqlpValue? AsValue { get; set; }
  public Itest_OpArgValueObject? As__OpArgValue { get; set; }
}

public class test_OpArgValueObject
  : GqlpModelBase
  , Itest_OpArgValueObject
{
  public Itest_Identifier Variable { get; set; }

  public test_OpArgValueObject
    ( Itest_Identifier variable
    )
  {
    Variable = variable;
  }
}

public class test_OpArgList
  : GqlpModelBase
  , Itest_OpArgList
{
  public ICollection<Itest_OpArgValue>? As_OpArgValue { get; set; }
  public Itest_OpArgListObject? As__OpArgList { get; set; }
}

public class test_OpArgListObject
  : GqlpModelBase
  , Itest_OpArgListObject
{

  public test_OpArgListObject
    ()
  {
  }
}

public class test_OpArgMap
  : GqlpModelBase
  , Itest_OpArgMap
{
  public IDictionary<GqlpScalar, Itest_OpArgValue>? As_OpArgValue { get; set; }
  public Itest_OpArgMapObject? As__OpArgMap { get; set; }
}

public class test_OpArgMapObject
  : GqlpModelBase
  , Itest_OpArgMapObject
{
  public Itest_OpArgValue Value { get; set; }
  public Itest_Identifier ByVariable { get; set; }

  public test_OpArgMapObject
    ( Itest_OpArgValue value
    , Itest_Identifier byVariable
    )
  {
    Value = value;
    ByVariable = byVariable;
  }
}

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
    ( ICollection<Itest_OpObject> body
    )
  {
    Body = body;
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
    ( ICollection<Itest_OpDirective> directives
    , string body
    )
  {
    Directives = directives;
    Body = body;
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
    ( Itest_Identifier fragment
    , ICollection<Itest_OpDirective> directives
    )
  {
    Fragment = fragment;
    Directives = directives;
  }
}
