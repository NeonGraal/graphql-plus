//HintName: test_constraint-alt-domain+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-alt-domain+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_domain_Dual;

public class testCnstAltDmnDual
  : GqlpEncoderBase
  , ItestCnstAltDmnDual
{
  public ItestRefCnstAltDmnDual<ItestDomCnstAltDmnDual>? AsRefCnstAltDmnDual { get; set; }
  public ItestCnstAltDmnDualObject? As_CnstAltDmnDual { get; set; }
}

public class testCnstAltDmnDualObject
  : GqlpEncoderBase
  , ItestCnstAltDmnDualObject
{

  public testCnstAltDmnDualObject
    ()
  {
  }
}

public class testRefCnstAltDmnDual<TRef>
  : GqlpEncoderBase
  , ItestRefCnstAltDmnDual<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefCnstAltDmnDualObject<TRef>? As_RefCnstAltDmnDual { get; set; }
}

public class testRefCnstAltDmnDualObject<TRef>
  : GqlpEncoderBase
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
