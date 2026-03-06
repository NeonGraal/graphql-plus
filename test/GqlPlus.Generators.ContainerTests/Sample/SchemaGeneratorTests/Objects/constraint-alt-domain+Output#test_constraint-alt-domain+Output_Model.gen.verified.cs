//HintName: test_constraint-alt-domain+Output_Model.gen.cs
// Generated from {CurrentDirectory}constraint-alt-domain+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_domain_Output;

public class testCnstAltDmnOutp
  : GqlpModelImplementationBase
  , ItestCnstAltDmnOutp
{
  public ItestRefCnstAltDmnOutp<ItestDomCnstAltDmnOutp>? AsRefCnstAltDmnOutp { get; set; }
  public ItestCnstAltDmnOutpObject? As_CnstAltDmnOutp { get; set; }
}

public class testCnstAltDmnOutpObject
  : GqlpModelImplementationBase
  , ItestCnstAltDmnOutpObject
{

  public testCnstAltDmnOutpObject
    ()
  {
  }
}

public class testRefCnstAltDmnOutp<TRef>
  : GqlpModelImplementationBase
  , ItestRefCnstAltDmnOutp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefCnstAltDmnOutpObject<TRef>? As_RefCnstAltDmnOutp { get; set; }
}

public class testRefCnstAltDmnOutpObject<TRef>
  : GqlpModelImplementationBase
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
