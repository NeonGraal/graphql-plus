//HintName: test_constraint-alt-domain+Input_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-alt-domain+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_domain_Input;

public class testCnstAltDmnInp
  : GqlpEncoderBase
  , ItestCnstAltDmnInp
{
  public ItestRefCnstAltDmnInp<ItestDomCnstAltDmnInp>? AsRefCnstAltDmnInp { get; set; }
  public ItestCnstAltDmnInpObject? As_CnstAltDmnInp { get; set; }
}

public class testCnstAltDmnInpObject
  : GqlpEncoderBase
  , ItestCnstAltDmnInpObject
{

  public testCnstAltDmnInpObject
    ()
  {
  }
}

public class testRefCnstAltDmnInp<TRef>
  : GqlpEncoderBase
  , ItestRefCnstAltDmnInp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefCnstAltDmnInpObject<TRef>? As_RefCnstAltDmnInp { get; set; }
}

public class testRefCnstAltDmnInpObject<TRef>
  : GqlpEncoderBase
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
