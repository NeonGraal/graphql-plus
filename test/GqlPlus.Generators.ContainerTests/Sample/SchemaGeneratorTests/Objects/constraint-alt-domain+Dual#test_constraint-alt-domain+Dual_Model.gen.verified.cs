//HintName: test_constraint-alt-domain+Dual_Model.gen.cs
// Generated from {CurrentDirectory}constraint-alt-domain+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_domain_Dual;

public class testCnstAltDmnDual
  : GqlpModelBase
  , ItestCnstAltDmnDual
{
  public ItestRefCnstAltDmnDual<ItestDomCnstAltDmnDual>? AsRefCnstAltDmnDual { get; set; }
  public ItestCnstAltDmnDualObject? As_CnstAltDmnDual { get; set; }
}

public class testCnstAltDmnDualObject
  : GqlpModelBase
  , ItestCnstAltDmnDualObject
{

  public testCnstAltDmnDualObject
    ()
  {
  }
}

public class testRefCnstAltDmnDual<TRef>
  : GqlpModelBase
  , ItestRefCnstAltDmnDual<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefCnstAltDmnDualObject<TRef>? As_RefCnstAltDmnDual { get; set; }
}

public class testRefCnstAltDmnDualObject<TRef>
  : GqlpModelBase
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
