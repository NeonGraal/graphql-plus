//HintName: test_constraint-alt-domain+Output_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-alt-domain+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_domain_Output;

public class testCnstAltDmnOutp
  : GqlpEncoderBase
  , ItestCnstAltDmnOutp
{
  public ItestRefCnstAltDmnOutp<ItestDomCnstAltDmnOutp>? AsRefCnstAltDmnOutp { get; set; }
  public ItestCnstAltDmnOutpObject? As_CnstAltDmnOutp { get; set; }
}

public class testCnstAltDmnOutpObject
  : GqlpEncoderBase
  , ItestCnstAltDmnOutpObject
{

  public testCnstAltDmnOutpObject
    ()
  {
  }
}

public class testRefCnstAltDmnOutp<TRef>
  : GqlpEncoderBase
  , ItestRefCnstAltDmnOutp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefCnstAltDmnOutpObject<TRef>? As_RefCnstAltDmnOutp { get; set; }
}

public class testRefCnstAltDmnOutpObject<TRef>
  : GqlpEncoderBase
  , ItestRefCnstAltDmnOutpObject<TRef>
{

  public testRefCnstAltDmnOutpObject
    ()
  {
  }
}

public class testDomCnstAltDmnOutp
  : GqlpDomainString
  , ItestDomCnstAltDmnOutp
{
}
