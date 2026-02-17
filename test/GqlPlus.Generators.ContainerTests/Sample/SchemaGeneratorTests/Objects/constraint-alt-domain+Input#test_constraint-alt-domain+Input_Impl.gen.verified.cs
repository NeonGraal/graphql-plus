//HintName: test_constraint-alt-domain+Input_Impl.gen.cs
// Generated from {CurrentDirectory}constraint-alt-domain+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_domain_Input;

public class testCnstAltDmnInp
  : GqlpModelImplementationBase
  , ItestCnstAltDmnInp
{
  public ItestRefCnstAltDmnInp<ItestDomCnstAltDmnInp>? AsRefCnstAltDmnInp { get; set; }
  public ItestCnstAltDmnInpObject? As_CnstAltDmnInp { get; set; }
}

public class testCnstAltDmnInpObject
  : GqlpModelImplementationBase
  , ItestCnstAltDmnInpObject
{

  public testCnstAltDmnInpObject()
  {
  }
}

public class testRefCnstAltDmnInp<TRef>
  : GqlpModelImplementationBase
  , ItestRefCnstAltDmnInp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefCnstAltDmnInpObject<TRef>? As_RefCnstAltDmnInp { get; set; }
}

public class testRefCnstAltDmnInpObject<TRef>
  : GqlpModelImplementationBase
  , ItestRefCnstAltDmnInpObject<TRef>
{

  public testRefCnstAltDmnInpObject()
  {
  }
}

public class testDomCnstAltDmnInp
  : GqlpDomainString
  , ItestDomCnstAltDmnInp
{
}
