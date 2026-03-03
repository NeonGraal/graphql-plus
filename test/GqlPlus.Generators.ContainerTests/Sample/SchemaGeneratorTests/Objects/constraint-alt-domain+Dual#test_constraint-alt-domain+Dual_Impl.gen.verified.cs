//HintName: test_constraint-alt-domain+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}constraint-alt-domain+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_domain_Dual;

public class testCnstAltDmnDual
  : GqlpModelImplementationBase
  , ItestCnstAltDmnDual
{
  public ItestRefCnstAltDmnDual<ItestDomCnstAltDmnDual>? AsRefCnstAltDmnDual { get; set; }
  public ItestCnstAltDmnDualObject? As_CnstAltDmnDual { get; set; }
}

public class testCnstAltDmnDualObject
  : GqlpModelImplementationBase
  , ItestCnstAltDmnDualObject
{

  public testCnstAltDmnDualObject
    ()
  {
  }
}

public class testRefCnstAltDmnDual<TRef>
  : GqlpModelImplementationBase
  , ItestRefCnstAltDmnDual<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefCnstAltDmnDualObject<TRef>? As_RefCnstAltDmnDual { get; set; }
}

public class testRefCnstAltDmnDualObject<TRef>
  : GqlpModelImplementationBase
  , ItestRefCnstAltDmnDualObject<TRef>
{

  public testRefCnstAltDmnDualObject
    ()
  {
  }
}

public class testDomCnstAltDmnDual
  : GqlpDomainString
  , ItestDomCnstAltDmnDual
{
}
