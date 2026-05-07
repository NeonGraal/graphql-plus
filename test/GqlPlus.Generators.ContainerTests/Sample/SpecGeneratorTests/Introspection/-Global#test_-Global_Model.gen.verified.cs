//HintName: test_-Global_Model.gen.cs
// Generated from {CurrentDirectory}-Global.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Global;

public class test_AndType
  : test_Named
  , Itest_AndType
{
  public Itest_Type? As_Type { get; set; }
  public Itest_AndTypeObject? As__AndType { get; set; }
}

public class test_AndTypeObject
  : test_NamedObject
  , Itest_AndTypeObject
{
  public Itest_Type Type { get; set; }

  public test_AndTypeObject
    ( Itest_Type ptype
    )
  {
    Type = ptype;
  }
}

public class test_Categories
  : test_AndType
  , Itest_Categories
{
  public Itest_Category? As_Category { get; set; }
  public Itest_CategoriesObject? As__Categories { get; set; }
}

public class test_CategoriesObject
  : test_AndTypeObject
  , Itest_CategoriesObject
{
  public Itest_Category Category { get; set; }

  public test_CategoriesObject
    ( Itest_Type ptype
    , Itest_Category pcategory
    ) : base(ptype)
  {
    Category = pcategory;
  }
}

public class test_Category
  : test_Aliased
  , Itest_Category
{
  public Itest_CategoryObject? As__Category { get; set; }
}

public class test_CategoryObject
  : test_AliasedObject
  , Itest_CategoryObject
{
  public test_Resolution Resolution { get; set; }
  public Itest_TypeRef<Itest_TypeKind> Output { get; set; }
  public ICollection<Itest_Modifiers> Modifiers { get; set; }

  public test_CategoryObject
    ( test_Resolution presolution
    , Itest_TypeRef<Itest_TypeKind> poutput
    , ICollection<Itest_Modifiers> pmodifiers
    )
  {
    Resolution = presolution;
    Output = poutput;
    Modifiers = pmodifiers;
  }
}

public class test_Directives
  : test_AndType
  , Itest_Directives
{
  public Itest_Directive? As_Directive { get; set; }
  public Itest_DirectivesObject? As__Directives { get; set; }
}

public class test_DirectivesObject
  : test_AndTypeObject
  , Itest_DirectivesObject
{
  public Itest_Directive Directive { get; set; }

  public test_DirectivesObject
    ( Itest_Type ptype
    , Itest_Directive pdirective
    ) : base(ptype)
  {
    Directive = pdirective;
  }
}

public class test_Directive
  : test_Aliased
  , Itest_Directive
{
  public Itest_DirectiveObject? As__Directive { get; set; }
}

public class test_DirectiveObject
  : test_AliasedObject
  , Itest_DirectiveObject
{
  public Itest_InputFieldType? Parameter { get; set; }
  public bool Repeatable { get; set; }
  public IDictionary<test_Location, GqlpUnit> Locations { get; set; }

  public test_DirectiveObject
    ( bool prepeatable
    , IDictionary<test_Location, GqlpUnit> plocations
    )
  {
    Repeatable = prepeatable;
    Locations = plocations;
  }
}

public class test_Operations
  : GqlpModelBase
  , Itest_Operations
{
  public Itest_Operation? As_Operation { get; set; }
  public Itest_Type? As_Type { get; set; }
  public Itest_OperationsObject? As__Operations { get; set; }
}

public class test_OperationsObject
  : GqlpModelBase
  , Itest_OperationsObject
{
  public Itest_Operation Operation { get; set; }
  public Itest_Type Type { get; set; }

  public test_OperationsObject
    ( Itest_Operation poperation
    , Itest_Type ptype
    )
  {
    Operation = poperation;
    Type = ptype;
  }
}

public class test_OpDirectives
  : test_Named
  , Itest_OpDirectives
{
  public Itest_OpDirectivesObject? As__OpDirectives { get; set; }
}

public class test_OpDirectivesObject
  : test_NamedObject
  , Itest_OpDirectivesObject
{
  public ICollection<Itest_OpDirective> Directives { get; set; }

  public test_OpDirectivesObject
    ( ICollection<Itest_OpDirective> pdirectives
    )
  {
    Directives = pdirectives;
  }
}

public class test_Operation
  : test_Aliased
  , Itest_Operation
{
  public Itest_OperationObject? As__Operation { get; set; }
}

