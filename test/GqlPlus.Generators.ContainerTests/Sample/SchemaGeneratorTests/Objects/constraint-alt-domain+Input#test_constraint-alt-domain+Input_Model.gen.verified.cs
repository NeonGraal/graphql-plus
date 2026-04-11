//HintName: test_constraint-alt-domain+Input_Model.gen.cs
// Generated from {CurrentDirectory}constraint-alt-domain+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_domain_Input;

public class testCnstAltDmnInp
  : GqlpModelBase
  , ItestCnstAltDmnInp
{
  public ItestRefCnstAltDmnInp<ItestDomCnstAltDmnInp>? AsRefCnstAltDmnInp { get; set; }
  public ItestCnstAltDmnInpObject? As_CnstAltDmnInp { get; set; }
}

public class testCnstAltDmnInpObject
  : GqlpModelBase
  , ItestCnstAltDmnInpObject
{

  public testCnstAltDmnInpObject
    ()
  {
  }
}

public class testRefCnstAltDmnInp<TRef>
  : GqlpModelBase
  , ItestRefCnstAltDmnInp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefCnstAltDmnInpObject<TRef>? As_RefCnstAltDmnInp { get; set; }
}

public class testRefCnstAltDmnInpObject<TRef>
  : GqlpModelBase
  , ItestRefCnstAltDmnInpObject<TRef>
{

  public testRefCnstAltDmnInpObject
    ()
  {
  }
}

public class testDomCnstAltDmnInp
  : GqlpDomainString
  , ItestDomCnstAltDmnInp
{
}
