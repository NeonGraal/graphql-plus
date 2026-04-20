//HintName: test_Operation_Model.gen.cs
// Generated from {CurrentDirectory}Operation.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Operation;

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
    ( ICollection<Itest_OpVariable> pvariables
    , ICollection<Itest_OpDirective> pdirectives
    , ICollection<Itest_OpFragment> pfragments
    , Itest_OpResult presult
    )
  {
    Variables = pvariables;
    Directives = pdirectives;
    Fragments = pfragments;
    Result = presult;
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
    ( Itest_Identifier pname
    , ICollection<Itest_Modifier> pmodifiers
    , ICollection<Itest_OpDirective> pdirectives
    )
  {
    Name = pname;
    Modifiers = pmodifiers;
    Directives = pdirectives;
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
    ( Itest_Identifier pname
    , ICollection<Itest_OpDirective> pdirectives
    , ICollection<Itest_OpObject> pbody
    )
  {
    Name = pname;
    Directives = pdirectives;
    Body = pbody;
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
    ( test_ModifierKind pmodifierKind
    )
  {
    ModifierKind = pmodifierKind;
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