public class test_OperationObject
  : test_AliasedObject
  , Itest_OperationObject
{
  public Itest_Name Category { get; set; }
  public IDictionary<Itest_Name, Itest_OpVariable> Variables { get; set; }
  public ICollection<Itest_OpDirective> Directives { get; set; }
  public IDictionary<Itest_Name, Itest_OpFragment> Fragments { get; set; }
  public Itest_OpResult Result { get; set; }
  public IDictionary<Itest_Path, ICollection<Itest_OpSelection>> Selections { get; set; }

  public test_OperationObject
    ( Itest_Name pcategory
    , IDictionary<Itest_Name, Itest_OpVariable> pvariables
    , ICollection<Itest_OpDirective> pdirectives
    , IDictionary<Itest_Name, Itest_OpFragment> pfragments
    , Itest_OpResult presult
    , IDictionary<Itest_Path, ICollection<Itest_OpSelection>> pselections
    )
  {
    Category = pcategory;
    Variables = pvariables;
    Directives = pdirectives;
    Fragments = pfragments;
    Result = presult;
    Selections = pselections;
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
  public Itest_TypeRef<Itest_TypeKind> Type { get; set; }
  public ICollection<Itest_Modifiers> Modifiers { get; set; }
  public GqlpValue? DefaultValue { get; set; }

  public test_OpVariableObject
    ( ICollection<Itest_OpDirective> pdirectives
    , Itest_TypeRef<Itest_TypeKind> ptype
    , ICollection<Itest_Modifiers> pmodifiers
    ) : base(pdirectives)
  {
    Type = ptype;
    Modifiers = pmodifiers;
  }
}

public class test_OpDirective
  : test_Named
  , Itest_OpDirective
{
  public Itest_OpDirectiveObject? As__OpDirective { get; set; }
}

public class test_OpDirectiveObject
  : test_NamedObject
  , Itest_OpDirectiveObject
{
  public Itest_OpArgument? Argument { get; set; }

  public test_OpDirectiveObject
    ()
  {
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
  public Itest_TypeRef<Itest_TypeKind> Type { get; set; }

  public test_OpFragmentObject
    ( ICollection<Itest_OpDirective> pdirectives
    , Itest_TypeRef<Itest_TypeKind> ptype
    ) : base(pdirectives)
  {
    Type = ptype;
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
  public Itest_Name Variable { get; set; }

  public test_OpArgValueObject
    ( Itest_Name pvariable
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
  public Itest_Name ByVariable { get; set; }

  public test_OpArgMapObject
    ( Itest_OpArgValue pvalue
    , Itest_Name pbyVariable
    )
  {
    Value = pvalue;
    ByVariable = pbyVariable;
  }
}

public class test_OpResult
  : GqlpModelBase
  , Itest_OpResult
{
  public Itest_TypeRef<Itest_SimpleKind>? As_TypeRef { get; set; }
  public Itest_OpResultObject? As__OpResult { get; set; }
}

public class test_OpResultObject
  : GqlpModelBase
  , Itest_OpResultObject
{
  public Itest_OpArgument? Argument { get; set; }

  public test_OpResultObject
    ()
  {
  }
}

public class test_Path
  : GqlpDomainString
  , Itest_Path
{
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
  public string? FieldAlias { get; set; }
  public Itest_OpArgument? Argument { get; set; }
  public ICollection<Itest_Modifiers> Modifiers { get; set; }

  public test_OpFieldObject
    ( ICollection<Itest_OpDirective> pdirectives
    , ICollection<Itest_Modifiers> pmodifiers
    ) : base(pdirectives)
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
  public Itest_TypeRef<Itest_TypeKind>? Type { get; set; }
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
  public string Fragment { get; set; }
  public ICollection<Itest_OpDirective> Directives { get; set; }

  public test_OpSpreadObject
    ( string pfragment
    , ICollection<Itest_OpDirective> pdirectives
    )
  {
    Fragment = pfragment;
    Directives = pdirectives;
  }
}

public class test_Setting
  : test_Named
  , Itest_Setting
{
  public Itest_SettingObject? As__Setting { get; set; }
}

public class test_SettingObject
  : test_NamedObject
  , Itest_SettingObject
{
  public GqlpValue Value { get; set; }

  public test_SettingObject
    ( GqlpValue pvalue
    )
  {
    Value = pvalue;
  }
}
