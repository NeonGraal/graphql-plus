//HintName: test_Operation_Model.gen.cs
// Generated from {CurrentDirectory}Operation.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Operation;

public class test_Operation
  : GqlpModelImplementationBase
  , Itest_Operation
{
  public string? AsString { get; set; }
  public Itest_OperationObject? As__Operation { get; set; }
}

public class test_OperationObject
  : GqlpModelImplementationBase
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
  : GqlpModelImplementationBase
  , Itest_OpVariable
{
  public Itest_OpVariableObject? As__OpVariable { get; set; }
}

public class test_OpVariableObject
  : GqlpModelImplementationBase
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
  : GqlpModelImplementationBase
  , Itest_OpDirective
{
  public Itest_OpDirectiveObject? As__OpDirective { get; set; }
}

public class test_OpDirectiveObject
  : GqlpModelImplementationBase
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
  : GqlpModelImplementationBase
  , Itest_OpFragment
{
  public Itest_OpFragmentObject? As__OpFragment { get; set; }
}

public class test_OpFragmentObject
  : GqlpModelImplementationBase
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
  : GqlpModelImplementationBase
  , Itest_Modifier
{
  public Itest_ModifierObject? As__Modifier { get; set; }
}

public class test_ModifierObject
  : GqlpModelImplementationBase
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
  : GqlpModelImplementationBase
  , Itest_OpArgument
{
  public Itest_OpArgValue? As_OpArgValue { get; set; }
  public Itest_OpArgList? As_OpArgList { get; set; }
  public Itest_OpArgMap? As_OpArgMap { get; set; }
  public Itest_OpArgumentObject? As__OpArgument { get; set; }
}

public class test_OpArgumentObject
  : GqlpModelImplementationBase
  , Itest_OpArgumentObject
{

  public test_OpArgumentObject
    ()
  {
  }
}

public class test_OpArgValue
  : GqlpModelImplementationBase
  , Itest_OpArgValue
{
  public GqlpValue? AsValue { get; set; }
  public Itest_OpArgValueObject? As__OpArgValue { get; set; }
}

public class test_OpArgValueObject
  : GqlpModelImplementationBase
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
  : GqlpModelImplementationBase
  , Itest_OpArgList
{
  public ICollection<Itest_OpArgValue>? As_OpArgValue { get; set; }
  public Itest_OpArgListObject? As__OpArgList { get; set; }
}

public class test_OpArgListObject
  : GqlpModelImplementationBase
  , Itest_OpArgListObject
{

  public test_OpArgListObject
    ()
  {
  }
}

public class test_OpArgMap
  : GqlpModelImplementationBase
  , Itest_OpArgMap
{
  public IDictionary<GqlpScalar, Itest_OpArgValue>? As_OpArgValue { get; set; }
  public Itest_OpArgMapObject? As__OpArgMap { get; set; }
}

public class test_OpArgMapObject
  : GqlpModelImplementationBase
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
