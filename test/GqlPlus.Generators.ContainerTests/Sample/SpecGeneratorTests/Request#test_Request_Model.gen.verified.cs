//HintName: test_Request_Model.gen.cs
// Generated from {CurrentDirectory}Request.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Request;

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
  public object? Parameters { get; set; }

  public test_RequestObject
    ( Itest_Operation pdefinition
    )
  {
    Definition = pdefinition;
  }
}

public class test_Identifier
  : GqlpDomainString
  , Itest_Identifier
{
}

public class test_Collections
  : GqlpModelBase
  , Itest_Collections
{
  public Itest_Modifier<test_ModifierKind>? As_ModifierKindList { get; set; }
  public Itest_ModifierKeyed<test_ModifierKind>? As_ModifierKindDictionary { get; set; }
  public Itest_ModifierKeyed<test_ModifierKind>? As_ModifierKindTypeParam { get; set; }
  public Itest_CollectionsObject? As__Collections { get; set; }
}

public class test_CollectionsObject
  : GqlpModelBase
  , Itest_CollectionsObject
{

  public test_CollectionsObject
    ()
  {
  }
}

public class test_ModifierKeyed<TModifierKind>
  : test_Modifier<TModifierKind>
  , Itest_ModifierKeyed<TModifierKind>
{
  public Itest_ModifierKeyedObject<TModifierKind>? As__ModifierKeyed { get; set; }
}

public class test_ModifierKeyedObject<TModifierKind>
  : test_ModifierObject<TModifierKind>
  , Itest_ModifierKeyedObject<TModifierKind>
{
  public Itest_Identifier By { get; set; }
  public bool IsOptional { get; set; }

  public test_ModifierKeyedObject
    ( TModifierKind pmodifierKind
    , Itest_Identifier pby
    , bool pisOptional
    ) : base(pmodifierKind)
  {
    By = pby;
    IsOptional = pisOptional;
  }
}

public class test_Modifiers
  : GqlpModelBase
  , Itest_Modifiers
{
  public Itest_Modifier<test_ModifierKind>? As_ModifierKindOptional { get; set; }
  public Itest_Collections? As_Collections { get; set; }
  public Itest_ModifiersObject? As__Modifiers { get; set; }
}

public class test_ModifiersObject
  : GqlpModelBase
  , Itest_ModifiersObject
{

  public test_ModifiersObject
    ()
  {
  }
}

public class test_Modifier<TModifierKind>
  : GqlpModelBase
  , Itest_Modifier<TModifierKind>
{
  public Itest_ModifierObject<TModifierKind>? As__Modifier { get; set; }
}

public class test_ModifierObject<TModifierKind>
  : GqlpModelBase
  , Itest_ModifierObject<TModifierKind>
{
  public TModifierKind ModifierKind { get; set; }

  public test_ModifierObject
    ( TModifierKind pmodifierKind
    )
  {
    ModifierKind = pmodifierKind;
  }
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
  public IDictionary<Itest_Path, ICollection<Itest_OpSelection>> Selections { get; set; }

  public test_OperationObject
    ( ICollection<Itest_OpVariable> pvariables
    , ICollection<Itest_OpDirective> pdirectives
    , ICollection<Itest_OpFragment> pfragments
    , Itest_OpResult presult
    , IDictionary<Itest_Path, ICollection<Itest_OpSelection>> pselections
    )
  {
    Variables = pvariables;
    Directives = pdirectives;
    Fragments = pfragments;
    Result = presult;
    Selections = pselections;
  }
}

public class test_Path
  : GqlpDomainString
  , Itest_Path
{
}

public class test_OpDirectives
  : GqlpModelBase
  , Itest_OpDirectives
{
  public Itest_OpDirectivesObject? As__OpDirectives { get; set; }
}

public class test_OpDirectivesObject
  : GqlpModelBase
  , Itest_OpDirectivesObject
{
  public Itest_Identifier Name { get; set; }
  public ICollection<string> Description { get; set; }
  public ICollection<Itest_OpDirective> Directives { get; set; }

  public test_OpDirectivesObject
    ( Itest_Identifier pname
    , ICollection<string> pdescription
    , ICollection<Itest_OpDirective> pdirectives
    )
  {
    Name = pname;
    Description = pdescription;
    Directives = pdirectives;
  }
}

public class test_OpVariable
  : test_OpDirectives
  , Itest_OpVariable
{
  public Itest_OpVariableObject? As__OpVariable { get; set; }
}

public class test_OpVariableObject
  : test_OpDirectivesObject
  , Itest_OpVariableObject
{
  public Itest_Identifier? Type { get; set; }
  public ICollection<Itest_Modifiers> Modifiers { get; set; }
  public GqlpValue? DefaultValue { get; set; }

  public test_OpVariableObject
    ( Itest_Identifier pname
    , ICollection<string> pdescription
    , ICollection<Itest_OpDirective> pdirectives
    , ICollection<Itest_Modifiers> pmodifiers
    ) : base(pname, pdescription, pdirectives)
  {
    Modifiers = pmodifiers;
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
    ( Itest_Identifier pname
    )
  {
    Name = pname;
  }
}

public class test_OpFragment
  : test_OpDirectives
  , Itest_OpFragment
{
  public Itest_OpFragmentObject? As__OpFragment { get; set; }
}

public class test_OpFragmentObject
  : test_OpDirectivesObject
  , Itest_OpFragmentObject
{
  public Itest_Identifier? Type { get; set; }

  public test_OpFragmentObject
    ( Itest_Identifier pname
    , ICollection<string> pdescription
    , ICollection<Itest_OpDirective> pdirectives
    ) : base(pname, pdescription, pdirectives)
  {
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

  public test_OpResultObject
    ()
  {
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
    ( Itest_Identifier pvariable
    )
  {
    Variable = pvariable;
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
    ( Itest_OpArgValue pvalue
    , Itest_Identifier pbyVariable
    )
  {
    Value = pvalue;
    ByVariable = pbyVariable;
  }
}

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
    ( Itest_Identifier pname
    , ICollection<string> pdescription
    , ICollection<Itest_OpDirective> pdirectives
    , ICollection<Itest_Modifiers> pmodifiers
    ) : base(pname, pdescription, pdirectives)
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
